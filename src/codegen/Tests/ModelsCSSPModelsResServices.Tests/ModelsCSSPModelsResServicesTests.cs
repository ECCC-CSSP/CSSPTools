using ConfigServices.Services;
using CultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelsCSSPModelsResServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ModelsCSSPModelsResServices.Tests
{
    public class ModelsCSSPModelsResServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IModelsCSSPModelsResService ModelsCSSPModelsResService { get; set; }
        #endregion Properties

        #region Constructors
        public ModelsCSSPModelsResServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task ModelsCSSPModelsResService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ModelsCSSPModelsResService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await ModelsCSSPModelsResService.Run(args));
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

            Services.AddSingleton<IModelsCSSPModelsResService, ModelsCSSPModelsResService>();

            Assert.True(await BuildServiceProvider());

            ModelsCSSPModelsResService = Provider.GetService<IModelsCSSPModelsResService>();
            Assert.NotNull(ModelsCSSPModelsResService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
