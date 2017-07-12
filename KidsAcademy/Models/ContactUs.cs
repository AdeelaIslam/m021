using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsAcademy.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Name is Required.")]
        public String Name { set; get; }

        [Required(ErrorMessage = "Email is Required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Mail Format is not Correct.")]
        public String Email { set; get; }

        
        

        [Required(ErrorMessage = "Message is Required.")]
        public String Message { set; get; }

    }
}