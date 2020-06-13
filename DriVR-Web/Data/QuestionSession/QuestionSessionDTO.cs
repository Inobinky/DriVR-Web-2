using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DriVR_Web.Data
{
    public struct QuestionSessionDTO
    {
        public int ID;
        [Required]
        public int UserID;
        [Required]
        public int AmountCorrect;
        [Required]
        public int AmountWrong;
        [Required]
        public DateTime DateFinished;
    }
}