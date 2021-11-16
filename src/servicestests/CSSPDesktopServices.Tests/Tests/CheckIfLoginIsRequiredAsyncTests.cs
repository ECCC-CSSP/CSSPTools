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
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDesktopService_CheckIfLoginIsRequired_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            Assert.True(await CSSPDesktopService.LogoffAsync());
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.False(CSSPDesktopService.contact.IsLoggedIn);
            Assert.True(CSSPDesktopService.LoginRequired);

            Assert.True(await CSSPDesktopService.CheckIfLoginIsRequiredAsync());
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.False(CSSPDesktopService.contact.IsLoggedIn);
            Assert.True(CSSPDesktopService.LoginRequired);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            Assert.True(await CSSPDesktopService.LoginAsync(loginModel));
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.True(CSSPDesktopService.contact.IsLoggedIn);
            Assert.False(CSSPDesktopService.LoginRequired);

            Assert.True(await CSSPDesktopService.CheckIfLoginIsRequiredAsync());
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.True(CSSPDesktopService.contact.IsLoggedIn);
            Assert.False(CSSPDesktopService.LoginRequired);
        }
    }
}
