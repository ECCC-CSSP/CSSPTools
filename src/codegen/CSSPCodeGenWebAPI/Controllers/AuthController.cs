using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSSPCodeGenWebAPI.Model;
using CSSPCodeGenWebAPI.Services.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/Auth/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public TokenController(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(LoginModel loginModel)
        {
            Thread.Sleep(1000);

            ServicesRes.Culture = new CultureInfo(Request.RouteValues["culture"].ToString());

            UserModel userModel = await _userService.CheckPassword(loginModel);

            // return null if user not found
            if (userModel == null)
                return BadRequest();

            if (!string.IsNullOrWhiteSpace(userModel.Error))
                return BadRequest(new { message = userModel.Error });

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userModel.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            userModel.Token = tokenHandler.WriteToken(token);

            return userModel;
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
        public string Token { get; set; }
        public string Error { get; set; }
    }

    public class LoginModel
    {
        public string LoginEmail { get; set; }
        public string Password { get; set; }
    }
}
