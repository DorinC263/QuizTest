namespace QuizTest
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public char CorrectAnswer { get; set; }

        /// <summary>
        /// A parameterless constructor for XML Serializer
        /// </summary>
        public Question()
        {
        }

        public Question(string questionText, string answerOptionA, string answerOptionB,string answerOptionC,char correctAnswer)
        {
            QuestionText = questionText;
            OptionA = answerOptionA;
            OptionB = answerOptionB;
            OptionC = answerOptionC;
            CorrectAnswer = correctAnswer;
        }
    }
}
