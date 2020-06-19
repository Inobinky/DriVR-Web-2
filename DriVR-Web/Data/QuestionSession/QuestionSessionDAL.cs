﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Data 
{
    public class QuestionSessionDAL : iQuestionSessionDAL, iQuestionSessionContainerDAL
    {
        private string connectionString = @"Data Source=(localdb)\LocalDBDrivr;Initial Catalog=DrivrDBLocal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // To get all questions
        public List<QuestionSessionDTO> GetAllQuestionSessions()
        {
            List<QuestionSessionDTO> questionList = new List<QuestionSessionDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllQuestionSessions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    QuestionSessionDTO questionSession = new QuestionSessionDTO();

                    questionSession.ID = Convert.ToInt32(dr["ID"].ToString());
                    questionSession.UserID = Convert.ToInt32(dr["UserId"].ToString());
                    questionSession.AmountCorrect = Convert.ToInt32(dr["AmountCorrect"].ToString());
                    questionSession.AmountWrong = Convert.ToInt32(dr["AmountWrong"].ToString());
                    questionSession.DateFinished = Convert.ToDateTime(dr["DateFinished"]);

                    questionList.Add(questionSession);
                }
            }

            return questionList;
        }

        // To insert questionSession
        public void AddQuestionSession(QuestionSessionDTO questionSession)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", questionSession.UserID);
                cmd.Parameters.AddWithValue("@AmountCorrect", questionSession.AmountCorrect);
                cmd.Parameters.AddWithValue("@AmountWrong", questionSession.AmountWrong);
                cmd.Parameters.AddWithValue("@DateFinished", questionSession.DateFinished);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // To update questionSession
        public void UpdateQuestionSession(QuestionSessionDTO questionSession)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@QuestionId", questionSession.ID);
                cmd.Parameters.AddWithValue("@UserId", questionSession.UserID);
                cmd.Parameters.AddWithValue("@AmountCorrect", questionSession.AmountCorrect);
                cmd.Parameters.AddWithValue("@AmountWrong", questionSession.AmountWrong);
                cmd.Parameters.AddWithValue("@DateFinished", questionSession.DateFinished);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // To update questionSession
        public void DeleteQuestionSession(int? questionId)
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

        // Get questionSession by Id
        public QuestionSessionDTO GetQuestionSessionById(int? questionId)
        {
            QuestionSessionDTO questionSession = new QuestionSessionDTO();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetQuestionById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    questionSession.ID = Convert.ToInt32(dr["QuestionId"].ToString());
                    questionSession.UserID = Convert.ToInt32(dr["UserId"].ToString());
                    questionSession.AmountCorrect = Convert.ToInt32(dr["AmountCorrect"].ToString());
                    questionSession.AmountWrong = Convert.ToInt32(dr["AmountWrong"].ToString());
                    questionSession.DateFinished = Convert.ToDateTime(dr["DateFinished"]);
                }
                con.Close();
            }

            return questionSession;
        }

    }
}
