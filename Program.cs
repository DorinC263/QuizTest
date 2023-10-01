namespace QuizTest
{
    internal class Program
    {
        public const string QUIT_GAME = "Q";   // Define a constant string for quitting the game
        public const string PLAY_GAME = "P";   // Define a constant string for playing the game
        public const string NAME_OF_XML = "Questions.xml";
        static void Main(string[] args)
        {
            UIMethods.DisplayWelcomeMessage(); // Display a welcome message to the user
            List<Question> questions = new List<Question>(); // Declare a list to store questions

            while (true) // Start an infinite loop for user interaction
            {
                UIMethods.DisplayQuitOrPlaying(); // Display options to the user
                string questionText = UIMethods.PromptForNonEmptyString("Question: "); // Prompt user for a question

                if (questionText.ToUpper() == QUIT_GAME) // Check if the user wants to quit
                {
                    break; // Exit the loop if the user chooses to quit
                }
                else if (questionText.ToUpper() == PLAY_GAME) // Check if the user wants to play
                {
                    Play.PlayQuiz(); // Call the PlayQuiz method to play the game
                    continue; // Continue the loop to provide more options
                }

                //Use a loop to iterate through AnswerOption enum values
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

                string relativePath = NAME_OF_XML; // Define the relative path for XML serialization
                FileOperations.SerializeQuestions(questions, relativePath); // Serialize questions to an XML file                
            }
            UIMethods.DisplayQuestions(questions); // Display all added questions to the user
        }
    }
}
