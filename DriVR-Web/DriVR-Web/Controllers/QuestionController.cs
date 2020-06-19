using DriVR_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DriVR_Web.Data;
using DriVR_Web.Logic;
using DriVR_Web.Interface;
using System;

namespace DriVR_Web.Controllers
{
    public class QuestionController : Controller
    {
        QuestionDAL QuestionDal = new QuestionDAL();
        QuestionContainer questionContainer = new QuestionContainer();
        QuestionSessionContainer questionSessionContainer = new QuestionSessionContainer();

        iQuestionContainerDAL iQuestionContainerDal = new QuestionDAL();
        iQuestionSessionContainerDAL iQuestionSessionContainerDal = new QuestionSessionDAL();

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
                questionContainer.AddQuestion(objQuestion);
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

        public IActionResult AnswerCurrentQuestion(Question question)
        {
            int questionIndex = questionContainer.GetAllQuestions().FindIndex(a => a.ID == question.ID);
            int nextQuestionIndex = questionIndex + 1;
            List<Question> questionList = new List<Question>(questionContainer.GetAllQuestions());

            if (nextQuestionIndex > (questionList.Count - 1))
            {
                QuestionSession questionSession = new QuestionSession();
                questionSession.DateFinished = DateTime.Now;
                questionSessionContainer.AddQuestionSession(questionSession);
                return RedirectToAction("Overview");
            }
            else
            {
                Question nextQuestion = questionList.ElementAt(nextQuestionIndex);
                questionContainer.AnswerQuestion(question);
                return RedirectToAction("AnswerQuestion", new { id = nextQuestion.ID });
            }
        }

        [HttpGet]
        public IActionResult AnswerQuestion(int? id)
        {
            if (id == null) { return NotFound(); }
            Question question = questionContainer.GetQuestionById(id);
            int questionIndex = questionContainer.GetAllQuestions().FindIndex(a => a.ID == question.ID);

            if (questionIndex == -1)
            {
                return RedirectToAction("Overview");
            }
            return View(question);
        }

        public IActionResult QuestionSessionStart()
        {
            return View();
        }

        public IActionResult QuestionSessionOverview()
        {
            ViewData["Questions"] = questionContainer.GetAllQuestions();
            ViewData["QuestionSessions"] = questionSessionContainer.GetAllQuestionSessions();
            return View("~/Views/QuestionSession/QuestionSessionOverview.cshtml");
        }

        public IActionResult AnsweredQuestionsOverview()
        {
            ViewData["Questions"] = questionContainer.GetAllQuestions();
            return View("~/Views/QuestionSession/AnsweredQuestionsOverview.cshtml");
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