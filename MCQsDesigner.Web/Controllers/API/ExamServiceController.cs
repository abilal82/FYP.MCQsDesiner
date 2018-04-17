using MCQsDesigner.BOL;
using MCQsDesigner.DAL;
using MCQsDesigner.DAL.DAC;
using MCQsDesigner.Web.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MCQsDesigner.Web.Controllers.API
{
    public class ExamServiceController : ApiController
    {

        private ExamDAC _exam;
        private ApplicationDbContext _context;


        [HttpGet]
        public IHttpActionResult GetQuestionByExamId(int Id)
        {
            if(Id > 0)
            {
                using (_context = new ApplicationDbContext())
                {
                    var questionDto = _context.ExamQuestions.Include(x => x.Exam).Where(m => m.ExamID == Id).Select(m => new QuestionDTO()
                    {
                        Id = m.Id,
                        QuestionTitle = m.QuestionTitle,
                        Marks = m.Marks,
                        OptionA = m.OptionA,
                        OptionB = m.OptionB,
                        OptionC = m.OptionC,
                        OptionD = m.OptionD,
                        CorrectAnswer = m.CorrectAnswer,
                        ExamID = m.ExamID,
                        ExamCode =m.Exam.ExamCode
                    }).ToList();



                    return Ok(questionDto);
                }
            }
            else
            {
                return BadRequest();
            }

          
        }

        [System.Web.Http.HttpGet]
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


        [HttpGet]
        public IHttpActionResult GetExamById(int Id)
        {
     
            Exam examModel = null;
            using (_context = new ApplicationDbContext())
            {
                if (Id > 0)
                {
                    _exam = new ExamDAC(_context);
                    examModel = _exam.GetExamById(Id);

                }
                else
                {
                    return NotFound();
                }
            }
            ExamDTO ExamDto = new ExamDTO()
            {
                Id = examModel.Id,
                ExamCode = examModel.ExamCode,
                ExamDate = examModel.ExamDate.Value.ToString("MMM dd, yyyy"),
                Duration = examModel.Duration,
                CourseId = examModel.CourseId,
                Category = examModel.Course.DegreeProgram.Category.Title,
                Degree = examModel.Course.DegreeProgram.ProgramTitle,
                Course = examModel.Course.CourseTitle
              

            };
            return Ok(ExamDto);
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

        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int id)
        {
            if(id >0)
            {
                ExamQuestionDAC questionDAC = new ExamQuestionDAC();
                questionDAC.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        public IHttpActionResult GetExamListByCourseId(int id)
        {

            using (_context = new ApplicationDbContext())
            {
                _exam = new ExamDAC(_context);
                try
                {
                    var resultList = _exam.GetListOfExamsByCourseId(id)
                                   .Select(exam => new ExamDTO()
                                   {
                                       Id = exam.Id,
                                       ExamCode = exam.ExamCode,
                                       ExamDate = exam.ExamDate.Value.ToString("MMM dd, yyyy"),
                                       Duration = exam.Duration

                                   }).ToList();
                    if (resultList.Count != 0)
                    {
                        return Ok(resultList);
                    }
                    else
                    {
                        return NotFound();


                    }
                }
                catch
                {
                    return InternalServerError();
                }
            }

           


        }

    }
}