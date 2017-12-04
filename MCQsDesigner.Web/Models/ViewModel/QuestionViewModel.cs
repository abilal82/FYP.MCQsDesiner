using MCQsDesigner.BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCQsDesigner.Web.Models.ViewModel
{
	public class QuestionViewModel
	{

        public int Id { get; set; }
        [DisplayName("Questions")]
        [Required(ErrorMessage ="Question must write to add question")]
        [StringLength(255, ErrorMessage ="No more than 255 charcters")]
        [AllowHtml]
        public string QuestionTitle { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage ="Required filed ")]
        [DisplayName("Option A")]
        public string OptionA { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage = "Required filed ")]
        [DisplayName("Option B")]
        public string OptionB { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Required filed ")]
        [DisplayName("Option C")]
        public string OptionC { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Required filed ")]
        [DisplayName("Option D")]
        public string OptionD { get; set; }

        [Required(ErrorMessage = "Required filed ")]
        [DisplayName("Answer")]
        [StringLength(25)]
        public string CorrectAnswer { get; set; }

        [Required(ErrorMessage = "Required filed ")]
        [DisplayName("Total Marks")]
        public byte Marks { get; set; }

        [Required(ErrorMessage = "Required filed ")]
        [DisplayName("Quiz")]
        public int ExamID { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}