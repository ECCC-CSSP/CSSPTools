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

namespace LocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalServicesTests
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
        public async Task LocalService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.False(LocalService.HasInternetConnection);
            Assert.Null(LocalService.LoggedInContactInfo);
            Assert.NotEmpty(FirstName);
            Assert.NotEmpty(Initial);
            Assert.NotEmpty(LastName);
            Assert.NotEmpty(LoginEmail);
            Assert.NotEmpty(Password);
            Assert.NotEmpty(CSSPDBLoginFileName);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalService_CheckInternetConnection_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(await LocalService.CheckInternetConnection());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalService_Scramble_And_DeScramble_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            List<string> TextToScrambleList = new List<string>()
            {
                "bonjour", "rouge", "1214123", "lsjf slefij", "@#$%^!&", "     "
            };

            foreach (string toScramble in TextToScrambleList)
            {
                string scrambleText = await LocalService.Scramble(toScramble);
                Assert.Equal(toScramble.Length + 1, scrambleText.Length);
                Assert.Equal(toScramble, await LocalService.Descramble(scrambleText));
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInContactInfo_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo.LoggedInContact.Id);

            Contact contact = LocalService.LoggedInContactInfo.LoggedInContact;
            Assert.Equal(FirstName, contact.FirstName);
            Assert.Equal(Initial, contact.Initial);
            Assert.Equal(LastName, contact.LastName);

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = LocalService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count == 1);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = LocalService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count == 0);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo.LoggedInContact.Id);

            // Second time should use the In Memory
            contact = LocalService.LoggedInContactInfo.LoggedInContact;
            Assert.Equal(FirstName, contact.FirstName);
            Assert.Equal(Initial, contact.Initial);
            Assert.Equal(LastName, contact.LastName);

            TVTypeUserAuthorizationList = LocalService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count == 1);

            TVItemUserAuthorizationList = LocalService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count == 0);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
