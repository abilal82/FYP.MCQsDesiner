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
                return _context.ExamQuestions.SingleOrDefault(x => x.Id == Id);
            }
        }


        public List<ExamQuestion> GetQuestionsByExamId(int examId)
        {
            using (_context)
            {
                return _context.ExamQuestions.Include(x => x.Exam)
                                             .Where(x => x.ExamID == examId).ToList();
            }
        }

        public void CreateQuestion(ExamQuestion question)
        {
            using (_context)
            {
                try
                {
                    _context.ExamQuestions.Add(question);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;

                }
             


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
