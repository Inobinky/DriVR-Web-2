using System;
using System.Collections.Generic;
using System.Text;
using DriVR_Web.Data;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Logic
{
    public class QuestionContainer
    {
        iQuestionContainerDAL iQuestionContainerDal;
        iQuestionDAL iQuestionDal;
        QuestionDTO questionDTO;

        public List<Question> GetAllQuestions()
        {
            List<Question> result = new List<Question>();

            foreach (QuestionDTO questionDto in iQuestionContainerDal.GetAllQuestions())
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
    }
}
