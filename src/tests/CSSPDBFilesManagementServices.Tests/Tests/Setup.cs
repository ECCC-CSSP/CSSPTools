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

namespace CSSPDBFilesManagementServices.Tests
{
    public partial class CSSPDBFilesManagementServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; set; }
        private ILocalService LocalService { get; set; }
        private string CSSPDBFilesManagementFileName { get; set; }
        private string CSSPDBLoginFileName { get; set; }
        private string Id { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBFilesManagementServicesTests()
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
                .AddJsonFile("appsettings_CSSPDBFilesManagementServicestests.json")
                .AddUserSecrets("27667b6d-6208-4074-be00-1041ba61f0c0")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<ILocalService, LocalService>();
            ServiceCollection.AddSingleton<ICSSPDBFilesManagementService, CSSPDBFilesManagementService>();

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

            CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagementFileName);

            FileInfo fiCSSPDBFilesManagementFileName = new FileInfo(CSSPDBFilesManagementFileName);
            Assert.True(fiCSSPDBFilesManagementFileName.Exists);

            ServiceCollection.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagementFileName.FullName }");
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPDBFilesManagementService = ServiceProvider.GetService<ICSSPDBFilesManagementService>();
            Assert.NotNull(CSSPDBFilesManagementService);

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
