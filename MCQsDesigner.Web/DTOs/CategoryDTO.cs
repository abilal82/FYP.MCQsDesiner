using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
  
        public string Title { get; set; }
        
        public DegreeProgramDTO DegreeProgramDTO { get; set; }
    }
}