using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPFileServices;
using CSSPLogServices;
using CSSPSQLiteServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSSPReadGzFileServices;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPScrambleServices;
using System.Collections.Generic;

namespace CSSPDesktopServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPDesktopServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICSSPFileService CSSPFileService { get; set; }
        private ICSSPDesktopService CSSPDesktopService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        //private string AzureStoreHash { get; set; }
        List<string> CSSPOtherFileList = new List<string>();
        List<string> dirList = new List<string>();

        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CSSPDesktopServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdesktopservicestests.json")
               .AddUserSecrets("6277018e-7198-41f3-9906-f8a6ccfa30e5")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();

            Assert.NotNull(Configuration["CSSPDB"]);
            Assert.NotNull(Configuration["CSSPDBLocal"]);
            Assert.NotNull(Configuration["CSSPDBManage"]);
            Assert.NotNull(Configuration["CSSPDesktopPath"]);
            Assert.NotNull(Configuration["CSSPDatabasesPath"]);
            Assert.NotNull(Configuration["CSSPWebAPIsLocalPath"]);
            Assert.Contains("test", Configuration["CSSPWebAPIsLocalPath"]);
            Assert.NotNull(Configuration["CSSPJSONPath"]);
            Assert.Contains("test", Configuration["CSSPJSONPath"]);
            Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
            Assert.Contains("test", Configuration["CSSPJSONPathLocal"]);
            Assert.NotNull(Configuration["CSSPFilesPath"]);
            Assert.Contains("test", Configuration["CSSPFilesPath"]);
            Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
            Assert.Contains("test", Configuration["CSSPOtherFilesPath"]);
            Assert.NotNull(Configuration["CSSPTempFilesPath"]);
            Assert.Contains("test", Configuration["CSSPTempFilesPath"]);
            Assert.NotNull(Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
            Assert.Contains("test", Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
            Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
            Assert.Contains("test", Configuration["AzureStoreCSSPJSONPath"]);
            Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
            Assert.Contains("test", Configuration["AzureStoreCSSPFilesPath"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["CSSPLocalUrl"]);
            Assert.NotNull(Configuration["LoginEmail"]);
            Assert.NotNull(Configuration["Password"]);

            CSSPOtherFileList = new List<string>()
            {
                $"{ Configuration["CSSPOtherFilesPath"] }CssFamilyMaterial.css",
                $"{ Configuration["CSSPOtherFilesPath"] }flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2",
                $"{ Configuration["CSSPOtherFilesPath"] }GoogleMap.js",
                $"{ Configuration["CSSPOtherFilesPath"] }IconFamilyMaterial.css",
                $"{ Configuration["CSSPOtherFilesPath"] }HelpDocEN.rtf",
                $"{ Configuration["CSSPOtherFilesPath"] }HelpDocFR.rtf"
            };

            dirList = new List<string>()
            {
                Configuration["CSSPWebAPIsLocalPath"],
                Configuration["CSSPJSONPath"],
                Configuration["CSSPJSONPathLocal"],
                Configuration["CSSPFilesPath"],
                Configuration["CSSPOtherFilesPath"],
                Configuration["CSSPTempFilesPath"],
            };

            CreateAndEmptyDirectories(dirList);

            CreateCopyOfCSSPDBLocal();

            CreateCopyOfCSSPDBManage();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            GetProviderServices();

            if (culture == "fr_CA")
            {
                CSSPDesktopService.IsEnglish = false;
            }
            else
            {
                CSSPDesktopService.IsEnglish = true;
            }

            if (CSSPDesktopService.IsEnglish)
            {
                CSSPCultureService.SetCulture("en-CA");
            }
            else
            {
                CSSPCultureService.SetCulture("fr-CA");
            }

            CopyOtherFileToTestOtherFile();

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
