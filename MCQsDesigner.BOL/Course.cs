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
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Course")]
        public int Id { get; set; }
        public string CourseTitle { get; set; }

        public byte CreditHour { get; set; }

        public string  CourseCode { get; set; }

        public string CourseOutLine { get; set; }
        
        [ForeignKey("DegreeID")]
        public virtual DegreeProgram DegreeProgram { get; set; }
        public int DegreeID { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }

    }
}
