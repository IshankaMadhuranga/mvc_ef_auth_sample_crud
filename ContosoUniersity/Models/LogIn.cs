using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ContosoUniersity.Models
{
    public class LogIn
    {
        [Required(ErrorMessage = "Email is requird.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is requird.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}