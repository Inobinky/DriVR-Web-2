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
        QuestionDAL QuestionDal = new QuestionDAL();
        QuestionContainer questionContainer = new QuestionContainer();
        iQuestionContainerDAL iQuestionContainerDal = new QuestionDAL();

        public IActionResult Overview()
        {
            List<Question> result = new List<Question>(questionContainer.GetAllQuestions());
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Question objQuestion)
        {
            if (ModelState.IsValid)
            {
                QuestionDTO dto;
                dto.ID = objQuestion.ID;
                dto.QuestionText = objQuestion.QuestionText;
                dto.AnswerOne = objQuestion.AnswerOne;
                dto.AnswerTwo = objQuestion.AnswerTwo;
                dto.AnswerThree = objQuestion.AnswerThree;
                QuestionDal.AddQuestion(dto);
                return RedirectToAction("Overview");
            }

            return View(objQuestion);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            Question question = questionContainer.GetQuestionById(id);
            if (question == null) { return NotFound(); }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] Question question)
        {
            if (id == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                questionContainer.UpdateQuestion(question);
                return RedirectToAction("Overview");
            }
            return View(QuestionDal);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) { return NotFound(); }
            Question question = new Question(iQuestionContainerDal.GetQuestionById(id));
            return View(question);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            Question question = questionContainer.GetQuestionById(id);
            return View(question);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteQuestion(int? id)
        {
            QuestionDal.DeleteQuestion(id);
            return RedirectToAction("Overview");
        }
    }
}