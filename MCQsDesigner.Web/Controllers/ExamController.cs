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
    public class ExamController : Controller
    {
        private CategoryDAC _category;
        private DegreeProgramDAC _degree;
        private CourseDAC _course;
       
        public ExamController()
        {
            _category = new CategoryDAC();
            _degree = new DegreeProgramDAC();
            _course = new CourseDAC();
        }


        public ActionResult ManageExams()
        { 

            var viewModel = new ExamViewModel() {

                Categories = _category.GetAllCategories(),
                DegreePrograms = _degree.GetAll(),
                Courses = _course.getAllCourses()
                

            };
          

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddExam(ExamViewModel  viewModel)
        {
            if(ModelState.IsValid)
            {
                ExamDAC examDAC = new ExamDAC(new ApplicationDbContext());
                var exam = new Exam()
                {
                    Id = viewModel.Exam.Id,
                    ExamCode = viewModel.Exam.ExamCode,
                    ExamDate = viewModel.Exam.ExamDate,
                    Duration = viewModel.Exam.Duration,
                    StartingTime = viewModel.Exam.StartingTime,
                    CourseId = viewModel.Exam.Course.Id

                };

                examDAC.Insert(exam);


            }
            else
            {
                var model = new ExamViewModel()
                {

                    Categories = _category.GetAllCategories(),
                    DegreePrograms = _degree.GetAll(),
                    Courses = _course.getAllCourses()


                };
                return View("ManageExams", model);
            }


            return RedirectToAction("ManageExams");
        }

        [HttpGet]
        public ActionResult QuizList()
        {
            var viewModel = new ExamViewModel()
            {

                Categories = _category.GetAllCategories(),
                //DegreePrograms = _degree.GetAll(),
                //Courses = _course.getAllCourses()


            };


            return View(viewModel);
        }
        [HttpGet]
        public ActionResult AvailableExam( ExamViewModel viewModel)
        {
           

            return View();
        } 


        [HttpPost]
        public ActionResult EditExam(ExamViewModel examView)
        {
            return RedirectToAction("ManageExams");
        }

        public ActionResult AttemptExam(int id)
        {


            if (id> 0)
            {
                var examQuestionDAC = new ExamQuestionDAC();
                List<QuestionViewModel> questionViewModel;
                var listOfQuestion = examQuestionDAC.GetQuestionsByExamId(id);
                var exam = new ExamDAC(new ApplicationDbContext());

                if (listOfQuestion != null)
                {
                    questionViewModel = new List<QuestionViewModel>();

                    foreach (var model in listOfQuestion)
                    {
                        questionViewModel.Add(new QuestionViewModel()
                        {

                            Id = model.Id,
                            QuestionTitle = model.QuestionTitle,
                            Marks = model.Marks,
                            OptionA = model.OptionA,
                            OptionB = model.OptionB,
                            OptionC = model.OptionC,
                            OptionD = model.OptionD,
                            CorrectAnswer = model.CorrectAnswer,
                          

                        });
                    }
                    var examModel= exam.GetExamById(id);

                    ExamViewModel eViewModel = new ExamViewModel()
                    {
                        ExamCode = examModel.ExamCode,
                        Time =  examModel.Duration
                    };

                    ViewBag.ExamInfo = eViewModel;
                    return View(questionViewModel);

                }
                else
                {
                    return Content("No question !");
                }

            }
            else
            {
                return Content("Invalid Id");
            }
                

            
            
                

        }
       

       
    }
}