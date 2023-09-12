namespace QuizTest
{
    public class Question
    {
        public string QuestionText { get; }
        public string OptionA { get; }
        public string OptionB { get; }
        public string OptionC { get; }
        public char CorrectAnswer { get; }

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
