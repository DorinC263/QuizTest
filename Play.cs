namespace QuizTest
{
    internal class Play
    {
        public static void PlayQuiz()
        {
            int score = 0;
            UIMethods.DisplayStartQuiz();

            string relativePath = Program.NAME_OF_XML;
            List<Question> questions = FileOperations.DeSerializeQuestions(relativePath);

            int totalQuestions = questions.Count;

            foreach (var question in questions)
            {
                UIMethods.DisplayQuestionsWithOptions(question);

                AnswerOption userAnswer = UIMethods.PromptForValidAnswer("Your Answer : ");
                Console.WriteLine();

                if (userAnswer == question.CorrectAnswer)
                {
                    score++;
                    UIMethods.DisplayWin(score);
                }
                else
                {
                    UIMethods.DisplayIncorrectAnswer(question.CorrectAnswer);
                }
            }

            UIMethods.DisplayQuizComplete(score,totalQuestions);
        }
    }
}