using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class ExamResult
    {

        public ExamResult()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
       
        public int MarksObtained { get; set; }
        [Required]
        public int CorrectAnswer { get; set; }
        [Required]
        public int InCorrectAnswer { get; set; }
        [Required]
        public int TotalMarks { get; set; }
        [Required]
        public int NoOfAttemptedQuestion{ get; set; }

        [Required]
        public int TotalNoOfQuestion { get; set; }

        public string   StudentProfileId { get; set; }
        [ForeignKey("StudentProfileId")]
        public virtual StudentProfile StudentProfiles { get; set; }

        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam ExamRusult { get; set; }

    }
}
