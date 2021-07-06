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
            Assert.NotNull(LoginEmail);
            Assert.NotNull(FirstName1);
            Assert.NotNull(Initial1);
            Assert.NotNull(LastName1);
            Assert.NotNull(LoginEmail3);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInContactInfo_With_LoginEmail_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo(LoginEmail);
            Assert.Equal(LoginEmail, LoggedInService.LoggedInContactInfo.LoggedInContact.LoginEmail);

            Contact contact = LoggedInService.LoggedInContactInfo.LoggedInContact;
            Assert.Equal(FirstName1, contact.FirstName);
            Assert.Equal(Initial1, contact.Initial);
            Assert.Equal(LastName1, contact.LastName);

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
            Assert.True(TVTypeUserAuthorizationList.Count > 0);

            List<TVItemUserAuthorization> TVItemUserAuthorizationList = LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
            Assert.True(TVItemUserAuthorizationList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInContactInfo_With_LoginEmail3_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo(LoginEmail3);
            Assert.Null(LoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count == 0);
            Assert.True(LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInLocalContactInf_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(LoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0);
            Assert.True(LoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_Scramble_and_Descramble_With_Empty_String_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string retStr = LoggedInService.Scramble("");
            Assert.Equal("", retStr);

            retStr = LoggedInService.Descramble("");
            Assert.Equal("", retStr);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_Scramble_and_Descramble_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Random random = new Random();

            for (int countWord = 0; countWord < 10000; countWord++)
            {
                string Word = "";
                string ScrambleWord = "";
                string DescrambleWord = "";

                int wordLength = random.Next(1, 250);
                for (int i = 0; i < wordLength; i++)
                {
                    Word += (char)random.Next('0', 'z');
                }

                ScrambleWord = LoggedInService.Scramble(Word);
                Assert.NotEqual(Word, ScrambleWord);

                DescrambleWord = LoggedInService.Descramble(ScrambleWord);
                Assert.Equal(Word, DescrambleWord);
            }

        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
