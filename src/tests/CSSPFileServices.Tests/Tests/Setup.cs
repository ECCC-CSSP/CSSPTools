using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices.Models;
using CSSPLogServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace FileServices.Tests
{
    [Collection("Sequential")]

    public partial class FileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private IFileService FileService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        private CSSPFileServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            config = new CSSPFileServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspfileservicestests.json")
               .AddUserSecrets("82e4fd10-d824-4d2a-afef-8a95e0902d75")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            config.APISecret = Configuration.GetValue<string>("APISecret");
            Assert.NotNull(config.APISecret);

            config.AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(config.AzureCSSPDB);

            config.AzureStore = Configuration.GetValue<string>("AzureStore");
            Assert.NotNull(config.AzureStore);

            config.AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            Assert.NotNull(config.AzureStoreCSSPFilesPath);
            config.AzureStoreCSSPFilesPath = config.AzureStoreCSSPFilesPath + "test";
            Assert.EndsWith("test", config.AzureStoreCSSPFilesPath);

            config.AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(config.AzureStoreCSSPJSONPath);
            config.AzureStoreCSSPJSONPath = config.AzureStoreCSSPJSONPath + "test";
            Assert.EndsWith("test", config.AzureStoreCSSPJSONPath);

            config.AzureStoreCSSPWebAPIsPath = Configuration.GetValue<string>("AzureStoreCSSPWebAPIsPath");
            Assert.NotNull(config.AzureStoreCSSPWebAPIsPath);
            config.AzureStoreCSSPWebAPIsPath = config.AzureStoreCSSPWebAPIsPath + "test";
            Assert.EndsWith("test", config.AzureStoreCSSPWebAPIsPath);

            config.CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(config.CSSPAzureUrl);
            Assert.Contains("csspwebapis.", config.CSSPAzureUrl);

            config.CSSPDB = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(config.CSSPDB);

            config.CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(config.CSSPDBLocal);

            config.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(config.CSSPDBManage);
            Assert.DoesNotContain("_test", config.CSSPDBManage);

            config.CSSPDesktopPath = Configuration.GetValue<string>("CSSPDesktopPath");
            Assert.NotNull(config.CSSPDesktopPath);

            config.CSSPDatabasesPath = Configuration.GetValue<string>("CSSPDatabasesPath");
            Assert.NotNull(config.CSSPDatabasesPath);

            config.CSSPWebAPIsPath = Configuration.GetValue<string>("CSSPWebAPIsPath");
            Assert.NotNull(config.CSSPWebAPIsPath);

            config.CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(config.CSSPJSONPath);

            config.CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            Assert.NotNull(config.CSSPFilesPath);

            config.CSSPTempFilesPath = Configuration.GetValue<string>("CSSPTempFilesPath");
            Assert.NotNull(config.CSSPTempFilesPath);

            config.CSSPOtherFilesPath = Configuration.GetValue<string>("CSSPOtherFilesPath");
            Assert.NotNull(config.CSSPOtherFilesPath);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<IFileService, FileService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();

            string CSSPDBManageTest = config.CSSPDBManage.Replace(".db", "_test.db");
            Assert.Contains("_test", CSSPDBManageTest);

            FileInfo fiCSSPDBManage = new FileInfo(config.CSSPDBManage);
            Assert.True(fiCSSPDBManage.Exists);

            FileInfo fiCSSPDBManageTest = new FileInfo(CSSPDBManageTest);
            if (!fiCSSPDBManageTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not copy {fiCSSPDBManage.FullName} to {fiCSSPDBManageTest.FullName}. Ex: {ex.Message}");
                }
            }

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManageTest.FullName }");
            });


            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

            config.AzureStore = LoggedInService.Descramble(config.AzureStore);

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            FileService = Provider.GetService<IFileService>();
            Assert.NotNull(FileService);

            var res = await FileService.FillConfigModel(config);
            Assert.True(res);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                       select c).ToList();

            try
            {
                dbManage.CommandLogs.RemoveRange(commandLogToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all CommandLogs from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
            }

            List<ManageFile> manageFileToDeleteList = (from c in dbManage.ManageFiles
                                                       select c).ToList();

            try
            {
                dbManage.ManageFiles.RemoveRange(manageFileToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all ManageFiles from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
