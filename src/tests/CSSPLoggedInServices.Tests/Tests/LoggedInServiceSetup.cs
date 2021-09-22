using CSSPCultureServices.Resources;
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

namespace LoggedInServices.Tests
{
    public partial class LoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        #endregion Properties

        #region Constructors
        public LoggedInServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> LoggedInServiceSetup(string culture, int ErrNumber = 0)
        {
            string appsettings = "appsettings_cssploggedinservicestests.json";

            if (ErrNumber == 2)
            {
                appsettings = "appsettings_cssploggedinservicestests_err1.json";
            }

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile(appsettings)
                .AddUserSecrets("88fc6657-c426-4796-95bb-ca3d0daf2ff0")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();

            if (ErrNumber != 2)
            {
                Assert.NotNull(Configuration["CSSPDB"]);
            }

            Assert.NotNull(Configuration["CSSPDBManage"]);

            if (ErrNumber != 1)
            {
                if (ErrNumber == 2)
                {
                    /* ---------------------------------------------------------------------------------
                     * using CSSPDB
                     * ---------------------------------------------------------------------------------      
                     */
                    Services.AddDbContext<CSSPDBContext>(options =>
                    {
                        options.UseSqlServer("Server=.\\sqlexpress;Database=CSSPDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                    });
                }
                else
                {
                    /* ---------------------------------------------------------------------------------
                     * using CSSPDB
                     * ---------------------------------------------------------------------------------      
                     */
                    Services.AddDbContext<CSSPDBContext>(options =>
                    {
                        options.UseSqlServer(Configuration["CSSPDB"]);
                    });
                }

                /* ---------------------------------------------------------------------------------
                 * CSSPDBManageContext
                 * ---------------------------------------------------------------------------------      
                 */

                FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
                Assert.True(fiCSSPDBManage.Exists);

                Services.AddDbContext<CSSPDBManageContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
                });
            }
            

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            if (ErrNumber == 1)
            {
                try
                {
                    LoggedInService = Provider.GetService<ILoggedInService>();
                    Assert.NotNull(LoggedInService);
                }
                catch (Exception ex)
                {
                    Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db && dbManage"), ex.Message);
                }
            }
            else if (ErrNumber == 2)
            {
                try
                {
                    LoggedInService = Provider.GetService<ILoggedInService>();
                    Assert.NotNull(LoggedInService);
                }
                catch (Exception ex)
                {
                    Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "LoggedInService"), ex.Message);
                }
            }
            else
            {
                    LoggedInService = Provider.GetService<ILoggedInService>();
                    Assert.NotNull(LoggedInService);
            }

            Assert.NotEmpty(Configuration["LoginEmail"]);
            Assert.NotEmpty(Configuration["FirstName1"]);
            Assert.NotEmpty(Configuration["Initial1"]);
            Assert.NotEmpty(Configuration["LastName1"]);
            Assert.NotEmpty(Configuration["LoginEmail3"]);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
