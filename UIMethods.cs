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
            Console.WriteLine("After that you can play your own Quiz!\n");
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
        /// No empty char
        /// </summary>
        /// <param name="message"></param>
        /// <returns>It goes through Enums to check for valid answers, if it doesnt contain them, the loop continue.</returns>
        public static AnswerOption PromptForValidAnswer(string message)
        {
            Console.Write(message);
            AnswerOption userAnswer;
            bool isValidAnswer;
            do
            {
                char.TryParse(Console.ReadKey().KeyChar.ToString().ToUpper(), out char inputChar);
                isValidAnswer = Enum.TryParse(inputChar.ToString(), out userAnswer);
                if (!isValidAnswer)
                {
                    Console.WriteLine("\nInvalid Option");
                }
            }
            while (!isValidAnswer);

            return userAnswer;
        }
        
        /// <summary>
        /// Displaying if the user wants to add the question with options or he wants to quit
        /// </summary>
        public static void DisplayQuitOrPlaying()
        {
            Console.WriteLine($"Enter a multiple-choice question or '{Program.QUIT_GAME}' to quit");
            Console.WriteLine($"You can also play the Quiz you just created by pressing '{Program.PLAY_GAME}'");
        }

        /// <summary>
        /// Display Questions
        /// </summary>
        /// <param name="questions">After the user added or played the quiz, this method displays all questions with the options and correct answer</param>
        public static void DisplayQuestions(List<Question> questions)
        {
            Console.WriteLine("List of multiple-choice questions!");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{questions[i].QuestionText}");
                for (int j = 0; j < questions[i].AnswerOptions.Count; j++)
                {
                    Console.WriteLine($"{(AnswerOption)(j)} : {questions[i].AnswerOptions[j]}");
                }
                Console.WriteLine($"Correct answer : {questions[i].CorrectAnswer}");
            }
        }

        public static int DisplayWin(int score)
        {
            Console.WriteLine("That is correct!");
            Console.WriteLine($"Your score is {score}");
            return score;
        }

        public static void DisplayQuizComplete(int score, int totalQuestions)
        {
            Console.WriteLine($"Quiz Complete. You answered {score} correct questions out of {totalQuestions} questions\n");
        }

        public static void DisplaySerializationPath(string fullPath)
        {
            Console.WriteLine($"Serialized questions to the following path: {fullPath}");
        }

        public static void DisplaySuccessMessage()
        {
            Console.WriteLine("\nQuestion added\n"); // Display a success message
        }

        public static void DisplayIncorrectAnswer(AnswerOption correctAnswer)
        {
            Console.WriteLine($"Incorrect. The correct answer was {correctAnswer}");
        }

        public static void DisplayStartQuiz()
        {
            Console.WriteLine("Let's start the Quiz! \n");
        }

        public static void DisplayQuestionsWithOptions(Question question)
        {
            Console.WriteLine($"\n{question.QuestionText}");
            foreach (AnswerOption answerOption in Enum.GetValues(typeof(AnswerOption)))
            {
                string optionLabel = Enum.GetName(typeof(AnswerOption), answerOption);
                Console.WriteLine($"{optionLabel} : {question.AnswerOptions[(int)answerOption]}");
            }
        }
    }
}