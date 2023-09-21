using System;
using System.Collections.Generic;
using QuizTest;  // Import the QuizTest namespace to access its classes

namespace QuizTest
{
    internal class Program
    {
        const string QUIT_GAME = "Q";   // Define a constant string for quitting the game
        const string PLAY_GAME = "P";   // Define a constant string for playing the game

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

                string optionA = UIMethods.PromptForNonEmptyString("Option A: "); // Prompt for option A
                string optionB = UIMethods.PromptForNonEmptyString("Option B: "); // Prompt for option B
                string optionC = UIMethods.PromptForNonEmptyString("Option C: "); // Prompt for option C

                UIMethods.PromptCorrectAnswer(); // Prompt the user for the correct answer
                char correctAnswer = UIMethods.PromptForEmptyChar("Your Answer (A, B, or C): "); // Prompt for the user's answer

                if (!Enum.TryParse(correctAnswer.ToString(), out AnswerOption parsedAnswer)) // Check if the answer is valid
                {
                    Console.WriteLine("\nInvalid Option. The question won't be added to the list."); // Display an error message
                }
                else
                {
                    // Create a new question and add it to the list
                    Question newQuestion = new Question
                    {
                        QuestionText = questionText,
                        AnswerOptions = new List<string> { optionA, optionB, optionC },
                        CorrectAnswer = parsedAnswer
                    };
                    questions.Add(newQuestion); // Add the new question to the list
                    Console.WriteLine("\nQuestion added\n"); // Display a success message

                    string relativePath = "Questions.xml"; // Define the relative path for XML serialization
                    FileOperations.SerializeQuestions(questions, relativePath); // Serialize questions to an XML file
                }
            }
            UIMethods.DisplayQuestions(questions); // Display all added questions to the user
        }
    }
}
