using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.DAL.DAC
{
    public class DegreeProgramDAC
    {
        private ApplicationDbContext _context;
        public DegreeProgramDAC()
        {

            _context = new ApplicationDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<DegreeProgram> GetAll()
        {

            var model = _context.DegreePrograms
                        .Include(x => x.Category).ToList();
                        
            return model;

        }

      


        public void AddDegreeTitle(DegreeProgram degree)
        {
            _context.DegreePrograms.Add(degree);
            _context.SaveChanges();
        }
        public void DeleteDegree(int id)
        {
            var category = _context.DegreePrograms.SingleOrDefault(x => x.Id == id);
            _context.DegreePrograms.Remove(category);
            _context.SaveChanges();
        }
    }
}
