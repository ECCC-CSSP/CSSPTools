using CSSPModels;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceGeneratedServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAppSettingsServices.Services;
using CultureServices.Resources;
using ConfigServices.Services;

namespace ServicesClassNameServiceGeneratedServices.Tests
{
    public class ServicesClassNameServiceGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesClassNameServiceGeneratedService ServicesClassNameServiceGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesClassNameServiceGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("en-GB")] // good will default to en-CA
        public async Task IServicesClassNameServiceGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesClassNameServiceGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await ServicesClassNameServiceGeneratedService.Run(args));

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
        public async Task ServicesClassNameServiceGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesClassNameServiceGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await ServicesClassNameServiceGeneratedService.Run(args));
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

            Services.AddSingleton<IServicesClassNameServiceGeneratedService, ServicesClassNameServiceGeneratedService>();

            Assert.True(await BuildServiceProvider());

            ServicesClassNameServiceGeneratedService = Provider.GetService<IServicesClassNameServiceGeneratedService>();
            Assert.NotNull(ServicesClassNameServiceGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
