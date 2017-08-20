using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class ExamQuestion
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Question")]
        [StringLength(255)]
        public string QuestionTitle { get; set; }
        [StringLength(25)]
        [Required]
        public string OptionA { get; set; }
        [StringLength(25)]
        [Required]

        public string OptionB { get; set; }
        [StringLength(25)]
        [Required]
        public string OptionC { get; set; }
        [StringLength(25)]
        [Required]
        public string OptionD{ get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        [Required]
        public byte Marks { get; set; } 
        public int ExamID { get; set; }

        [ForeignKey("ExamID")]
        public virtual Exam Exam { get; set; }
    }
}
