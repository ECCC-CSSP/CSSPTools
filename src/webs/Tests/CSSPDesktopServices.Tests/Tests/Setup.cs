using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPDesktopServices.Services;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CSSPDesktopServices.Tests
{
    public partial class CSSPDesktopServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
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
            Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<IDownloadGzFileService, DownloadGzFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ILocalService, LocalService>();

            // Doing CSSPDBLocalContext
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            // Doing CSSPDBSearchContext
            string CSSPDBSearch = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearch);

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearch);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            // Doing CSSPDBFilesManagementContext
            string CSSPDBFilesManagement = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagement);

            FileInfo fiCSSPDBFileManagement = new FileInfo(CSSPDBFilesManagement);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFileManagement.FullName }");
            });

            // Doing CSSPDBLoginContext
            string CSSPDBLogin = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLogin);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLogin);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            try
            {
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
                    CSSPDesktopService.appTextModel = new AppTextModelEN();
                }
                else
                {
                    CSSPDesktopService.appTextModel = new AppTextModelFR();
                }

                if (!CSSPDesktopService.ReadConfiguration().GetAwaiter().GetResult()) return false;


            }
            catch (Exception ex)
            {

                throw;
            }
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
