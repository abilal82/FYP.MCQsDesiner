using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        public byte CreditHour { get; set; }

        public string  CourseCode { get; set; }

        public string CourseOutLine { get; set; }

        public DegreeProgram DegreeProgram { get; set; }
    }
}
