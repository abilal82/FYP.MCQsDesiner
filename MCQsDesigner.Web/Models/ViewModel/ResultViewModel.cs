using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.ViewModel
{
    public class ResultViewModel
    {
        public int NoOfQuestionAttempt { get; set; }
     
    

        public int MarksObtained { get; set; }
        public int TotalMarks { get; set; }
        public int NoOfNotAttempt { get; set; }
        public byte Marks { get; set; }

        public int TotalNoOFQuestion { get; set; }
        public int NoOfNotAttemptedQuestion { get; set; }

        public decimal  Percentage { get; set; }

        public string  Degree { get; set; }

        public string Category { get; set; }
        public string CourseCode { get; set; }

        public string ExamCode { get; set; }

        public int  ExamDuration{ get; set; }
    }
}