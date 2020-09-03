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

namespace LoggedInServices.Tests
{
    public partial class LoggedInServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private string Id { get; set; }
        private string FirstName1 { get; set; }
        private string Initial1 { get; set; }
        private string LastName1 { get; set; }
        private string Id2 { get; set; }
        private string FirstName2 { get; set; }
        private string LastName2 { get; set; }
        private string Id3 { get; set; }
        #endregion Properties

        #region Constructors
        public LoggedInServicesTests()
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
                .AddJsonFile("appsettings_loggedinservicestests.json")
                .AddUserSecrets("88fc6657-c426-4796-95bb-ca3d0daf2ff0")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<ILoggedInService, LoggedInService>();

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDB2");
            Assert.NotNull(CSSPDBConnString);

            ServiceCollection.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            ServiceCollection.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = ServiceProvider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            Id = Configuration.GetValue<string>("Id");
            Assert.NotEmpty(Id);

            FirstName1 = Configuration.GetValue<string>("FirstName1");
            Assert.NotEmpty(FirstName1);

            Initial1 = Configuration.GetValue<string>("Initial1");
            Assert.NotEmpty(Initial1);

            LastName1 = Configuration.GetValue<string>("LastName1");
            Assert.NotEmpty(LastName1);

            Id2 = Configuration.GetValue<string>("Id2");
            Assert.NotEmpty(Id2);

            FirstName2 = Configuration.GetValue<string>("FirstName2");
            Assert.NotEmpty(FirstName2);

            LastName2 = Configuration.GetValue<string>("LastName2");
            Assert.NotEmpty(LastName2);

            Id3 = Configuration.GetValue<string>("Id3");
            Assert.NotEmpty(Id3);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
