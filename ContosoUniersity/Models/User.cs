using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniersity.Models
{
    public class User
    {
       
            [Key]
            public int ID { get; set; }

            [Required(ErrorMessage = "First name is requird.")]
            public string FirtName { get; set; }

            [Required(ErrorMessage = "Last name is requird.")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is requird.")]
            [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter valid email!")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is requird.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            //[Compare("Password", ErrorMessage = "Password not matched.")]
            //[DataType(DataType.Password)]
            //public string ConfirmPassword { get; set; }

        
    }
}