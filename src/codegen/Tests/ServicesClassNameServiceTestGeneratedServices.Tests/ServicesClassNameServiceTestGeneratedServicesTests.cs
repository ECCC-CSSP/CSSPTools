using CSSPDBModels;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceTestGeneratedServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAppSettingsServices.Services;
using CSSPCultureServices.Resources;
using ConfigServices.Services;

namespace ServicesClassNameServiceTestGeneratedServices.Tests
{
    public class ServicesClassNameServiceTestGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesClassNameServiceTestGeneratedService ServicesClassNameServiceTestGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesClassNameServiceTestGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task ServicesClassNameServiceTestGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesClassNameServiceTestGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await ServicesClassNameServiceTestGeneratedService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task ServicesClassNameServiceTestGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ServicesClassNameServiceTestGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await ServicesClassNameServiceTestGeneratedService.Run(args));
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

            Services.AddSingleton<IServicesClassNameServiceTestGeneratedService, ServicesClassNameServiceTestGeneratedService>();

            Assert.True(await BuildServiceProvider());

            ServicesClassNameServiceTestGeneratedService = Provider.GetService<IServicesClassNameServiceTestGeneratedService>();
            Assert.NotNull(ServicesClassNameServiceTestGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
