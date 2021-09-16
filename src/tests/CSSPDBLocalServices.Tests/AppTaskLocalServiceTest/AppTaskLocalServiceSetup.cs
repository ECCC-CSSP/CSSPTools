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

namespace CSSPDBLocalServices.Tests
{
    public partial class AppTaskLocalServiceTest
    {
        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private ICSSPFileService FileService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private IAppTaskLocalService AppTaskLocalService { get; set; }
        private ITVItemLocalService TVItemLocalService { get; set; }
        private string CSSPDB { get; set; }
        private string CSSPDBLocal { get; set; }
        private string CSSPDBManage { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPDBManage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLocalServiceTest()
        {

        }
        #endregion Constructors

        private async Task CreateCSSPDBLocal()
        {
            if (fiCSSPDBLocal.Exists)
            {
                try
                {
                    fiCSSPDBLocal.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            await CSSPSQLiteService.CreateSQLiteCSSPDBLocal();
        }
        private async Task<bool> AppTaskLocalServiceSetup(string culture, bool ClearLocalDB)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("86d17aa8-ffaa-4834-b06c-95bdec59d59b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<IAppTaskLocalService, AppTaskLocalService>();
            Services.AddSingleton<ITVItemLocalService, TVItemLocalService>();

            /* ---------------------------------------------------------------------------------
            * CSSPDBContext
            * ---------------------------------------------------------------------------------      
            */
            CSSPDB = Configuration.GetValue<string>("CSSPDB");
            Assert.NotNull(CSSPDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDB);
            });

            /* ---------------------------------------------------------------------------------
            * CSSPDBLocalContext
            * ---------------------------------------------------------------------------------      
            */

            CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
            * CSSPDBManageContext
            * ---------------------------------------------------------------------------------      
            */

            CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(CSSPDBManage);

            fiCSSPDBManage = new FileInfo(CSSPDBManage);

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

            TVItemLocalService = Provider.GetService<ITVItemLocalService>();
            Assert.NotNull(TVItemLocalService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            return await Task.FromResult(true);
        }
    }
}
