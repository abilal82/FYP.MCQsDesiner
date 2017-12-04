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
        [DisplayName("Questions")]
        
        [StringLength(255)]
        public string QuestionTitle { get; set; }
        [StringLength(25)]
        [Required()]
        [DisplayName("Option A")]
        public string OptionA { get; set; }
        [StringLength(25)]
        [Required]
        [DisplayName("Option B")]
        public string OptionB { get; set; }
        [StringLength(25)]
        [Required]
        [DisplayName("Option C")]
        public string OptionC { get; set; }
        [StringLength(25)]
        [Required]
        [DisplayName("Option D")]
        public string OptionD{ get; set; }
        [Required]
        [DisplayName("Answer")]
        [StringLength(25)]
        public string CorrectAnswer { get; set; }
        [Required]
        [DisplayName("Total Marks")]
        public byte Marks { get; set; } 
        public int ExamID { get; set; }

        [ForeignKey("ExamID")]
        public virtual Exam Exam { get; set; }
    }
}
