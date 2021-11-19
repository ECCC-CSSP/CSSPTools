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
using System.Linq;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FillContactHasInternetConnectionAsync_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            Assert.Empty(CSSPLogService.ErrRes.ErrList);

            DeleteCSSPDesktopPath();
            CreateCSSPDatabasesPath();
            await CheckCSSPDBManage();

            Assert.Empty(CSSPLogService.ErrRes.ErrList);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            Assert.Empty(CSSPLogService.ErrRes.ErrList);

            Assert.True(await CSSPDesktopService.LoginAsync(loginModel));
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.True(CSSPDesktopService.contact.IsLoggedIn);
            Assert.False(CSSPDesktopService.LoginRequired);

            bool retBool = await CSSPDesktopService.FillContactHasInternetConnectionAsync();
            Assert.True(retBool);
            
            Contact contactRet = (from c in dbManage.Contacts
                                  select c).FirstOrDefault();

            Assert.NotNull(contactRet); 
            Assert.True(contactRet.IsLoggedIn);
            Assert.True(contactRet.HasInternetConnection); 
        }
    }
}
