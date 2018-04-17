using MCQsDesigner.BOL;
using MCQsDesigner.DAL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    public class QuestionController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Question
        public ActionResult ManageQuestions()
        {
            using (_context)
            {
                ExamDAC exam = new ExamDAC(_context);
                QuestionViewModel model = new QuestionViewModel()
                {
                    Exams = exam.GetAll()
                };
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult ViewExamQuestion()
        {
           
            return View("ViewExamQuestion");
        }


        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel model)
        {
            ExamQuestionDAC QDac = new ExamQuestionDAC();
            if(!ModelState.IsValid)
            {

                //ExamDAC exam = new ExamDAC(_context);
                //QuestionViewModel VModel = new QuestionViewModel()
                //{
                //    QuestionTitle = model.QuestionTitle,
                //    Marks = model.Marks,
                //    OptionA = model.OptionA,
                //    OptionB = model.OptionB,
                //    OptionC = model.OptionC,
                //    OptionD = model.OptionD,
                //    CorrectAnswer = model.CorrectAnswer,
                //    ExamID = model.ExamID,
                //    Exams = exam.GetAll()
                //};
                using (_context)
                {
                    ExamDAC exam = new ExamDAC(_context);
                    QuestionViewModel Qmodel = new QuestionViewModel()
                    {
                        Exams = exam.GetAll()
                    };
                 
                return View("ManageQuestions", Qmodel);
                }

               
             
            }
            else
            {

                try
                {
                    ExamQuestion question = new ExamQuestion()
                    {
                        QuestionTitle = model.QuestionTitle,
                        ExamID = model.ExamID,
                        Marks = model.Marks,
                        OptionA = model.OptionA,
                        OptionB = model.OptionB,
                        OptionC = model.OptionC,
                        OptionD = model.OptionD,
                        CorrectAnswer = model.CorrectAnswer
                    
                    };
                    QDac.CreateQuestion(question);
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
                return RedirectToAction("ManageQuestions");

            }
          
        }
    }
}