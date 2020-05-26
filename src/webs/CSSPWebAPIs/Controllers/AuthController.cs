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
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IUserService userService { get; }
        #endregion Properties

        #region Constructors
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        #endregion Constructors

        #region Functions public
        [Route("Token")]
        [HttpPost]
        public async Task<ActionResult<UserModel>> Token(LoginModel loginModel)
        {
            //Thread.Sleep(1000);

            await userService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));

            return await userService.Login(loginModel);
        }
        //[Route("Register")]
        //[HttpPost]
        //public async Task<ActionResult<bool>> Register(RegisterModel registerModel)
        //{
        //    //Thread.Sleep(1000);

        //    await userService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));

        //    return await userService.Register(registerModel);
        //}
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
