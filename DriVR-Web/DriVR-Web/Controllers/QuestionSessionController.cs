using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriVR_Web.Logic;
using Microsoft.AspNetCore.Mvc;

namespace DriVR_Web.Controllers
{
    public class QuestionSessionController : Controller
    {
        QuestionContainer questionContainer = new QuestionContainer();

        public IActionResult QuestionSessionStart()
        {
            List<Question> result = new List<Question>(questionContainer.GetAllQuestions());
            return View(result);
        }
    }
}