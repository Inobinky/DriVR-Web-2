using System;
using System.Collections.Generic;
using System.Text;
using DriVR_Web.Data;

namespace DriVR_Web.Logic
{
    public class QuestionContainer
    {
        public List<Question> GetAllQuestions()
        {
            QuestionDAL questionDAL = new QuestionDAL();
            List<Question> result = new List<Question>();

            foreach (QuestionDTO questionDto in questionDAL.GetAllQuestions())
            {
                Question question = new Question(questionDto);
                result.Add(question);
            }

            return result;
        }
    }
}
