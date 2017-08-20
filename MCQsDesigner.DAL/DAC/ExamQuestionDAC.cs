using MCQsDesigner.BOL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.DAL.DAC
{
    public class ExamQuestionDAC
    {
        private ApplicationDbContext _context;

        public ExamQuestionDAC()
        {
            _context = new ApplicationDbContext();
        }

       
        public List<ExamQuestion> GetAll()
        {
            using (_context)
            {
                return _context.ExamQuestions.Include(x => x.Exam).ToList();
            }
              

        }
        
        public ExamQuestion GetById(int Id)
        {
            using (_context)
            {
               return _context.ExamQuestions.Find(Id);
            }
        }

        public void Delete(int Id)
        {
            using (_context)
            {
                var question = _context.ExamQuestions.SingleOrDefault(x => x.Id == Id);
                _context.ExamQuestions.Remove(question);
                _context.SaveChanges();

            }
        }

    }
}
