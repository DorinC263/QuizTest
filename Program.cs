namespace QuizTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.DisplayWelcomeMessage();

            List<Question> questions = new List<Question>();

            while (true)
            {
                Console.WriteLine("Enter a multiple-choice question or 'Q' to quit");
                Console.WriteLine("You can also play the Quizz you just created by pressing 'P'");
                Console.Write("Question : ");
                string questionText = Console.ReadLine();

                if (questionText.ToUpper() == "Q")
                {
                    break;
                }
                else if (questionText.ToUpper() == "P")
                {
                    Play.PlayQuiz(questions);
                    continue;
                }

                Console.Write("Option A : ");
                string optionA = Console.ReadLine();

                Console.Write("Option B : ");
                string optionB = Console.ReadLine();

                Console.Write("Option C : ");
                string optionC = Console.ReadLine();

                Console.WriteLine("And the correct answer (A, B or C ) : ");
                char correctAnswer = char.ToUpper(Console.ReadKey().KeyChar);

                if (correctAnswer != 'A' && correctAnswer != 'B' && correctAnswer != 'C')
                {
                    Console.WriteLine("\nInvalid Option.The question won`t be added to the list");
                }
                else
                {
                    questions.Add(new Question(questionText, optionA, optionB, optionC, correctAnswer));
                    Console.WriteLine("\nQuestion added\n");
                }
            }

            Console.WriteLine("List of multiple-choice questions!");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{questions[i].QuestionText}");
                Console.WriteLine($"A. {questions[i].OptionA}");
                Console.WriteLine($"B. {questions[i].OptionB}");
                Console.WriteLine($"C. {questions[i].OptionC}");
                Console.WriteLine($"Correct Answer : {questions[i].CorrectAnswer}");
            }
        }        
    }
}