using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPDBModels;
using CSSPSQLiteServices;
using DownloadFileServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using Xunit;
using CSSPDBCommandLogModels;
using CSSPDBFilesManagementModels;
using CSSPDBPreferenceModels;
using LoggedInServices;
using CSSPScrambleServices;
using FilesManagementServices;

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
        private ICSSPDesktopService CSSPDesktopService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDesktopService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
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
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            //Services.AddSingleton<IPreferenceService, PreferenceService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<IFilesManagementService, FilesManagementService>();
            Services.AddSingleton<IDownloadFileService, DownloadFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            //Services.AddSingleton<IWebAppLoadedService, WebAppLoadedService>();
            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();

            /* ---------------------------------------------------------------------------------
             * using TestDB
             * ---------------------------------------------------------------------------------      
             */
            string TestDB = Configuration.GetValue<string>("TestDB");
            Assert.NotNull(TestDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDB);
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocal
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBCommandLog
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBCommandLog = Configuration.GetValue<string>("CSSPDBCommandLog");
            Assert.NotNull(CSSPDBCommandLog);

            FileInfo fiCSSPDBCommandLog = new FileInfo(CSSPDBCommandLog);

            Services.AddDbContext<CSSPDBCommandLogContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBCommandLog.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBFilesManagement
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagement);

            FileInfo fiCSSPDBFileManagement = new FileInfo(CSSPDBFilesManagement);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFileManagement.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreference);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
            Assert.NotNull(CSSPDesktopService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

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

            if (!CSSPDesktopService.ReadConfiguration().GetAwaiter().GetResult()) return false;

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
