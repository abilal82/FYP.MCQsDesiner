using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public string OptionA { get; set; } 
        public string OptionB { get; set; }       
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public byte Marks { get; set; }
        public int ExamID { get; set; }
        public string ExamCode { get; set; }
    }
}