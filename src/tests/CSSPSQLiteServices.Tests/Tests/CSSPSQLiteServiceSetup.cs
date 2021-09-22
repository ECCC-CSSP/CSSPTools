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
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        private async Task<bool> CSSPSQLiteServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspsqliteservicestests.json")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            FileInfo fi = new FileInfo(Configuration["CSSPDBLocal"]);
            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ Configuration["CSSPDBLocal"] }");
            });

            fi = new FileInfo(Configuration["CSSPDBManage"]);
            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ Configuration["CSSPDBManage"] }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
