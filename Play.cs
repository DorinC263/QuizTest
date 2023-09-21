using System;
using System.Collections.Generic;

namespace QuizTest
{
    internal class Play
    {
        public static void PlayQuiz()
        {
            int score = 0;
            Console.WriteLine("Let's start the Quiz! \n");

            string relativePath = "Questions.xml";
            List<Question> questions = FileOperations.DeSerializeQuestions(relativePath);

            int totalQuestions = questions.Count;

            foreach (var question in questions)
            {
                Console.WriteLine($"\n{question.QuestionText}");
                string[] optionLabel = { "Option A", "Option B", "Option C" };

                for (int i = 0; i < question.AnswerOptions.Count; i++)
                {
                    Console.WriteLine($"{optionLabel[i]} : {question.AnswerOptions[i]}");
                }

                char userAnswerChar = UIMethods.PromptForEmptyChar("Your Answer (A, B, or C): ");
                Console.WriteLine();

                if (Enum.TryParse(userAnswerChar.ToString(), out AnswerOption userAnswer))
                {
                    if (userAnswer == question.CorrectAnswer)
                    {
                        Console.WriteLine("That is correct!");
                        score++;
                        Console.WriteLine($"Your score is {score}");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer was {question.CorrectAnswer}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Answer. Please enter A, B, or C!");
                }
            }

            Console.WriteLine($"Quiz Complete. You answered {score} correct questions out of {totalQuestions} questions\n");
        }
    }
}
