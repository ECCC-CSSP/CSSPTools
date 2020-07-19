using ConfigServices.Services;
using CSSPCultureServices.Resources;
using EnumsTestGenerated_cs.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace EnumsTestGenerated_csServices.Tests
{
    public class EnumsTestGenerated_csServiceTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsTestGenerated_csService EnumsTestGenerated_csService { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsTestGenerated_csServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task EnumsTestGenerated_csService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsTestGenerated_csService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await EnumsTestGenerated_csService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task EnumsTestGenerated_csService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsTestGenerated_csService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await EnumsTestGenerated_csService.Run(args));
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

            Services.AddSingleton<IEnumsTestGenerated_csService, EnumsTestGenerated_csService>();

            Assert.True(await BuildServiceProvider());

            EnumsTestGenerated_csService = Provider.GetService<IEnumsTestGenerated_csService>();
            Assert.NotNull(EnumsTestGenerated_csService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
