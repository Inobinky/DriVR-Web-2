using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DriVR_Web.Data
{
    public struct QuestionDTO
    {
        public int ID;
        [Required]
        public string QuestionText;
        [Required]
        public string AnswerOne;
        [Required]
        public string AnswerTwo;
        [Required]
        public string AnswerThree;
        [Required]
        public int CorrectAnswer;
        [Required]
        public string ImageUrl;
        [Required]
        public int ChosenAnswer;
    }
}