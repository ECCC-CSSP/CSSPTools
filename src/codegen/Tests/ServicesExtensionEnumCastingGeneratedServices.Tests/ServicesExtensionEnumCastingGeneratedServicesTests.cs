using ConfigServices.Services;
using CultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceGeneratedServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ServicesClassNameServiceGeneratedServices.Tests
{
    public class ServicesExtensionEnumCastingGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesExtensionEnumCastingGeneratedService ServicesExtensionEnumCastingGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesExtensionEnumCastingGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("en-GB")] // good will default to en-CA
        public async Task IServicesExtensionEnumCastingGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesExtensionEnumCastingGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await ServicesExtensionEnumCastingGeneratedService.Run(args));

            // all culture other than "fr-CA" should default to "en-CA"
            if (culture != "fr-CA")
            {
                culture = "en-CA";
            }
            CultureInfo Culture = new CultureInfo(culture);
            Assert.Equal(Culture, CultureServicesRes.Culture);
        }
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        public async Task IServicesExtensionEnumCastingGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesExtensionEnumCastingGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await ServicesExtensionEnumCastingGeneratedService.Run(args));
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

            Services.AddSingleton<IServicesExtensionEnumCastingGeneratedService, ServicesExtensionEnumCastingGeneratedService>();

            Assert.True(await BuildServiceProvider());

            ServicesExtensionEnumCastingGeneratedService = Provider.GetService<IServicesExtensionEnumCastingGeneratedService>();
            Assert.NotNull(ServicesExtensionEnumCastingGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
