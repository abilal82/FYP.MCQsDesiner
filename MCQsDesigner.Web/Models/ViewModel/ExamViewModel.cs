using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.ViewModel
{
    public class ExamViewModel
    {
        public Exam Exam { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<DegreeProgram> DegreePrograms { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}