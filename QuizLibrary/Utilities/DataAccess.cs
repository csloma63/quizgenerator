using System.IO;
using System.Configuration;
using System.Threading.Tasks;

namespace QuizLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        public string[] LoadFile()
        {
            return File.ReadAllLines(ConfigurationManager.AppSettings["ImportQuiz"]);
        }
    }
}
