using System;
using System.Collections.Generic;
using System.Text;
using DriVR_Web.Data;

namespace DriVR_Web.Interface
{
    public interface iQuestionContainerDAL
    {
        public List<QuestionDTO> GetAllQuestions();
        public QuestionDTO GetQuestionById(int? questionId);
    }
}