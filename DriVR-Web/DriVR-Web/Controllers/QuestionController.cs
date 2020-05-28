using DriVR_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DriVR_Web.Controllers
{
    public class QuestionController : Controller
    {
        QuestionDAL questionDAL = new QuestionDAL();

        public IActionResult Index()
        {
            List<QuestionInfo> questionList = new List<QuestionInfo>();
            questionList = questionDAL.GetAllQuestions().ToList();
            return View(questionList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] QuestionInfo objQuestion)
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
            QuestionInfo question = questionDAL.GetQuestionById(id);
            if (question == null) { return NotFound(); }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] QuestionInfo question)
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
            QuestionInfo question = questionDAL.GetQuestionById(id);
            if (question == null) { return NotFound(); }
            return View(question);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            QuestionInfo question = questionDAL.GetQuestionById(id);
            if (question == null) { return NotFound(); }
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