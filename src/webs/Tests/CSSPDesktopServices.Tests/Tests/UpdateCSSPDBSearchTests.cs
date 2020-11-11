using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CSSPHelperModels;

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
        public async Task CSSPDesktopService_UpdateCSSPDBSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration.GetValue<string>("LoginEmail"),
                Password = Configuration.GetValue<string>("Password"),
            };

            bool retBool = await CSSPDesktopService.Login(loginModel);
            Assert.True(retBool);

            bool retBool2 = await CSSPDesktopService.CheckIfLoginIsRequired();
            Assert.True(retBool2);

            bool retBool3 = await CSSPDesktopService.UpdateCSSPDBSearch();
            Assert.True(retBool3);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
