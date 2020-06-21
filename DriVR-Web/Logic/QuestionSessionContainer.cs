using System;
using System.Collections.Generic;
using System.Text;
using DriVR_Web.Data;
using DriVR_Web.Interface;

namespace DriVR_Web.Logic
{
    public class QuestionSessionContainer
    {
        iQuestionSessionContainerDAL iQuestionSessionContainerDal = new QuestionSessionDAL();
        iQuestionSessionDAL iQuestionSessionDal = new QuestionSessionDAL();

        public QuestionSessionContainer() { } // Default constructor

        public QuestionSessionContainer(iQuestionSessionContainerDAL iquestionContainerDal, iQuestionSessionDAL iquestionDAL) { }


        public List<QuestionSession> GetAllQuestionSessions()
        {
            List<QuestionSession> result = new List<QuestionSession>();
            List<QuestionSessionDTO> dtoQuestionSessions = new List<QuestionSessionDTO>(iQuestionSessionContainerDal.GetAllQuestionSessions());

            foreach (QuestionSessionDTO questionSessionDto in dtoQuestionSessions)
            {
                QuestionSession question = new QuestionSession(questionSessionDto);
                result.Add(question);
            }

            return result;
        }

        public QuestionSession GetQuestionSessionById(int? questionSessionId)
        {
            QuestionSession result = new QuestionSession(iQuestionSessionContainerDal.GetQuestionSessionById(questionSessionId));
            return result;
        }

        public void AddQuestionSession(QuestionSession questionSession)
        {
            QuestionSessionDTO dto;
            dto.ID = questionSession.ID;
            dto.UserID = questionSession.UserID;
            dto.AmountCorrect = questionSession.AmountCorrect;
            dto.AmountWrong = questionSession.AmountWrong;
            dto.DateFinished = questionSession.DateFinished;
            iQuestionSessionDal.AddQuestionSession(dto);
        }
    }
}