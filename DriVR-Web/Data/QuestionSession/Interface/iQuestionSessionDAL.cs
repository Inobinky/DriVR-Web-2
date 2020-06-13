using System;
using System.Collections.Generic;
using System.Text;

namespace DriVR_Web.Data.Interface
{
    public interface iQuestionSessionDAL
    {
        public void AddQuestionSession(QuestionSessionDTO questionSession);
        public void UpdateQuestionSession(QuestionSessionDTO questionSession);
        public void DeleteQuestionSession(int? questionSessionId);
    }
}