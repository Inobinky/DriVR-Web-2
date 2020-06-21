using Microsoft.VisualStudio.TestTools.UnitTesting;
using DriVR_Web.Logic;
using Moq;
using DriVR_Web.Data;
using DriVR_Web.Interface;

namespace Tests
{
    [TestClass]
    public class QuestionTests
    {
        private Mock<iQuestionContainerDAL> questionContainerDALMock;
        private Mock<iQuestionDAL> questionDALMock;

        [TestInitialize]
        public void Initialize()
        {
            questionContainerDALMock = new Mock<iQuestionContainerDAL>();
            questionDALMock = new Mock<iQuestionDAL>();
        }

        [TestMethod]
        public void VerifyInitializingQuestion()
        {
            // Arrange
            QuestionDTO questionDTO = new QuestionDTO();
            questionDTO.ID = 6;
            questionDTO.QuestionText = "QTEXT";
            questionDTO.AnswerOne = "ANSW1";
            questionDTO.AnswerTwo = "Answ2";
            questionDTO.AnswerThree = "ans3";
            questionDTO.ImageUrl = "URL";
            questionDTO.CorrectAnswer = 3;
            questionDTO.ChosenAnswer = 1;

            // Act
            Question question = new Question(questionDTO);

            // Assert
            Assert.IsNotNull(questionDTO);
            Assert.IsNotNull(question);
            Assert.AreEqual(question.ID, questionDTO.ID);
            Assert.AreEqual(question.QuestionText, questionDTO.QuestionText);
            Assert.AreEqual(question.AnswerOne, questionDTO.AnswerOne);
            Assert.AreEqual(question.AnswerOne, questionDTO.AnswerOne);
            Assert.AreEqual(question.AnswerTwo, questionDTO.AnswerTwo);
            Assert.AreEqual(question.AnswerThree, questionDTO.AnswerThree);
            Assert.AreEqual(question.ImageUrl, questionDTO.ImageUrl);
            Assert.AreEqual(question.CorrectAnswer, questionDTO.CorrectAnswer);
            Assert.AreEqual(question.ChosenAnswer, questionDTO.ChosenAnswer);
        }
    }
}