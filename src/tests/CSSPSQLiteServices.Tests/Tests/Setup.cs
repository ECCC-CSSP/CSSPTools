using CSSPCultureServices.Services;
using CSSPDBModels;
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
        private string CSSPDBLocal { get; set; }
        private string CSSPDBManage { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPDBManage { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspsqliteservicestests.json")
               .AddUserSecrets("bffe2152-6c6e-4e4f-944e-dce6d07efd1e")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalTest
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
             * CSSPDBManageTest
             * ---------------------------------------------------------------------------------      
             */
            CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(CSSPDBManage);

            fiCSSPDBManage = new FileInfo(CSSPDBManage);

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

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
