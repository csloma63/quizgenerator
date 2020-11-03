using QuizLibrary.Models;
using QuizLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace QuizLibrary
{
    public class Quiz : IQuiz
    {
        private List<Question> questions = new List<Question>();
        private string[] input;
        private int score = 0;
        private bool isDone = false;

        IDataAccess _dataAccess;

        public Quiz(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void Run()
        {
            ImportQuizData();
            ProcessInput();
            TakeQuiz();
            DisplayScore();
            EndQuiz();
        }

        public string[] ImportQuizData()
        {
            try 
            { 
                input = _dataAccess.LoadFile();
                return input;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(Messages.ErrorMessage(ex.Message));
                isDone = true;
                EndQuiz();
                //Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.ErrorMessage(e.Message));
                isDone = true;
                EndQuiz();
                //Environment.Exit(0);
            }

            return null;
        }

        int correct;

        public void ProcessInput()
        {
            Dictionary<int, string> answ = new Dictionary<int, string>();
            Question newQuestion = new Question();

            for (int i = 0; i < input.Length; i++)
            {
                var input_V = input[i];
                if (GetQuestionValue(input_V))
                    newQuestion.Query = input[i];
                if (GetNumericValue(input_V))
                {
                    string[] spliter = input[i].Split('.');
                    answ.Add(Int32.Parse(spliter[0]), spliter[1]);
                }
                if (GetCorrectValue(input_V))
                {
                    newQuestion.Answers = answ;
                    newQuestion.Correct = correct;
                    questions.Add(newQuestion);
                    newQuestion = new Question();
                    answ = new Dictionary<int, string>();
                }
            }
        }

        public bool GetQuestionValue(string input_V)
        {
            if (input_V.Substring(0, 1) == "(") return true;
            else return false;
        }
        public bool GetNumericValue(string input_V)
        {
            if (input_V.Length > 1 && input_V.Substring(0, 2).Contains(".")) return true;
            else return false;
        }
        public bool GetCorrectValue(string input_V)
        {
            if (int.TryParse(input_V, out correct)) return true;
            else return false;
        }

        public Question GetNextQuestion()
        {
            int next = 0;
            Question next_Q = questions[next];
            if (questions.Count > 0) questions.RemoveAt(next);
            if (questions.Count == 0) isDone = true;
            next++;
            return next_Q;
        }

        public void TakeQuiz()
        {
            Console.WriteLine(Messages.Welcome() + Environment.NewLine);
            while (isDone == false)
            {
                Question nextQuestion = GetNextQuestion();
                Console.WriteLine(nextQuestion.ToString());

                int input_sa;
                var selectedAnswer = Console.ReadLine();
                while (!Int32.TryParse(selectedAnswer, out input_sa) || !nextQuestion.Answers.ContainsKey(input_sa))
                {
                    Console.WriteLine(Messages.NotValid(selectedAnswer));
                    selectedAnswer = Console.ReadLine();
                }
                if (input_sa == nextQuestion.Correct)
                {
                    score++;
                    Console.WriteLine(Messages.Correct() + Environment.NewLine);
                }
                else
                {
                    var correctAnswer = nextQuestion.Answers[nextQuestion.Correct];
                    Console.WriteLine(Messages.NotCorrect(correctAnswer.ToString()) + Environment.NewLine);
                }
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine(Messages.Score(score));
        }

        public void EndQuiz()
        {
            Console.WriteLine(Messages.EndQuiz());
        }
    }
}
