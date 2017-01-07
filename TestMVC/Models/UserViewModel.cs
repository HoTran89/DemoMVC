using System;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "BirthDate")]
        public DateTime DateOfBirth { get; set; }
    }
}