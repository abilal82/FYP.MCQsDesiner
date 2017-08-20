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
                _context.Exams.Add(exam);
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
    }
}
