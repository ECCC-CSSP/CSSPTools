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
            Assert.NotEmpty(FirstName);
            Assert.NotEmpty(Initial);
            Assert.NotEmpty(LastName);
            Assert.NotEmpty(LoginEmail);
            Assert.NotEmpty(Password);
            Assert.NotEmpty(CSSPDBPreferenceFileName);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalService_CheckInternetConnection_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(await LocalService.CheckInternetConnection());
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}