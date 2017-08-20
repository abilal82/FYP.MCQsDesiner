using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.DAL.DAC
{
    public class CourseDAC : IDisposable
    {
        private ApplicationDbContext _context;

        public CourseDAC()
        {
            _context = new ApplicationDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Course> getAllCourses()
        {
            return _context.Courses.Include(x => x.DegreeProgram).ToList();
        }

       
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int Id)
        {
            var model = _context.Courses.SingleOrDefault(x =>x.Id ==Id);
            _context.Courses.Remove(model);
            _context.SaveChanges();
        }

    }
}
