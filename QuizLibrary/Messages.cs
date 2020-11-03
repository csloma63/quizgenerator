using System.Collections.Generic;


namespace QuizLibrary
{
    public class Messages
    {
        public static string Welcome()
        {
            return "Please input the number that best answers the question.";
        }

        public static string Correct()
        {
            return "That is CORRECT!";
        }

        public static string NotCorrect(string answer)
        {
            return $"Sorry, the correct response was {answer}.";
        }

        public static string Score(int score)
        {
            return $"You answered {score} correctly.";
        }

        public static string NotValid(string input)
        {
            return $"{input} is not a valid answer, try again.";
        }

        public static string EndQuiz()
        {
            return "Press enter to exit.";
        }

        public static string ErrorMessage(string message)
        {
            return $"Sorry, something went amiss: {message}";
        }
    }
}
