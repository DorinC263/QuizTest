using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;

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
                UIMethods.DisplayQuitOrPlaying();
                string questionText = UIMethods.PromptForNonEmptyString("Question : ");
                
                //If the user chooses Q it quits the program
                if (questionText.ToUpper() == "Q")
                {
                    break;
                }
                //if the user chooses P it goes to play the added questions.
                else if (questionText.ToUpper() == "P")
                {
                    Play.PlayQuiz(questions);
                    continue;
                }

                string optionA = UIMethods.PromptForNonEmptyString("Option A: ");
                string optionB = UIMethods.PromptForNonEmptyString("Option B: ");
                string optionC = UIMethods.PromptForNonEmptyString("Option C: ");

                UIMethods.PromptCorrectAnswer();
                char correctAnswer = char.ToUpper(Console.ReadKey().KeyChar);

                // After he added the question and options, if he doesn`t choose the correct ABC as the correct answer, the question won`t be added at all.
                if (correctAnswer != 'A' && correctAnswer != 'B' && correctAnswer != 'C')
                {
                    Console.WriteLine("\nInvalid Option.The question won`t be added to the list");
                }
                else
                {
                    Question newQuestion = new Question
                    {
                        QuestionText = questionText,
                        OptionA = optionA,
                        OptionB = optionB,
                        OptionC = optionC,
                        CorrectAnswer = correctAnswer
                    };

                    questions.Add(newQuestion);
                    Console.WriteLine("\nQuestion added\n");

                    // It serializes the questions and options and correct answer only if the question is added to the list.
                    XmlSerializer serializer = new(typeof(List<Question>));

                    var path = @"C:\Users\Admin\Desktop\Questions.xml";
                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, questions);
                    }
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