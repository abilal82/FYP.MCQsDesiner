
using MCQsDesigner.BOL;
using MCQsDesigner.DAL.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MCQsDesigner.Web.Controllers.API
{
    public class CourseServiceController : ApiController
    {

        private CategoryDAC _category;
        private DegreeProgramDAC _degree;
        private CourseDAC _course;

        public CourseServiceController()
        {
            _category = new CategoryDAC();
            _degree = new DegreeProgramDAC();
            _course = new CourseDAC();
        }

        [HttpGet]
        //returning Degree programs list for dropdown list 
        public IHttpActionResult GetProgramsList(int Id)
        {
            var model = _degree.GetAll().Where(x => x.CategoryId == Id).Select(x => new { x.Id, x.ProgramTitle }).ToList();
            if (model == null)
                return NotFound();
            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetCourseList(int Id)
        {
            var model = _course.getAllCourses()
                               .Where(x => x.DegreeID == Id)
                               .Select(x => new { x.Id, x.CourseTitle })
                               .ToList();
            if(model.Count!=0)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IHttpActionResult GetCourseDetail()
        {

            var model = _course.getAllCourses()
                        .Select(x => new {
                            x.Id,
                            x.CourseTitle,
                            x.CourseCode,
                            x.CreditHour,
                            DegreeProgram = new {
                                x.DegreeProgram.ProgramTitle

                                
                            }
                        });

            return Ok(model);
        }

        public IHttpActionResult DeleteCourse(int Id)
        {
            _course.DeleteCourse(Id);
            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            _category.Dispose();
            _degree.Dispose();
            _course.Dispose();
            base.Dispose(disposing);
        }
    }
}
