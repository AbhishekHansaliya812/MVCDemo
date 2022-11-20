using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCDemo.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please Enter User Name")]
        public string UserName { get; set; }

        [Display(Name = "Mobile")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please provide valid Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        public string Gender { get; set; }  
    }
}