using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropServices.Tests
{
    public class DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService { get; set; }
        #endregion Properties

        #region Constructors
        public DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService.Run(args));
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

            Services.AddSingleton<IDBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService, DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService>();

            Assert.True(await BuildServiceProvider());

            DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService = Provider.GetService<IDBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService>();
            Assert.NotNull(DBModelsCompareDBFieldsAndCSSPDBModelsDLLPropService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
