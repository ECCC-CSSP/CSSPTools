﻿using CSSPDBModels;
using CSSPHelperModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPAzureLoginServices.Tests
{
    public partial class CSSPAzureLoginServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPAzureLoginService_Login_Good_Test(string culture)
        {
            Assert.True(await CSSPAzureLoginServiceSetup(culture));

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
            Assert.Empty(CSSPLogService.ErrRes.ErrList);

            Contact contact = (from c in dbManage.Contacts
                               select c).FirstOrDefault();
            Assert.NotNull(contact);

            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.Equal(contact.ContactTVItemID, CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID);
        }
    }
}