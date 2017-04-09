using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class DegreeLevel
    {
        public DegreeLevel()
        {
            DegreePrograms = new HashSet<DegreeProgram>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public byte Duration { get; set; }
        public ICollection<DegreeProgram> DegreePrograms { get; set; }
    }
}
