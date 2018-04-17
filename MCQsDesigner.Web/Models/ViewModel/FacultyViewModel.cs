using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCQsDesigner.Web.Models.ViewModel
{
    public class FacultyViewModel
    {
        public string UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(25)]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [StringLength(10)]
        [Display(Name = "Roles")]
        [Required]
        public String  Role { get; set; }


    }
}