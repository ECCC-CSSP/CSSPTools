using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using WebAPIClassNameControllerTestGeneratedServices.Services;
using Xunit;

namespace WebAPIClassNameControllerTestGeneratedServices.Tests
{
    public class WebAPIClassNameControllerTestGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IWebAPIClassNameControllerTestGeneratedService WebAPIClassNameControllerTestGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public WebAPIClassNameControllerTestGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task IWebAPIClassNameControllerTestGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(WebAPIClassNameControllerTestGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await WebAPIClassNameControllerTestGeneratedService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task IWebAPIClassNameControllerTestGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(WebAPIClassNameControllerTestGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await WebAPIClassNameControllerTestGeneratedService.Run(args));
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

            Services.AddSingleton<IWebAPIClassNameControllerTestGeneratedService, WebAPIClassNameControllerTestGeneratedService>();

            Assert.True(await BuildServiceProvider());

            WebAPIClassNameControllerTestGeneratedService = Provider.GetService<IWebAPIClassNameControllerTestGeneratedService>();
            Assert.NotNull(WebAPIClassNameControllerTestGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
