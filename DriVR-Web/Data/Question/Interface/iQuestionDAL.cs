using System;
using System.Collections.Generic;
using System.Text;

namespace DriVR_Web.Data.Interface
{
    public interface iQuestionDAL
    {
        public void AddQuestion(QuestionDTO question);
        public void UpdateQuestion(QuestionDTO question);
        public void AnswerQuestion(QuestionDTO question);
        public void DeleteQuestion(int? questionId);
    }
}