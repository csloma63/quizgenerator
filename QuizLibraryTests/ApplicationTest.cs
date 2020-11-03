using Moq;
using QuizGenerator;
using QuizLibrary;
using Xunit;

namespace QuizLibraryTests
{
    public class ApplicationTest
    {
        private readonly Mock<IQuiz> mockQuiz;
        private readonly Application application;

        public ApplicationTest()
        {
            mockQuiz = new Mock<IQuiz>();
            application = new Application(mockQuiz.Object);
        }

        [Fact]
        public void Run_Works()
        {
            mockQuiz.Setup(q => q.Run());
            application.Run();
        }




    }
}
