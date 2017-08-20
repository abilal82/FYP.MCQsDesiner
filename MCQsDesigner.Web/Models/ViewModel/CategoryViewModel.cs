using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.ViewModel
{
    public class CategoryViewModel
    {
        public Category Categories { get; set; }
        public IEnumerable<DegreeProgram> DegreePrograms { get; set; }
        public IEnumerable<Category> Category { get;set; }
    }
}