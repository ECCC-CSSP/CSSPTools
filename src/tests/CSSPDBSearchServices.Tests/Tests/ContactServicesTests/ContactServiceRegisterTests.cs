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
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_And_RemoveAspNetUserAndContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(200, ((ObjectResult)actionRet.Result).StatusCode);
            Contact contact = (Contact)((OkObjectResult)actionRet.Result).Value;
            Assert.NotNull(contact);
            Assert.True(contact.ContactTVItemID > 0);
            Assert.Equal(registerModel.FirstName.ToLower(), contact.FirstName.ToLower());
            Assert.False(string.IsNullOrWhiteSpace(contact.Token));


            await LoggedInService.SetLoggedInContactInfo(contact.Id);
            LoggedInService.DBLocation = DBLocationEnum.Server;
            LoggedInService.RunningOn = RunningOnEnum.Azure;

            string Id = contact.Id;
            int ContactTVItemID = contact.ContactTVItemID;

            var actionRet2 = await ContactService.RemoveAspNetUserAndContact(Id);
            Assert.Equal(200, ((ObjectResult)actionRet2.Result).StatusCode);
            Assert.True((bool)((OkObjectResult)actionRet2.Result).Value);

            var actionRet3 = await TVItemService.Delete(ContactTVItemID);
            Assert.Equal(200, ((ObjectResult)actionRet3.Result).StatusCode);
            Assert.True((bool)((OkObjectResult)actionRet3.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_FirstName_Emmpty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "", // "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_LastName_Emmpty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "", // "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_LoginEmail_Emmpty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "", // "AlAlAl.BlBlBl@somewhere.com",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_Password_Emmpty_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = "", // loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_PasswordAndConfirmPasswordNotEqual_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password + "a",
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_FullNameAlreadyExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "Charles",
                Initial = "G",
                LastName = "LeBlanc",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "AlAlAl.BlBlBl@somewhere.com",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ContactService_Register_LoginEmailAlreadyExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            RegisterModel registerModel = new RegisterModel()
            {
                FirstName = "AlAlAl",
                Initial = "T",
                LastName = "BlBlBl",
                ContactTitle = ContactTitleEnum.DirectorGeneral,
                LoginEmail = "Charles.LeBlanc2@canada.ca",
                Password = loginModel.Password,
                ConfirmPassword = loginModel.Password,
            };

            var actionRet = await ContactService.Register(registerModel);
            Assert.Equal(400, ((ObjectResult)actionRet.Result).StatusCode);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }

}
