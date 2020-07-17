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
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CSSPCodeGenWebAPI.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IContactService ContactService { get; }
        #endregion Properties

        #region Constructors
        public AuthController(IContactService ContactService)
        {
            this.ContactService = ContactService;
        }
        #endregion Constructors

        #region Functions public
        [Route("Token")]
        [HttpPost]
        public async Task<ActionResult<Contact>> Token(LoginModel loginModel)
        {
            //Thread.Sleep(1000);

            return await ContactService.Login(loginModel);
        }
        //[Route("Register")]
        //[HttpPost]
        //public async Task<ActionResult<bool>> Register(RegisterModel registerModel)
        //{
        //    //Thread.Sleep(1000);

        //    await ContactService.SetCulture(new CultureInfo(Request.RouteValues["culture"].ToString()));

        //    return await ContactService.Register(registerModel);
        //}
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
