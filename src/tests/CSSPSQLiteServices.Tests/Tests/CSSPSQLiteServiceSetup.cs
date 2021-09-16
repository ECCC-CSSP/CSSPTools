using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPSQLiteServices.Models;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPSQLiteServices.Tests
{
    public partial class CSSPSQLiteServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private CSSPDBLocalContext dbLocalTest { get; set; }
        private CSSPDBManageContext dbMTest { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPDBManage { get; set; }
        private CSSPSQLiteServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        private async Task<bool> CSSPSQLiteServiceSetup(string culture)
        {
            config = new CSSPSQLiteServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspsqliteservicestests.json")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            config.CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(config.CSSPDBLocal);

            config.CSSPDBLocal = config.CSSPDBLocal.Replace(".db", "_test.db");
            Assert.Contains("_test", config.CSSPDBLocal);

            fiCSSPDBLocal = new FileInfo(config.CSSPDBLocal);

            if (fiCSSPDBLocal.Exists)
            {
                try
                {
                    fiCSSPDBLocal.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not delete {fiCSSPDBLocal.FullName}. Ex: {ex.Message}");
                }
            }

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            config.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(config.CSSPDBManage);

            config.CSSPDBManage = config.CSSPDBManage.Replace(".db", "_test.db");
            Assert.Contains("_test", config.CSSPDBManage);

            fiCSSPDBManage = new FileInfo(config.CSSPDBManage);
            
            if (fiCSSPDBManage.Exists)
            {
                try
                {
                    fiCSSPDBManage.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not delete {fiCSSPDBManage.FullName}. Ex: {ex.Message}");
                }
            }

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            await CSSPSQLiteService.FillConfigModel(config);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
