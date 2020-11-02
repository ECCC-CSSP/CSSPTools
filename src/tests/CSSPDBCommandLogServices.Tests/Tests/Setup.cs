using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using LocalServices;

namespace CSSPDBCommandLogServices.Tests
{
    public partial class CSSPDBCommandLogServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBCommandLogService CSSPDBCommandLogService { get; set; }
        private ILocalService LocalService { get; set; }
        private string CSSPDBCommandLogFileName { get; set; }
        private string CSSPDBLoginFileName { get; set; }
        private string Id { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBCommandLogServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdbcommandlogservicestests.json")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<ILocalService, LocalService>();
            ServiceCollection.AddSingleton<ICSSPDBCommandLogService, CSSPDBCommandLogService>();

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLogin
             * ---------------------------------------------------------------------------------      
             */
            CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);
            Assert.True(fiCSSPDBLogin.Exists);

            ServiceCollection.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLoginInMemory
             * ---------------------------------------------------------------------------------      
             */

            ServiceCollection.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            CSSPDBCommandLogFileName = Configuration.GetValue<string>("CSSPDBCommandLog");
            Assert.NotNull(CSSPDBCommandLogFileName);

            FileInfo fiCSSPDBCommandLogFileName = new FileInfo(CSSPDBCommandLogFileName);
            Assert.True(fiCSSPDBCommandLogFileName.Exists);

            ServiceCollection.AddDbContext<CSSPDBCommandLogContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBCommandLogFileName.FullName }");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPDBCommandLogService = ServiceProvider.GetService<ICSSPDBCommandLogService>();
            Assert.NotNull(CSSPDBCommandLogService);

            LocalService = ServiceProvider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            await LocalService.SetLoggedInContactInfo();
            Assert.NotNull(LocalService.LoggedInContactInfo);
            Assert.NotNull(LocalService.LoggedInContactInfo.LoggedInContact);


            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
