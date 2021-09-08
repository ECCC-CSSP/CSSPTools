/* 
 *  Manually Edited
 *  
 */

using CSSPAzureAppTaskServices.Models;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CSSPAzureAppTaskServices.Tests
{
    public partial class AzureAppTaskServiceTest
    {
        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private IAzureAppTaskService AzureAppTaskService { get; set; }
        private CSSPAzureAppTaskServiceConfigModel config { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBManageContext dbManage { get; set; }

        #endregion Properties

        #region Constructors
        public AzureAppTaskServiceTest()
        {

        }
        #endregion Constructors

        private async Task<bool> Setup(string culture)
        {
            config = new CSSPAzureAppTaskServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspAzureAppTaskservicestests.json")
               .AddUserSecrets("8d884ed8-5f30-45e9-a33d-c37d20a2323d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            // --------- Reading Configuration Variables
            // -----------------------------------------
            config.APISecret = Configuration.GetValue<string>("APISecret");
            Assert.NotNull(config.APISecret);

            config.AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(config.AzureCSSPDB);
            config.AzureCSSPDB = config.AzureCSSPDB.Replace("Initial Catalog=CSSPTemporaryDB;", "Initial Catalog=CSSPTemporaryDBTest;");
            Assert.Contains("CSSPTemporaryDBTest", config.AzureCSSPDB);

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

            config.CSSPLocalUrl = Configuration.GetValue<string>("CSSPLocalUrl");
            Assert.NotNull(config.CSSPLocalUrl);
            Assert.Contains("localhost:", config.CSSPLocalUrl);

            config.CSSPDB = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(config.CSSPDB);

            config.CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(config.CSSPDBLocal);

            config.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(config.CSSPDBManage);
            Assert.DoesNotContain("_test", config.CSSPDBManage);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<IAzureAppTaskService, AzureAppTaskService>();

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
             * using AzureCSSPDB
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(config.AzureCSSPDB);
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

            AzureAppTaskService = Provider.GetService<IAzureAppTaskService>();
            Assert.NotNull(AzureAppTaskService);

            var res = await AzureAppTaskService.FillConfigModel(config);
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

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            AzureAppTaskService = Provider.GetService<IAzureAppTaskService>();
            Assert.NotNull(AzureAppTaskService);

            List<AppTask> appTaskToDeleteList = (from c in db.AppTasks
                                                 select c).ToList();

            try
            {
                db.AppTasks.RemoveRange(appTaskToDeleteList);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all AppTasks from db. Ex: { ex.Message }");
            }

            return await Task.FromResult(true);
        }
    }
}
