using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesRepopulateTestDBServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ServicesRepopulateTestDBServices.Tests
{
    public class ServicesRepopulateTestDBServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesRepopulateTestDBService ServicesRepopulateTestDBService { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesRepopulateTestDBServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        ////[InlineData("fr-CA")] // good
        ////[InlineData("en-GB")] // good will default to en-CA
        public async Task ServicesRepopulateTestDBService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesRepopulateTestDBService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await ServicesRepopulateTestDBService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        ////[InlineData("fr-CA")] // good
        public async Task IServicesRepopulateTestDBService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesRepopulateTestDBService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await ServicesRepopulateTestDBService.Run(args));
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture, string appsettingjsonFileName)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettingjsonFileName)
               .Build();

            Services = new ServiceCollection();
            Assert.True(await ConfigureBaseServices());

            Assert.True(await ConfigureCSSPDBContext());

            Assert.True(await ConfigureTestDBContext());

            Services.AddSingleton<IServicesRepopulateTestDBService, ServicesRepopulateTestDBService>();

            Assert.True(await BuildServiceProvider());

            ServicesRepopulateTestDBService = Provider.GetService<IServicesRepopulateTestDBService>();
            Assert.NotNull(ServicesRepopulateTestDBService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
