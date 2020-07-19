using ConfigServices.Services;
using CSSPEnums;
using CSSPCultureServices.Resources;
using EnumsGenerated_csServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace EnumsGenerated_csServices.Tests
{
    public class EnumsGenerated_csServiceTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsGenerated_csService EnumsGenerated_csService { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsGenerated_csServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task EnumsGenerated_csService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsGenerated_csService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await EnumsGenerated_csService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task EnumsGenerated_csService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsGenerated_csService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await EnumsGenerated_csService.Run(args));
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

            Services.AddSingleton<IEnumsGenerated_csService, EnumsGenerated_csService>();

            Assert.True(await BuildServiceProvider());

            EnumsGenerated_csService = Provider.GetService<IEnumsGenerated_csService>();
            Assert.NotNull(EnumsGenerated_csService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
