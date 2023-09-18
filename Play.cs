using System.Xml.Serialization;

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
            Console.WriteLine("Lets start the Quizz! \n");

            // The user can either answer from a set of questions that he previously added or he can add the questions and answer them.
            XmlSerializer serializer = new(typeof(List<Question>));
            var path = @"C:\Users\Admin\Desktop\Questions.xml";
            using (FileStream file = File.OpenRead(path))
            {
                questions = serializer.Deserialize(file) as List<Question>;
            }
            /// even if the user adds or takes the questions from deserializer, total questions will give the correct output.
            int totalQuestions = questions.Count;

            // for every question in the list of questions, he can choose the option to the question.
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
            Console.WriteLine($"Quizz Complete. You answered {score} correct questions / out of {totalQuestions} questions\n");
        }
    }
}
