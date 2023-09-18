namespace QuizTest
{
    public static class UIMethods
    {
        /// <summary>
        /// Welcome Message
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\tWelcome to Question Game");
            Console.WriteLine("You can add as many multiple-choice questions as you like.");
            Console.WriteLine("After that you can play your own Quizz!\n");
        }
        /// <summary>
        /// No Empty Strings
        /// </summary>
        /// <param name="message">if the user does not input anything, the method will keep prompting for input</param>
        /// <returns></returns>
        public static string PromptForNonEmptyString(string message)
        {
            string input;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));
            return input;
        }

        /// <summary>
        /// Displaying if the user wants to add the question with options or he wants to quit
        /// </summary>
        public static void DisplayQuitOrPlaying()
        {
            Console.WriteLine("Enter a multiple-choice question or 'Q' to quit");
            Console.WriteLine("You can also play the Quizz you just created by pressing 'P'");
        }

        /// <summary>
        /// Prompts the user for the correct option to the question he added
        /// </summary>
        public static void PromptCorrectAnswer()
        {
            Console.WriteLine("And the correct answer (A, B or C ) : ");
        }
    }
}
