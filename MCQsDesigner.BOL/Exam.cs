using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    [Table("Exams")]
    public class Exam
    {
        public Exam()
        {
            ExamQuestion = new HashSet<ExamQuestion>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ExamCode { get; set; }
        public int Duration { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime?  StartingTime { get; set; }
    
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestion { get; set; }
    }
}
