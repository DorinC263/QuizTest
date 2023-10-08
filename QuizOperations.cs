namespace QuizTest
{
    internal class QuizOperations
    {
        /// <summary>
        /// Get answer options for a question and add it to the list of questions.
        /// </summary>
        /// <param name="questionText">The text of the question.</param>
        /// <param name="questions">The list of questions to add the new question to.</param>
        public static List<string> GetAnswerOption()
        {
            List<string> answerOptions = new List<string>();
            foreach (AnswerOption option in Enum.GetValues(typeof(AnswerOption)))
            {
                string optionText = UIMethods.PromptForNonEmptyString($"Option {option} : ");
                answerOptions.Add(optionText);
            } 
            return answerOptions;
        }
        /// <summary>
        /// Adds a new question to the list of questions.
        /// </summary>
        /// <param name="questionText">The text of the question.</param>
        /// <param name="answerOptions">The list of answer options for the question.</param>
        /// <param name="questions">The list of questions to which the new question will be added.</param>
        public static void AddQuestion(string questionText,List<string> answerOptions,List<Question> questions)
        {
            AnswerOption correctAnswer = UIMethods.PromptForValidAnswer("The correct answer is : "); // Prompt for the user's answer

            Question newQuestion = new Question
            {
                QuestionText = questionText,
                AnswerOptions = answerOptions,
                CorrectAnswer = correctAnswer
            };
            questions.Add(newQuestion); // Add the new question to the list
        }
    }
}
