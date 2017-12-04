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

            var model = new ExamViewModel() {

                Categories = _category.GetAllCategories(),
                DegreePrograms = _degree.GetAll(),
                Courses = _course.getAllCourses()
                

            };
          

            return View(model);
        }

        [HttpPost]
        public ActionResult AddExam(ExamViewModel  model)
        {
            ExamDAC examDAC = new ExamDAC(new ApplicationDbContext());
            var exam = new Exam()
            {
                Id = model.Exam.Id,
                ExamCode = model.Exam.ExamCode,
                ExamDate = model.Exam.ExamDate,
                Duration = model.Exam.Duration,
                StartingTime = model.Exam.StartingTime,
                CourseId = model.Exam.Course.Id

            };

            examDAC.Insert(exam);




            return RedirectToAction("ManageExams");
        }

        [HttpPost]
        public ActionResult EditExam(ExamViewModel examView)
        {
            return RedirectToAction("ManageExams");
        }
       
    }
}