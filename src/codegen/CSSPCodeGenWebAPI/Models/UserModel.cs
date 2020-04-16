using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Models
{
    public class UserModel
    {
        public int ContactID { get; set; }
        public string Id { get; set; }
        public int ContactTVItemID { get; set; }
        public string LoginEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }

}
