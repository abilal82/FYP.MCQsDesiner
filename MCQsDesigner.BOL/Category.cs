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
    public class Category
    {
        public Category()
        {
            DegreeProgram = new HashSet<DegreeProgram>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(10)]
        [DisplayName("Degree Level")]      
        public string Title { get; set; }
        public byte Duration { get; set; }
      
        public virtual ICollection<DegreeProgram> DegreeProgram { get; set; }
    }
}
