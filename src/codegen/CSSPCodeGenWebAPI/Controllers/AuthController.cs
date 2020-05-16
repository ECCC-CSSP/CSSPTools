using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSSPCodeGenWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserServices.Models;
using UserServices.Services;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/Auth/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IUserService userService { get; }
        #endregion Properties

        #region Constructors
        public TokenController(IUserService userService)
        {
            this.userService = userService;
        }
        #endregion Constructors

        #region Functions public
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post(LoginModel loginModel)
        {
            //Thread.Sleep(1000);

            await userService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));

            return await userService.CheckPassword(loginModel);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
