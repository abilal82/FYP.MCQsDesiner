using MCQsDesigner.BOL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Controllers
{
    public class CourseController : Controller
    {
        private CourseDAC _courseDac;
        private DegreeProgramDAC _degree;
        private CategoryDAC _category;

        public CourseController()
        {
            _courseDac = new CourseDAC();
            _degree = new DegreeProgramDAC();
            _category = new CategoryDAC();
        }

        protected override void Dispose(bool disposing)
        {
            _courseDac.Dispose();
            _courseDac.Dispose();
            _degree.Dispose();
            base.Dispose(disposing);
        }
        // GET: Course
        public ActionResult ManageCourses()
        {

            var model = new CoursesViewModel()
            {
                Categories = _category.GetAllCategories(),
                DegreePrograms = _degree.GetAll()

            };
            return View(model);
        }

        
        public ActionResult AddCourse(CoursesViewModel model)
        {
            var course = new Course()
            {
                CourseTitle = model.Courses.CourseTitle,
                CourseCode = model.Courses.CourseCode,
                CreditHour = model.Courses.CreditHour,
                DegreeID = model.Courses.DegreeProgram.Id
            };

            _courseDac.AddCourse(course);
            return RedirectToAction("ManageCourses");
        }

       
    }
}