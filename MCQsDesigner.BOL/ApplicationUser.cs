using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQsDesigner.BOL
{
    public class ApplicationUser :IdentityUser
    {
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        public virtual StudentProfile StudentProfile{ get; set; }


    }
}
