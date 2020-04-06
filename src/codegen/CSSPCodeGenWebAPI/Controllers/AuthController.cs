using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/Auth/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public TokenController()
        {

        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(LoginModel loginModel)
        {
            List<UserModel> userModelList = new List<UserModel>() {
                new UserModel()
                {
                    ContactID = 2,
                    Id = "IdIdIDidididididididi",
                    ContactTVItemID = 34,
                    LoginEmail = loginModel.LoginEmail,
                    FirstName = "Charles",
                    Initial = "G",
                    LastName = "LeBlanc",
                    Password = loginModel.Password,
                    Token = "Thisifjlsjflsj lefj token",
                },
                    new UserModel()
                {
                    ContactID = 4,
                    Id = "IdIdIDidididididididi",
                    ContactTVItemID = 34,
                    LoginEmail = loginModel.LoginEmail,
                    FirstName = "Charles",
                    Initial = "G",
                    LastName = "LeBlanc",
                    Password = loginModel.Password,
                    Token = "Thisifjlsjflsj lefj token",
                },
            };

            return (from c in userModelList
                    select c).FirstOrDefault();
        }
    }

    public class UserModel
    {
        public int ContactID { get; set; }
        public string Id { get; set; }
        public int ContactTVItemID { get; set; }
        public string LoginEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class LoginModel
    {
        public string LoginEmail { get; set; }
        public string Password { get; set; }
    }
}
