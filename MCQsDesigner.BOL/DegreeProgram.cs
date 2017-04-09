using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class DegreeProgram
    {
        public DegreeProgram()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string ProgramTitle { get; set; }
        public DegreeLevel DegreeLevel { get; set; }
        public virtual ICollection<Course> Courses { get; set; }    

    }
}
