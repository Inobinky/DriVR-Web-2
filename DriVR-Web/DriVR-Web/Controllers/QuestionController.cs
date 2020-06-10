using DriVR_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DriVR_Web.Data;
using DriVR_Web.Logic;
using DriVR_Web.Data.Interface;

namespace DriVR_Web.Controllers
{
    public class QuestionController : Controller
    {
        QuestionDAL questionDal = new QuestionDAL(); //TODO: TURN THEM ALL INTO INTERF
        iQuestionContainerDAL iQuestionContainerDal = new QuestionDAL();
        public QuestionDTO questionDTO;

        public IActionResult Overview()
        {
            List<QuestionDTO> questionList = iQuestionContainerDal.GetAllQuestions().ToList();
            return View(questionList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] QuestionDTO objQuestion)
        {
            if (ModelState.IsValid)
            {
                questionDal.AddQuestion(objQuestion);
                return RedirectToAction("Overview");
            }

            return View(objQuestion);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionDTO question = questionDal.GetQuestionById(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] QuestionDTO question)
        {
            if (id == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                questionDal.UpdateQuestion(question);
                return RedirectToAction("Overview");
            }
            return View(questionDal);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionDTO question = questionDal.GetQuestionById(id);
            return View(question);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionDTO question = questionDal.GetQuestionById(id);
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteQuestion(int? id)
        {
            questionDal.DeleteQuestion(id);
            return RedirectToAction("Overview");
        }
    }
}