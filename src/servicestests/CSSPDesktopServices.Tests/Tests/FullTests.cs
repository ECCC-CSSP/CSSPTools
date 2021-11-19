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
using System.Threading;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Full_Good_Test(string culture)
        {
            Assert.True(await CSSPDesktopServiceSetup(culture));

            DeleteCSSPDesktopPath();
            CreateCSSPDatabasesPath();
            await CheckCSSPDBManage();

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            Assert.True(await CSSPDesktopService.LoginAsync(loginModel));
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.True(CSSPDesktopService.contact.IsLoggedIn);
            Assert.False(CSSPDesktopService.LoginRequired);

            Assert.True(await CSSPDesktopService.LogoffAsync());
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.False(CSSPDesktopService.contact.IsLoggedIn);
            Assert.True(CSSPDesktopService.LoginRequired);

            Assert.True(await CSSPDesktopService.FillLoginRequiredAsync());
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.False(CSSPDesktopService.contact.IsLoggedIn);
            Assert.True(CSSPDesktopService.LoginRequired);

            Assert.True(await CSSPDesktopService.LoginAsync(loginModel));
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.True(CSSPDesktopService.contact.IsLoggedIn);
            Assert.False(CSSPDesktopService.LoginRequired);

            Assert.True(await CSSPDesktopService.FillLoginRequiredAsync());
            Assert.NotNull(CSSPDesktopService.contact);
            Assert.True(CSSPDesktopService.contact.IsLoggedIn);
            Assert.False(CSSPDesktopService.LoginRequired);

            await CopyAzureZipUpdateFilesToAzureTestDirectory();

            await CopyAzureJsonUpdateFilesToAzureTestDirectory();

            Assert.True(await CSSPDesktopService.CreateAllRequiredDirectoriesAsync());

            Assert.True(await CSSPDesktopService.InstallUpdatesAsync());

            Assert.True(await CSSPDesktopService.FillUpdateIsNeededAsync());
            Assert.False(CSSPDesktopService.UpdateIsNeeded);

            List<string> WebAPIsLocalFileNameList = new List<string>()
            {
                "CSSPWebAPIsLocal.exe",
                "e_sqlite3.dll"
            };

            foreach (string fileName in WebAPIsLocalFileNameList)
            {
                FileInfo fi = new FileInfo($"{ Configuration["AfterInstallLocalCSSPWebAPIsLocalPath"] }{ fileName }");
                Assert.True(fi.Exists);
            }

            List<string> CSSPClientFileNameList = new List<string>()
            {
                "index.html",
            };

            foreach (string fileName in CSSPClientFileNameList)
            {
                FileInfo fi = new FileInfo($"{ Configuration["AfterInstallLocalCSSPWebAPIsLocalClientPath"] }{ fileName }");
                Assert.True(fi.Exists);
            }

            foreach (string fileName in await CSSPDesktopService.GetCSSPOtherFileListAsync())
            {
                FileInfo fiOther = new FileInfo(fileName);

                FileInfo fi = new FileInfo($"{ Configuration["AfterInstallLocalCSSPOtherFilesPath"] }{ fiOther.Name }");
                Assert.True(fi.Exists);
            }

            foreach (string fileName in await CSSPDesktopService.GetJsonFileNameListAsync())
            {
                FileInfo fiJson = new FileInfo(fileName);

                FileInfo fi = new FileInfo($"{ Configuration["AfterInstallLocalCSSPJsonPath"] }{ fiJson.Name }");
                Assert.True(fi.Exists);
            }

            Assert.True(await CSSPDesktopService.StartAsync());

            Thread.Sleep(3000);

            Assert.True(await CSSPDesktopService.StopAsync());
        }
    }
}
