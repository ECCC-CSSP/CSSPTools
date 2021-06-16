using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPScrambleServices;
using CSSPSQLiteServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    public partial class ManageServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICommandLogService CommandLogService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
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
        public ManageServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task CreateCSSPDBManage()
        {
            if (fiCSSPDBManage.Exists)
            {
                try
                {
                    fiCSSPDBManage.Delete();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            await CSSPSQLiteService.CreateSQLiteCSSPDBManage();
        }
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdbmanageservicestests.json")
                .AddUserSecrets("27667b6d-6208-4074-be00-1041ba61f0c0")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ICommandLogService, CommandLogService>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

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

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            CommandLogService = Provider.GetService<ICommandLogService>();
            Assert.NotNull(CommandLogService);

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
