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

namespace LocalServices.Tests
{
    public partial class LocalServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private string Id { get; set; }
        private string FirstName { get; set; }
        private string Initial { get; set; }
        private string LastName { get; set; }
        private string LoginEmail { get; set; }
        private string Password { get; set; }
        private string CSSPDBLoginFileName { get; set; }
        #endregion Properties

        #region Constructors
        public LocalServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_localservicestests.json")
                .AddUserSecrets("bbf8e532-7685-4d08-a552-9cb1b5482267")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<ILocalService, LocalService>();

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLogin
             * ---------------------------------------------------------------------------------      
             */
            CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

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

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = ServiceProvider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Id = Configuration.GetValue<string>("Id");
            Assert.NotEmpty(Id);

            FirstName = Configuration.GetValue<string>("FirstName");
            Assert.NotEmpty(FirstName);

            Initial = Configuration.GetValue<string>("Initial");
            Assert.NotEmpty(Initial);

            LastName = Configuration.GetValue<string>("LastName");
            Assert.NotEmpty(LastName);

            LoginEmail = Configuration.GetValue<string>("LoginEmail");
            Assert.NotEmpty(LoginEmail);

            Password = Configuration.GetValue<string>("Password");
            Assert.NotEmpty(Password);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}