using DriVR_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DriVR_Web.Data;
using DriVR_Web.Logic;

namespace DriVR_Web.Controllers
{
    public class QuestionController : Controller
    {
        QuestionDAL questionDAL = new QuestionDAL();
        QuestionContainer questionContainer = new QuestionContainer();

        public IActionResult Overview()
        {
            List<Question> questionList = questionContainer.GetAllQuestions();
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
                questionDAL.AddQuestion(objQuestion);
                return RedirectToAction("Index");
            }

            return View(objQuestion);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionDTO question = questionDAL.GetQuestionById(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] QuestionDTO question)
        {
            if (id == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                questionDAL.UpdateQuestion(question);
                return RedirectToAction("Index");
            }
            return View(questionDAL);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionDTO question = questionDAL.GetQuestionById(id);
            return View(question);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionDTO question = questionDAL.GetQuestionById(id);
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteQuestion(int? id)
        {
            questionDAL.DeleteQuestion(id);
            return RedirectToAction("Index");
        }
    }
}