using Microsoft.VisualStudio.TestTools.UnitTesting;
using DriVR_Web.Logic;
using Moq;
using DriVR_Web.Data;
using DriVR_Web.Interface;
using System;

namespace Tests
{
    [TestClass]
    public class QuestionSessionTests
    {
        private Mock<iQuestionSessionContainerDAL> questionSessionContainerDALMock;
        private Mock<iQuestionSessionDAL> questionSessionDALMock;

        [TestInitialize]
        public void Initialize()
        {
            questionSessionContainerDALMock = new Mock<iQuestionSessionContainerDAL>();
            questionSessionDALMock = new Mock<iQuestionSessionDAL>();
        }

        [TestMethod]
        public void VerifyInitializingQuestionSession()
        {
            // Arrange
            QuestionSessionDTO questionSessionDTO = new QuestionSessionDTO();
            questionSessionDTO.ID = 6;
            questionSessionDTO.AmountCorrect = 0;
            questionSessionDTO.AmountWrong = 0;
            questionSessionDTO.UserID = 2;
            questionSessionDTO.DateFinished = DateTime.Today;

            // Act
            QuestionSession questionSession = new QuestionSession(questionSessionDTO);

            // Assert
            Assert.IsNotNull(questionSessionDTO);
            Assert.IsNotNull(questionSession);
            Assert.AreEqual(questionSession.ID, questionSessionDTO.ID);
            Assert.AreEqual(questionSession.UserID, questionSessionDTO.UserID);
            Assert.AreEqual(questionSession.AmountCorrect, 0);
            Assert.AreEqual(questionSession.AmountWrong, 0);
            Assert.AreEqual(questionSession.DateFinished, questionSessionDTO.DateFinished);
        }
    }
}