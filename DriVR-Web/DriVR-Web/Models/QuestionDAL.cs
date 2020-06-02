using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DriVR_Web.Models
{
    public class QuestionDAL
    {
        private string connectionString = @"Data Source=(localdb)\LocalDBDrivr;Initial Catalog=DrivrDBLocal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // To get all questions
        public List<QuestionInfo> GetAllQuestions()
        {
            List<QuestionInfo> questionList = new List<QuestionInfo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllQuestion", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    QuestionInfo question = new QuestionInfo();

                    question.ID = Convert.ToInt32(dr["QuestionId"].ToString());
                    question.QuestionText = dr["QuestionText"].ToString();
                    question.AnswerOne = dr["AnswerOne"].ToString();
                    question.AnswerTwo = dr["AnswerTwo"].ToString();
                    question.AnswerThree = dr["AnswerThree"].ToString();

                    questionList.Add(question);
                }
            }

            return questionList;
        }

        // To insert question
        public void AddQuestion(QuestionInfo question)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                cmd.Parameters.AddWithValue("@AnswerOne", question.AnswerOne);
                cmd.Parameters.AddWithValue("@AnswerTwo", question.AnswerTwo);
                cmd.Parameters.AddWithValue("@AnswerThree", question.AnswerThree);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // To update question
        public void UpdateQuestion(QuestionInfo question)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QuestionId", question.ID);
                cmd.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                cmd.Parameters.AddWithValue("@AnswerOne", question.AnswerOne);
                cmd.Parameters.AddWithValue("@AnswerTwo", question.AnswerTwo);
                cmd.Parameters.AddWithValue("@AnswerThree", question.AnswerThree);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // To update question
        public void DeleteQuestion(int? questionId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QuestionId", questionId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Get question by Id
        public QuestionInfo GetQuestionById(int? questionId)
        {
            QuestionInfo question = new QuestionInfo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetQuestionById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    question.ID = Convert.ToInt32(dr["QuestionId"].ToString());
                    question.QuestionText = dr["QuestionText"].ToString();
                    question.AnswerOne = dr["AnswerOne"].ToString();
                    question.AnswerTwo = dr["AnswerTwo"].ToString();
                    question.AnswerThree = dr["AnswerThree"].ToString();
                }
                con.Close();
            }

            return question;
        }

    }
}
