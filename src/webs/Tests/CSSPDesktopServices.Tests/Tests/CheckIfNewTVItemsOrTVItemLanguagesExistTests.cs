using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
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
        public async Task CSSPDesktopService_CheckIfNewTVItemsOrTVItemLanguagesExist_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.True(await CSSPDesktopService.CheckingInternetConnection());

            Assert.True(await CSSPDesktopService.CheckIfNewTVItemsOrTVItemLanguagesExist());
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
