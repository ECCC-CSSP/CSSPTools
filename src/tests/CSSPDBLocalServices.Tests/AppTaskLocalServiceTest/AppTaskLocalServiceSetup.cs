/* 
 *  Manually Edited
 *  
 */

using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPSQLiteServices;
using CSSPFileServices;
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
using CSSPLogServices;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class AppTaskLocalServiceTest
    {
        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private ICSSPFileService FileService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private IAppTaskLocalService AppTaskLocalService { get; set; }
        private IMapInfoLocalService MapInfoLocalService { get; set; }
        private ITVItemLocalService TVItemLocalService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLocalServiceTest()
        {

        }
        #endregion Constructors

        private async Task<bool> AppTaskLocalServiceSetup(string culture, bool ClearLocalDB)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("86d17aa8-ffaa-4834-b06c-95bdec59d59b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Assert.NotNull(Configuration["APISecret"]);
            Assert.NotNull(Configuration["AzureCSSPDB"]);
            Assert.NotNull(Configuration["AzureStore"]);
            Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
            Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
            Assert.NotNull(Configuration["AzureStoreCSSPWebAPIsPath"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["CSSPLocalUrl"]);
            Assert.NotNull(Configuration["CSSPDB"]);
            Assert.NotNull(Configuration["CSSPDBLocal"]);
            Assert.NotNull(Configuration["CSSPDBManage"]);
            Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
            Assert.NotNull(Configuration["azure_csspjson_backup"]);
            Assert.NotNull(Configuration["CSSPDesktopPath"]);
            Assert.NotNull(Configuration["CSSPDatabasesPath"]);
            Assert.NotNull(Configuration["CSSPWebAPIsPath"]);
            Assert.NotNull(Configuration["CSSPJSONPath"]);
            Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
            Assert.NotNull(Configuration["CSSPFilesPath"]);
            Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
            Assert.NotNull(Configuration["ComputerName"]);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<IAppTaskLocalService, AppTaskLocalService>();
            Services.AddSingleton<IMapInfoLocalService, MapInfoLocalService>();
            Services.AddSingleton<ITVItemLocalService, TVItemLocalService>();

            /* ---------------------------------------------------------------------------------
            * CSSPDBContext
            * ---------------------------------------------------------------------------------      
            */
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["CSSPDB"]);
            });

            /* ---------------------------------------------------------------------------------
            * CSSPDBLocalContext
            * ---------------------------------------------------------------------------------      
            */
            FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"].Replace("_test", ""));
            Assert.True(fiCSSPDBLocal.Exists);

            FileInfo fiCSSPDBLocalTest = new FileInfo(Configuration["CSSPDBLocal"]);
            if (!fiCSSPDBLocalTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBLocal.FullName, fiCSSPDBLocalTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not copy {fiCSSPDBLocal.FullName} to {fiCSSPDBLocalTest.FullName}. Ex: {ex.Message}");
                }
            }

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
            * CSSPDBManageContext
            * ---------------------------------------------------------------------------------      
            */

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"].Replace("_test", ""));
            Assert.True(fiCSSPDBManage.Exists);

            FileInfo fiCSSPDBManageTest = new FileInfo(Configuration["CSSPDBManage"]);
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

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            Assert.True(await LoggedInService.SetLoggedInLocalContactInfo());

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            FileService = Provider.GetService<ICSSPFileService>();
            Assert.NotNull(FileService);

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            Assert.NotNull(CreateGzFileService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            AppTaskLocalService = Provider.GetService<IAppTaskLocalService>();
            Assert.NotNull(AppTaskLocalService);

            MapInfoLocalService = Provider.GetService<IMapInfoLocalService>();
            Assert.NotNull(MapInfoLocalService);

            TVItemLocalService = Provider.GetService<ITVItemLocalService>();
            Assert.NotNull(TVItemLocalService);

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            List<AppTask> appTaskToDeleteList = (from c in dbLocal.AppTasks
                                                       select c).ToList();

            try
            {
                dbLocal.AppTasks.RemoveRange(appTaskToDeleteList);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all AppTasks from {fiCSSPDBLocalTest.FullName}. Ex: { ex.Message }");
            }

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
    }
}
