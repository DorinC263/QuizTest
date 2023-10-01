namespace QuizTest
{
    internal class QuizOperations
    {
        /// <summary>
        /// Get answer options for a question and add it to the list of questions.
        /// </summary>
        /// <param name="questionText">The text of the question.</param>
        /// <param name="questions">The list of questions to add the new question to.</param>
        public static List<string> GetAnswerOption(string questionText,List<Question> questions)
        {
            List<string> answerOptions = new List<string>();
            foreach (AnswerOption option in Enum.GetValues(typeof(AnswerOption)))
            {
                string optionText = UIMethods.PromptForNonEmptyString($"Option {option} : ");
                answerOptions.Add(optionText);
            }
            AnswerOption correctAnswer = UIMethods.PromptForValidAnswer("The correct answer is : "); // Prompt for the user's answer

            // Create a new question and add it to the list
            Question newQuestion = new Question
            {
                QuestionText = questionText,
                AnswerOptions = answerOptions,
                CorrectAnswer = correctAnswer
            };
            questions.Add(newQuestion); // Add the new question to the list
            UIMethods.DisplaySuccessMessage();
            return answerOptions;
        }
    }
}
