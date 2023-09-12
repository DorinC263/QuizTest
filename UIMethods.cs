﻿namespace QuizTest
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


    }
}
