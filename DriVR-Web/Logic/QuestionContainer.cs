using System;
using System.Collections.Generic;
using System.Text;
using DriVR_Web.Data;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Logic
{
    public class QuestionContainer
    {
        iQuestionContainerDAL iQuestionContainerDal = new QuestionDAL();
        iQuestionDAL iQuestionDal = new QuestionDAL();
        QuestionDTO questionDTO;

        public List<Question> GetAllQuestions()
        {
            List<Question> result = new List<Question>();
            List<QuestionDTO> dtoQuestions = new List<QuestionDTO>(iQuestionContainerDal.GetAllQuestions());

            foreach (QuestionDTO questionDto in dtoQuestions)
            {
                Question question = new Question(questionDto);
                result.Add(question);
            }

            return result;
        }

        public Question GetQuestionById(int? questionId)
        {
            Question result = new Question(iQuestionContainerDal.GetQuestionById(questionId));
            return result;
        }

        public void AddQuestion(Question questionDTO)
        {
            QuestionDTO dto;
            dto.ID = questionDTO.ID;
            dto.QuestionText = questionDTO.QuestionText;
            dto.AnswerOne = questionDTO.AnswerOne;
            dto.AnswerTwo = questionDTO.AnswerTwo;
            dto.AnswerThree = questionDTO.AnswerThree;
            dto.CorrectAnswer = questionDTO.CorrectAnswer;
            dto.ImageUrl = questionDTO.ImageUrl;
            iQuestionDal.AddQuestion(dto);
        }

        public void UpdateQuestion(Question question)
        {
            QuestionDTO questionDTO;
            questionDTO.ID = question.ID;
            questionDTO.QuestionText = question.QuestionText;
            questionDTO.AnswerOne = question.AnswerOne;
            questionDTO.AnswerTwo = question.AnswerTwo;
            questionDTO.AnswerThree = question.AnswerThree;
            questionDTO.CorrectAnswer = question.CorrectAnswer;
            questionDTO.ImageUrl = question.ImageUrl;
            iQuestionDal.UpdateQuestion(questionDTO);
        }
    }
}