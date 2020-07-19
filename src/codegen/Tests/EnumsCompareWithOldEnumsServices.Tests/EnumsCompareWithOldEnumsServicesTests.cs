using ConfigServices.Services;
using CSSPCultureServices.Resources;
using EnumsCompareWithOldEnumsServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace EnumsCompareWithOldEnumsServices.Tests
{
    public class EnumsCompareWithOldEnumsServiceTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsCompareWithOldEnumsService EnumsCompareWithOldEnumsService { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task EnumsCompareWithOldEnumsService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsCompareWithOldEnumsService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await EnumsCompareWithOldEnumsService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task EnumsCompareWithOldEnumsService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsCompareWithOldEnumsService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await EnumsCompareWithOldEnumsService.Run(args));
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

            Services.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();

            Assert.True(await BuildServiceProvider());

            EnumsCompareWithOldEnumsService = Provider.GetService<IEnumsCompareWithOldEnumsService>();
            Assert.NotNull(EnumsCompareWithOldEnumsService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
