using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.DTOs
{
    public class ExamDTO
    {
        public int Id { get; set; }
       
        public string ExamCode { get; set; }
        public int Duration { get; set; }
        public string ExamDate { get; set; }
        public DateTime StartingTime { get; set; }

        public int CourseId { get; set; }

        public string Course { get; set; }
        public string Category { get; set; }

        public string Degree { get; set; }
    }
}