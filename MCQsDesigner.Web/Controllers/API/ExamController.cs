using MCQsDesigner.BOL;
using MCQsDesigner.DAL;
using MCQsDesigner.DAL.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MCQsDesigner.Web.Controllers.API
{
    public class ExamController : ApiController
    {

        private ExamDAC _exam;
        private ApplicationDbContext _context;

        [HttpGet]
        public IHttpActionResult GetExamList()
        {
            using (_context = new ApplicationDbContext())
            {
                _exam = new ExamDAC(_context);
                var model = _exam.GetExamAndCourses()
                                .Select(x => new {
                                        x.Id,
                                        x.ExamCode,
                                        DateTime = x.ExamDate.Value.ToString("MMM dd, yyyy"),    
                                        x.Duration,       
                                    Course = new  {
                                        x.Course.CourseTitle
                                    },
                                    DegreeProgram = new  {
                                        x.Course.DegreeProgram.ProgramTitle
                                    }
 
                                });
               

                return Ok(model);
            }

               
        }

        [HttpDelete]
        public IHttpActionResult DeleteExam(int Id) {
            using (_context = new ApplicationDbContext())
            {
                _exam = new ExamDAC(_context);
                if(Id > 0)
                {
                    _exam.Delete(Id);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}