using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DriVR_Web.Data
{
    public struct QuestionDTO
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
    }
}