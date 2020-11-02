using CSSPModels;
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

namespace LoggedInServices.Tests
{
    [Collection("Sequential")]
    public partial class LoggedInServicesTests
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
        public async Task LoggedInService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(Id);
            Assert.NotNull(FirstName1);
            Assert.NotNull(Initial1);
            Assert.NotNull(LastName1);
            Assert.NotNull(Id2);
            Assert.NotNull(FirstName2);
            Assert.NotNull(LastName2);
            Assert.NotNull(Id3);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInContactInfo_With_Id_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo(Id);
            Assert.Equal(Id, LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            Contact contact = LoggedInService.LoggedInContactInfo.LoggedInContact;
            Assert.Equal(FirstName1, contact.FirstName);
            Assert.Equal(Initial1, contact.Initial);
            Assert.Equal(LastName1, contact.LastName);

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count > 0);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInContactInfo_With_Id2_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo(Id2);
            Assert.Equal(Id2, LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            Contact contact = LoggedInService.LoggedInContactInfo.LoggedInContact;
            Assert.Equal(FirstName2, contact.FirstName);
            Assert.Equal(LastName2, contact.LastName);

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count == 1);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count == 1);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInContactInfo_With_Id3_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo(Id3);
            Assert.Null(LoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count == 0);
            Assert.True(LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_Contact_Should_Exist_In_Memory_DB_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // first time it will get the LoggedInContactInfo from the read DB
            await LoggedInService.SetLoggedInContactInfo(Id);
            Assert.Equal(Id, LoggedInService.LoggedInContactInfo.LoggedInContact.Id);

            // first time it will get the LoggedInContactInfo from the InMemory DB
            await LoggedInService.SetLoggedInContactInfo(Id);
            Assert.Equal(Id, LoggedInService.LoggedInContactInfo.LoggedInContact.Id);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
