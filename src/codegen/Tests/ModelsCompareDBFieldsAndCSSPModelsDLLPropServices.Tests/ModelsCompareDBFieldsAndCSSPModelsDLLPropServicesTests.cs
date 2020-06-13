using ConfigServices.Services;
using CultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Tests
{
    public class ModelsCompareDBFieldsAndCSSPModelsDLLPropServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IModelsCompareDBFieldsAndCSSPModelsDLLPropService ModelsCompareDBFieldsAndCSSPModelsDLLPropService { get; set; }
        #endregion Properties

        #region Constructors
        public ModelsCompareDBFieldsAndCSSPModelsDLLPropServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task ModelsCompareDBFieldsAndCSSPModelsDLLPropService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ModelsCompareDBFieldsAndCSSPModelsDLLPropService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await ModelsCompareDBFieldsAndCSSPModelsDLLPropService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task ModelsCompareDBFieldsAndCSSPModelsDLLPropService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ModelsCompareDBFieldsAndCSSPModelsDLLPropService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await ModelsCompareDBFieldsAndCSSPModelsDLLPropService.Run(args));
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

            Services.AddSingleton<IModelsCompareDBFieldsAndCSSPModelsDLLPropService, ModelsCompareDBFieldsAndCSSPModelsDLLPropService>();

            Assert.True(await BuildServiceProvider());

            ModelsCompareDBFieldsAndCSSPModelsDLLPropService = Provider.GetService<IModelsCompareDBFieldsAndCSSPModelsDLLPropService>();
            Assert.NotNull(ModelsCompareDBFieldsAndCSSPModelsDLLPropService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
