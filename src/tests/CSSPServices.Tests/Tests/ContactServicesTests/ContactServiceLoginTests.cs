using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactServices.Tests
{
    public partial class ContactServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Constructors_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(Configuration);
            Assert.NotNull(ServiceCollection);
            Assert.NotNull(ContactService);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Login_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRet = await ContactService.Login(loginModel);
            Assert.Equal(200, ((ObjectResult)actionRet.Result).StatusCode);
            Contact contact = (Contact)((OkObjectResult)actionRet.Result).Value;
            Assert.NotNull(contact);
            Assert.Equal(2, contact.ContactTVItemID);
            Assert.Equal("Charles".ToLower(), contact.FirstName.ToLower());
            Assert.False(string.IsNullOrWhiteSpace(contact.Token));
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_LoginEmail_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            loginModel.LoginEmail = "";

            var actionRet = await ContactService.Login(loginModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Password_Empty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            loginModel.Password = "";

            var actionRet = await ContactService.Login(loginModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Login_Good_Return_EmailCouldNotBeFound_Test(string culture)
        {
            Assert.True(await Setup(culture));

            loginModel.LoginEmail = "NotFound@email.ca";

            var actionRet = await ContactService.Login(loginModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
            string expected = String.Format(CSSPCultureServicesRes.__CouldNotBeFound, CSSPCultureServicesRes.Email, loginModel.LoginEmail);
            var value = ((BadRequestObjectResult)actionRet.Result).Value;
            Assert.Equal(expected, value);

        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ContactService_Login_Good_Return_Error_UnableToLoginAs_WithProvidedPassword_Test2(string culture)
        {
            Assert.True(await Setup(culture));

            loginModel.Password = "NotAPassword!";

            var actionRet = await ContactService.Login(loginModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
            string expected = String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail);
            var value = ((BadRequestObjectResult)actionRet.Result).Value;
            Assert.Equal(expected, value);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }

}
