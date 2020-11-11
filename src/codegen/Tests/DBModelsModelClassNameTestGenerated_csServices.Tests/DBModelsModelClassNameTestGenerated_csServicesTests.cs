using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DBModelsModelClassNameTestGenerated_csServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DBModelsModelClassNameTestGenerated_csServices.Tests
{
    public class DBModelsModelClassNameTestGenerated_csServiceTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDBModelsModelClassNameTestGenerated_csService DBModelsModelClassNameTestGenerated_csService { get; set; }
        #endregion Properties

        #region Constructors
        public DBModelsModelClassNameTestGenerated_csServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task DBModelsModelClassNameTestGenerated_csService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(DBModelsModelClassNameTestGenerated_csService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await DBModelsModelClassNameTestGenerated_csService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task DBModelsModelClassNameTestGenerated_csService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(DBModelsModelClassNameTestGenerated_csService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await DBModelsModelClassNameTestGenerated_csService.Run(args));
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

            Services.AddSingleton<IDBModelsModelClassNameTestGenerated_csService, DBModelsModelClassNameTestGenerated_csService>();

            Assert.True(await BuildServiceProvider());

            DBModelsModelClassNameTestGenerated_csService = Provider.GetService<IDBModelsModelClassNameTestGenerated_csService>();
            Assert.NotNull(DBModelsModelClassNameTestGenerated_csService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
