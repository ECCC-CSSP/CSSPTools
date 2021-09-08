using CSSPCreateGzFileServices.Models;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using CSSPHelperModels;
using CSSPHelperServices;
using CSSPLogServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CreateGzFileServices.Tests
{
    [Collection("Sequential")]
    public partial class CreateGzFileServiceTests
    {
        #region Variables
        DateTime LastTime = DateTime.Now;
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private CSSPCreateGzFileServiceConfigModel config { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            config = new CSSPCreateGzFileServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspcreategzfileservicestests.json")
               .AddUserSecrets("724bc44d-9408-48dc-8513-1d2816ee63f9")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            // --------- Reading Configuration Variables
            // -----------------------------------------
            config.APISecret = Configuration.GetValue<string>("APISecret");
            Assert.NotNull(config.APISecret);

            config.azure_csspjson_backup = Configuration.GetValue<string>("azure_csspjson_backup");
            Assert.NotNull(config.azure_csspjson_backup);
            config.azure_csspjson_backup = config.azure_csspjson_backup.Replace("azure_csspjson_backup\\", "azure_csspjson_backup_test\\");
            Assert.Contains("_test", config.azure_csspjson_backup);

            config.azure_csspjson_backup_uncompress = Configuration.GetValue<string>("azure_csspjson_backup_uncompress");
            Assert.NotNull(config.azure_csspjson_backup_uncompress);
            config.azure_csspjson_backup_uncompress = config.azure_csspjson_backup_uncompress.Replace("azure_csspjson_backup_uncompress\\", "azure_csspjson_backup_uncompress_test\\");
            Assert.Contains("_test", config.azure_csspjson_backup_uncompress);

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

            config.ComputerName = Configuration.GetValue<string>("ComputerName");
            Assert.NotNull(config.ComputerName);

            config.CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            Assert.NotNull(config.CSSPAzureUrl);
            Assert.Contains("csspwebapis.", config.CSSPAzureUrl);

            config.CSSPDB = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(config.CSSPDB);

            config.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(config.CSSPDBManage);
            Assert.DoesNotContain("_test", config.CSSPDBManage);

            config.CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            Assert.NotNull(config.CSSPJSONPathLocal);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();

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

            /* ---------------------------------------------------------------------------------
             * CSSPDBContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(config.CSSPDB);
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);

            config.AzureStore = LoggedInService.Descramble(config.AzureStore);

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            Assert.NotNull(CreateGzFileService);

            var res = await CreateGzFileService.FillConfigModel(config);
            Assert.True(res);

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
