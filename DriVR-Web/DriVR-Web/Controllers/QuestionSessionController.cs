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
            return View();
        }
    }
}