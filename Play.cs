﻿namespace QuizTest
{
    internal class Play
    {
        public static void PlayQuiz()
        {
            int score = 0;
            Console.WriteLine("Let's start the Quiz! \n");

            string relativePath = Program.NAME_OF_XML;
            List<Question> questions = FileOperations.DeSerializeQuestions(relativePath);

            int totalQuestions = questions.Count;

            foreach (var question in questions)
            {
                Console.WriteLine($"\n{question.QuestionText}");
                foreach (AnswerOption answerOption in Enum.GetValues(typeof(AnswerOption)))
                {
                    string optionLabel = Enum.GetName(typeof(AnswerOption), answerOption);
                    Console.WriteLine($"{optionLabel} : {question.AnswerOptions[(int)answerOption]}");
                }

                AnswerOption userAnswer = UIMethods.PromptForValidAnswer("Your Answer : ");
                Console.WriteLine();

                if (userAnswer == question.CorrectAnswer)
                {
                    score++;
                    UIMethods.DisplayWin(score);
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer was {question.CorrectAnswer}");
                }
            }

            Console.WriteLine($"Quiz Complete. You answered {score} correct questions out of {totalQuestions} questions\n");
        }
    }
}