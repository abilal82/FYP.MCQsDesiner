using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class StudentProfile
    {
        public StudentProfile()
        {
            Examresults = new HashSet<ExamResult>();
        }
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [StringLength(25)]
        [Required]
        public string RollNumber { get; set; }
        [StringLength(25)]
        [Required]
        public string Session { get; set; }

        public ICollection<ExamResult> Examresults { get; set; }


    }
}
