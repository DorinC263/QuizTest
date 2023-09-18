namespace QuizTest
{
    /// <summary>
    /// This code plays the questions and answers the user just added.
    /// </summary>
    internal class Play
    {
        public static void PlayQuiz(List<Question> questions)
        {
            int score = 0;
            int totalQuestions = questions.Count;
            Console.WriteLine("Lets start the Quizz! \n");

            foreach (var question in questions)
            {
                Console.WriteLine("\n" + question.QuestionText);
                Console.WriteLine($"A. {question.OptionA}");
                Console.WriteLine($"B. {question.OptionB}");
                Console.WriteLine($"C. {question.OptionC}");

                Console.WriteLine("Your Answer (A, B or C) : ");
                char userAnswer = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (userAnswer == question.CorrectAnswer)
                {
                    Console.WriteLine("That is Correct!");
                    score++;
                    Console.WriteLine($"Your score is {score}");
                }
                else
                {
                    Console.WriteLine($"Inccorect. The correct answer was {question.CorrectAnswer}");
                }
            }
            Console.WriteLine($"Quizz Complete. Your score is {score}/{totalQuestions}\n");
        }
    }
}
