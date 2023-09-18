namespace QuizTest
{
    public class Question
    {
        private string questionText;
        private string optionA;
        private string optionB;
        private string optionC;
        private char correctAnswer;

        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; }
        }
        public string OptionA
        {
            get { return optionA; }
            set { optionA = value; }
        }
        public string OptionB
        {
            get { return optionB; }
            set { optionB = value; }
        }
        public string OptionC
        {
            get { return optionC; }
            set { optionC = value; }
        }
        public char CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }
    }
}
