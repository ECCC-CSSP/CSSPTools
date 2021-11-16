using System;
using System.Collections.Generic;
using System.Text;

namespace UserServices.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string Initial { get; set; }
        public string LastName { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
