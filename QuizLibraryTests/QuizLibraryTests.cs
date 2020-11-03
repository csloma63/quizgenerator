using QuizLibrary.Models;
using QuizLibrary.Utilities;
using Xunit;

namespace QuizLibrary.Tests
{
    public class QuizTests
    {
        [Fact]
        public void GetQuestionValue_ReturnsTrue()
        {
            Quiz quiz = new Quiz();
            bool expected = true;
            bool actual = quiz.GetQuestionValue("(1) The question?");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQuestionValue_ReturnsFalse()
        {
            Quiz quiz = new Quiz();
            bool expected = false;
            bool actual = quiz.GetQuestionValue("[1] The question?");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumericValue_ReturnsTrue()
        {
            Quiz quiz = new Quiz();
            bool expected = true;
            bool actual = quiz.GetNumericValue("2. The answer");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumericValue_ReturnsFalse()
        {
            Quiz quiz = new Quiz();
            bool expected = false;
            bool actual = quiz.GetNumericValue("3 The answer.");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2", true)]
        [InlineData("2.5", false)]
        [InlineData("101", true)]
        [InlineData("@ppl3", false)]
        public void GetCorrectValue_ReturnsTrue(string x, bool expected)
        {
            Quiz quiz = new Quiz();
            bool actual = quiz.GetCorrectValue(x);
            Assert.Equal(expected, actual);
        }

    }
}
