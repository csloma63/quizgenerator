using QuizLibrary;

namespace QuizGenerator
{
    public class Application : IApplication
    {
        IQuiz _quiz;

        public Application(IQuiz quiz)
        {
            _quiz = quiz;
        }

        public void Run()
        {
            _quiz.Run();
        }
    }
}
