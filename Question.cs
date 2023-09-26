namespace QuizTest
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> AnswerOptions { get; set; }
        public AnswerOption CorrectAnswer{ get;set; }
    }

    public enum AnswerOption
    {
        A,
        B,
        C,
        D
    }
}
