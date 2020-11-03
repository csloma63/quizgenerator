using Moq;
using QuizLibrary.Utilities;
using System;
using System.IO;
using Xunit;

namespace QuizLibrary.Tests
{
    public class QuizTests
    {
        private readonly Mock<IDataAccess> mockDataAccess;
        private readonly Quiz quiz;

        public QuizTests() 
        {
            mockDataAccess = new Mock<IDataAccess>();
            quiz = new Quiz(mockDataAccess.Object);
        }

        [Fact]
        public void ImportQuizData_Works()
        {
            mockDataAccess.Setup(m => m.LoadFile()).Returns(GetSampleArray());
            var expected = GetSampleArray();
            var actual = quiz.ImportQuizData();
            Assert.Equal(expected.Length, actual.Length);
        }

        [Fact]
        public void ImportQuizData_FNF_Exception()
        {
            mockDataAccess.Setup(m => m.LoadFile()).Throws(new FileNotFoundException("File not found"));
            var expected = GetSampleArray();
            var actual = quiz.ImportQuizData();
            Assert.Null(actual);
        }

        [Fact]
        public void ImportQuizData_Exception()
        {
            mockDataAccess.Setup(m => m.LoadFile()).Throws(new Exception("File not found"));
            var expected = GetSampleArray();
            var actual = quiz.ImportQuizData();
            Assert.Null(actual);
        }

        [Fact]
        public void GetQuestionValue_ReturnsTrue()
        {
            bool expected = true;
            bool actual = quiz.GetQuestionValue("(1) The question?");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetQuestionValue_ReturnsFalse()
        {
            bool expected = false;
            bool actual = quiz.GetQuestionValue("[1] The question?");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumericValue_ReturnsTrue()
        {
            bool expected = true;
            bool actual = quiz.GetNumericValue("2. The answer");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumericValue_ReturnsFalse()
        {
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
            bool actual = quiz.GetCorrectValue(x);
            Assert.Equal(expected, actual);
        }
  

        public string[] GetSampleArray()
        {
            string[] output = new string[]
            {
                    "(1) Provides the ability to a class to have multiple implementations with the same name.","1. Polymorphism","2. Encapsulation","3. Inheritance","4. Abstraction","1",
                    "(2) Provides the ability to a class to have multiple implementations with the same name.","1. Polymorphism","2. Encapsulation","3. Inheritance","4. Abstraction","2"
            };
            return output;
        }

    }
}
