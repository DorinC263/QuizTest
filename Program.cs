using System.Xml.Serialization;

namespace QuizTest
{
    internal class Program
    {
        const string QUIT_GAME = "Q";
        const string PLAY_GAME = "P";
        static void Main(string[] args)
        {
            UIMethods.DisplayWelcomeMessage();

            List<Question> questions = new List<Question>();

            while (true)
            {
                UIMethods.DisplayQuitOrPlaying();
                string questionText = UIMethods.PromptForNonEmptyString("Question : ");

                //If the user chooses Q it quits the program
                if (questionText.ToUpper() == QUIT_GAME)
                {
                    break;
                }
                //if the user chooses P it goes to play the added questions(either from memory or from XML file)
                else if (questionText.ToUpper() == PLAY_GAME)
                {
                    Play.PlayQuiz(questions);
                    continue;
                }

                string optionA = UIMethods.PromptForNonEmptyString("Option A: ");
                string optionB = UIMethods.PromptForNonEmptyString("Option B: ");
                string optionC = UIMethods.PromptForNonEmptyString("Option C: ");

                UIMethods.PromptCorrectAnswer();
                char correctAnswer = char.ToUpper(Console.ReadKey().KeyChar);

                // After he added the question and options, if he doesn`t choose the correct ABC as the correct answer, the question won`t be added at all.
                if (correctAnswer != 'A' && correctAnswer != 'B' && correctAnswer != 'C')
                {
                    Console.WriteLine("\nInvalid Option.The question won`t be added to the list");
                }
                else
                {
                    Question newQuestion = new Question
                    {
                        QuestionText = questionText,
                        OptionA = optionA,
                        OptionB = optionB,
                        OptionC = optionC,
                        CorrectAnswer = correctAnswer
                    };

                    questions.Add(newQuestion);
                    Console.WriteLine("\nQuestion added\n");

                    string relativePath = "Questions.xml";
                    FileOperations.SerializeQuestions(questions,relativePath);
                }
            }
            UIMethods.DisplayQuestions(questions);
        }
    }
}