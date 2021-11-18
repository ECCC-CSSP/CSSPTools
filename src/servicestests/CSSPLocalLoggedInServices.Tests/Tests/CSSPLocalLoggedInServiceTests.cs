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

namespace CSSPLocalLoggedInServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPLocalLoggedInServicesTests
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
            Assert.True(await CSSPLocalLoggedInServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPLocalLoggedInService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LoggedInService_SetLoggedInLocalContactInf_Good_Test(string culture)
        {
            Assert.True(await CSSPLocalLoggedInServiceSetup(culture));

            await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0);
            Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
