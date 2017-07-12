using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsAcademy.Models
{
    public class Kids
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(14, ErrorMessage = "Length must be less than 15")]
        public string FirstName { get; set; }

        [Required(ErrorMessage= "Last Name is required")]
        [StringLength(14, ErrorMessage = "Length must be less than 15")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 12, ErrorMessage= "Age must be between 1 to 12")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@".*@.*", ErrorMessage = "Email must be valid")]
        public string Email { get; set; }

    }
}