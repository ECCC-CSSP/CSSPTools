using AngularEnumsGeneratedServices.Services;
using ConfigServices.Services;
using CSSPEnums;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AngularEnumsGeneratedServices.Tests
{
    public class AngularEnumsGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        IAngularEnumsGeneratedService AngularEnumsGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public AngularEnumsGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task AngularEnumsGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(AngularEnumsGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await AngularEnumsGeneratedService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task AngularEnumsGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(culture, "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(AngularEnumsGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await AngularEnumsGeneratedService.Run(args));
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture, string appsettingjsonFileName)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettingjsonFileName)
               .Build();

            Services = new ServiceCollection();
            Assert.True(await ConfigureBaseServices());

            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAngularEnumsGeneratedService, AngularEnumsGeneratedService>();

            Assert.True(await BuildServiceProvider());

            CSSPCultureService.SetCulture(culture);

            AngularEnumsGeneratedService = Provider.GetService<IAngularEnumsGeneratedService>();
            Assert.NotNull(AngularEnumsGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
