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
            Console.WriteLine("Lets start the Quiz! \n");

            // The user can either answer from a set of questions that he previously added or he can add the questions and answer them.
            string relativePath = "Questions.xml";
            List<Question> deserializedQuestions = FileOperations.DeSerializeQuestions(relativePath);

            /// even if the user adds or takes the questions from deserializer, total questions will give the correct output.
            int totalQuestions = deserializedQuestions.Count;

            // for every question in the list of questions, he can choose the option to the question.
            foreach (var question in deserializedQuestions)
            {
                Console.WriteLine("\n" + question.QuestionText);
                Console.WriteLine($"A. {question.OptionA}");
                Console.WriteLine($"B. {question.OptionB}");
                Console.WriteLine($"C. {question.OptionC}");

                char userAnswer = UIMethods.PromptForEmptyChar("Your Answer (A, B or C) : ");
                Console.WriteLine();

                if (userAnswer == question.CorrectAnswer)
                {
                    Console.WriteLine("That is Correct!");
                    score++;
                    Console.WriteLine($"Your score is {score}");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer was {question.CorrectAnswer}");
                }
            }
            Console.WriteLine($"Quiz Complete. You answered {score} correct questions / out of {totalQuestions} questions\n");
        }
    }
}
