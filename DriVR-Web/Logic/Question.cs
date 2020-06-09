using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DriVR_Web.Data;

namespace DriVR_Web.Logic
{
    public class Question
    {
        public int ID { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public string AnswerOne { get; set; }
        [Required]
        public string AnswerTwo { get; set; }
        [Required]
        public string AnswerThree { get; set; }

        public Question(QuestionDTO questionDTO)
        {
            ID = questionDTO.ID;
            QuestionText = questionDTO.QuestionText;
            AnswerOne = questionDTO.AnswerOne;
            AnswerTwo = questionDTO.AnswerTwo;
            AnswerThree = questionDTO.AnswerThree;
        }
    }
}
