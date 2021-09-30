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

namespace CSSPServerLoggedInServices.Tests
{
    public partial class CSSPServerLoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPServerLoggedInServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CSSPServerLoggedInServiceSetup(string culture, int ErrNumber = 0)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspserverloggedinservicestests.json")
                .AddUserSecrets("88fc6657-c426-4796-95bb-ca3d0daf2ff0")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();

            Assert.NotNull(Configuration["CSSPDB"]);

            /* ---------------------------------------------------------------------------------
             * using CSSPDB
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["CSSPDB"]);
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPServerLoggedInService = Provider.GetService<ICSSPServerLoggedInService>();
            Assert.NotNull(CSSPServerLoggedInService);

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
