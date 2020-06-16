using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DriVR_Web.Data;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Logic
{
    public class QuestionSession
    {
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int AmountCorrect { get; set; }
        [Required]
        public int AmountWrong { get; set; }
        [Required]
        public DateTime DateFinished { get; set; }

        public QuestionSession() { } // Default constructor

        public QuestionSession(QuestionSessionDTO questionSessionDTO)
        {
            ID = questionSessionDTO.ID;
            UserID = questionSessionDTO.UserID;
            AmountCorrect = questionSessionDTO.AmountCorrect;
            AmountWrong = questionSessionDTO.AmountWrong;
            DateFinished = questionSessionDTO.DateFinished;
        }
    }
}
