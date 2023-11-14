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
        private ExamDAC _exam;
       
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
            if(!ModelState.IsValid)
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
                             ExamID = id

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

        [HttpPost]
        public ActionResult SubmitExam(List<QuestionViewModel> listOfquestionViewModel)
        {
            int _totalNoOFQuestion = 0;
            int _noOfQuestionAttempt = 0;
            int _marksObtained = 0;
            int _totalMarks = 0;
            int _noOfNotAttempt = 0;
            decimal _percentage = 0;
            ViewBag.PassingPercentage = 50.0;
            var _examId = listOfquestionViewModel.Select(x=>x.ExamID);
          

            foreach( var questions in listOfquestionViewModel)
            {

                _totalNoOFQuestion++;
                _totalMarks = _totalMarks + questions.Marks;

                if (questions.CorrectAnswer.Equals(questions.SelectedAnswer,StringComparison.InvariantCultureIgnoreCase))
                {
                    _marksObtained = _marksObtained + questions.Marks;
                    _noOfQuestionAttempt++;

                }
                else if(questions.SelectedAnswer == null || questions.SelectedAnswer =="")
                {
                    _noOfNotAttempt++;
                }


            }

            _percentage = (decimal)(_marksObtained  * 100) / _totalMarks;

            _exam = new ExamDAC(new ApplicationDbContext());

           var ExamEntityGraph = _exam.GetExamToProgramCategoryGraph(_examId.First());


            ResultViewModel resultViewModel = new ResultViewModel()
            {
                TotalMarks = _totalMarks,
                NoOfQuestionAttempt = _noOfQuestionAttempt,
                MarksObtained = _marksObtained,
                NoOfNotAttempt = _noOfNotAttempt,
                TotalNoOFQuestion = _totalNoOFQuestion,
                NoOfNotAttemptedQuestion = _noOfNotAttempt,
                Percentage = _percentage,
                Category = ExamEntityGraph.Course.DegreeProgram.Category.Title,
                Degree = ExamEntityGraph.Course.DegreeProgram.ProgramTitle,
                CourseCode = ExamEntityGraph.Course.CourseCode,
                ExamCode = ExamEntityGraph.ExamCode,
                ExamDuration = ExamEntityGraph.Duration



            };

            return View("QuizResult",resultViewModel);
        }
       
    }
}