namespace QuizApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuizService service = new QuizService();
            service.StartQuiz();
        }
    }
}
