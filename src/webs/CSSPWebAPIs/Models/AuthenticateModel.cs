using CSSPWebAPIs.Resources;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPWebAPIs.Models
{
    public class LoginModel
    {
        [Required]
        public string LoginEmail { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        public string Initial { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string LoginEmail { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
