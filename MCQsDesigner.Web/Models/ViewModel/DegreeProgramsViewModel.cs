using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.ViewModel
{
    public class DegreeProgramsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public DegreeProgram DegreePrograms { get; set; }
    }
}