using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.DAL.DAC
{
    public class ExamDAC
    {
       private ApplicationDbContext _context;
        public ExamDAC(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Exam> GetAll()
        {
            return _context.Exams.Include(x => x.Course).ToList();
        }
        public List<Exam> GetExamAndCourses()
        {
            return _context.Exams
                            .Include(x => x.Course)
                            .Include(x=>x.Course.DegreeProgram)
                            .ToList();
        }
        public void Insert(Exam exam)
        {

            using (_context)
            {
                if(exam.Id == 0)
                {
                 _context.Exams.Add(exam);

                }
                else
                {
                    var examInDB =   _context.Exams.Include(x => x.Course)
                                   .Include(x => x.Course.DegreeProgram)
                                   .SingleOrDefault(x => x.Id == exam.Id);

                    examInDB.ExamCode = exam.ExamCode;
                    examInDB.ExamDate = exam.ExamDate;
                    examInDB.Duration = exam.Duration;
                    examInDB.CourseId = exam.CourseId;

                }
                _context.SaveChanges();

            }
        }
        public void Delete(int Id)
        {
            using (_context)
            {
                var model = _context.Exams.SingleOrDefault(x => x.Id==Id);
               
                    _context.Exams.Remove(model);
                    _context.SaveChanges();
               
                

              
            }
            
        }

        public Exam GetExamById(int id)
        {

            return _context.Exams.Include(x => x.Course)
                                .Include(x => x.Course.DegreeProgram)
                                .Include(x=>x.Course.DegreeProgram.Category)
                                .SingleOrDefault(x => x.Id == id);


        }
      

    }
}
