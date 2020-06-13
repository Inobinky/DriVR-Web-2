using System;
using System.Collections.Generic;
using System.Text;
using DriVR_Web.Data;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Logic
{
    public class QuestionSessionContainer
    {
        iQuestionSessionContainerDAL iQuestionSessionContainerDal = new QuestionSessionDAL();
        iQuestionSessionDAL iQuestionSessionDal = new QuestionSessionDAL();
        QuestionSessionDTO questionDTO;

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

        public void AddQuestionSession(QuestionSession questionDTO)
        {
            QuestionSessionDTO dto;
            dto.ID = questionDTO.ID;
            dto.UserID = questionDTO.UserID;
            dto.AmountCorrect = questionDTO.AmountCorrect;
            dto.AmountWrong = questionDTO.AmountWrong;
            dto.DateFinished = questionDTO.DateFinished;
            iQuestionSessionDal.AddQuestionSession(dto);
        }

        public void UpdateQuestionSession(QuestionSession question)
        {
            QuestionSessionDTO dto;
            dto.ID = questionDTO.ID;
            dto.UserID = questionDTO.UserID;
            dto.AmountCorrect = questionDTO.AmountCorrect;
            dto.AmountWrong = questionDTO.AmountWrong;
            dto.DateFinished = questionDTO.DateFinished;
            iQuestionSessionDal.UpdateQuestionSession(questionDTO);
        }
    }
}