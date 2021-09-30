using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServerLoggedInServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPServerLoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPServerLoggedInServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPServerLoggedInService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SetLoggedInContactInfo_With_LoginEmail_Good_Test(string culture)
        {
            Assert.True(await CSSPServerLoggedInServiceSetup(culture));

            await CSSPServerLoggedInService.SetLoggedInContactInfo(Configuration["LoginEmail"]);
            Assert.Equal(Configuration["LoginEmail"], CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.LoginEmail);

            Contact contact = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact;
            Assert.Equal(Configuration["FirstName1"], contact.FirstName);
            Assert.Equal(Configuration["Initial1"], contact.Initial);
            Assert.Equal(Configuration["LastName1"], contact.LastName);

            List <TVTypeUserAuthorization> TVTypeUserAuthorizationList = CSSPServerLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count > 0);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = CSSPServerLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task SetLoggedInContactInfo_With_LoginEmail3_Good_Test(string culture)
        {
            Assert.True(await CSSPServerLoggedInServiceSetup(culture));

            await CSSPServerLoggedInService.SetLoggedInContactInfo(Configuration["LoginEmail3"]);
            Assert.Null(CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(CSSPServerLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count == 0);
            Assert.True(CSSPServerLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count == 0);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
