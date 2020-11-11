using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DBModelsCompareServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DBModelsCompareServices.Tests
{
    public class DBModelsCompareServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDBModelsCompareService DBModelsCompareService { get; set; }
        #endregion Properties

        #region Constructors
        public DBModelsCompareServicesTests()
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
            Assert.NotNull(DBModelsCompareService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await DBModelsCompareService.Run(args));
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
            Assert.NotNull(DBModelsCompareService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await DBModelsCompareService.Run(args));
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

            Services.AddSingleton<IDBModelsCompareService, DBModelsCompareService>();

            Assert.True(await BuildServiceProvider());

            DBModelsCompareService = Provider.GetService<IDBModelsCompareService>();
            Assert.NotNull(DBModelsCompareService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
