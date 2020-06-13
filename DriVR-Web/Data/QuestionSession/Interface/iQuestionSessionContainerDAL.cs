using System;
using System.Collections.Generic;
using System.Text;

namespace DriVR_Web.Data.Interface
{
    public interface iQuestionSessionContainerDAL
    {
        public List<QuestionSessionDTO> GetAllQuestionSessions();
        public QuestionSessionDTO GetQuestionSessionById(int? questionSessionId);
    }
}