namespace QuizTest
{
    public class Question
    {
        private string questionText;
        private List<string> answerOptions;
        private AnswerOption correctAnswer;

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }

        public List<string> AnswerOptions
        {
            get { return answerOptions; }
            set { answerOptions = value; }
        }

        public AnswerOption CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        public Question()
        {
        }
    }

    public enum AnswerOption
    {
        A,
        B,
        C
    }
}
