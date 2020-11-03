using System;
using System.Collections.Generic;
using System.Text;

namespace QuizLibrary.Models
{
    public class Question
    {
        public string Query { get; set; }

        public Dictionary<int, string> Answers { get; set; }

        public int Correct { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Query + Environment.NewLine);
            foreach (KeyValuePair<int, string> item in Answers)
            {
                sb.Append($"{item.Key}. {item.Value}" + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
