using QuizLibrary.Models;
using System.Collections.Generic;

namespace QuizLibrary
{
    public interface IQuiz
    {
        void DisplayScore();
        void EndQuiz();
        Question GetNextQuestion();
        void ImportQuizData();
        void ProcessInput();
        void Run();
        void TakeQuiz();
    }
}
