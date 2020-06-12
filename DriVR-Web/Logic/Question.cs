using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DriVR_Web.Data;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Logic
{
    public class Question
    {
        iQuestionContainerDAL iQuestionContainerDal;
        iQuestionDAL iQuestionDal;

        public int ID { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string AnswerOne { get; set; }
        [Required]
        public string AnswerTwo { get; set; }
        [Required]
        public string AnswerThree { get; set; }

        public Question() { } // Default constructor

        public Question(QuestionDTO questionDTO)
        {
            ID = questionDTO.ID;
            QuestionText = questionDTO.QuestionText;
            AnswerOne = questionDTO.AnswerOne;
            AnswerTwo = questionDTO.AnswerTwo;
            AnswerThree = questionDTO.AnswerThree;
        }

        public void AddQuestion(Question question)
        {
            //question = new Question(question);
            //iQuestionDal.AddQuestion(question);
        }

        //public void Update(Question question)
        //{
        //    ID = question.ID;
        //    QuestionText = question.QuestionText;
        //    AnswerOne = question.AnswerOne;
        //    AnswerTwo = question.AnswerTwo;
        //    AnswerThree = question.AnswerThree;
        //    iQuestionDal.UpdateQuestion(this);
        //}
    }
}
