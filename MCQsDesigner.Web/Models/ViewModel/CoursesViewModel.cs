using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.ViewModel
{
    public class CoursesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DegreeProgram> DegreePrograms { get; set; }
        public Course Courses { get; set; }
    }
}