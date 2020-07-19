using ConfigServices.Services;
using CSSPCultureServices.Resources;
using EnumsPolSourceInfoRelatedFilesServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace EnumsPolSourceInfoRelatedFilesServices.Tests
{
    public class EnumsPolSourceInfoRelatedFilesServiceTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsPolSourceInfoRelatedFilesService EnumsPolSourceInfoRelatedFilesService { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsPolSourceInfoRelatedFilesServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task EnumsPolSourceInfoRelatedFilesService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsPolSourceInfoRelatedFilesService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await EnumsPolSourceInfoRelatedFilesService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task EnumsPolSourceInfoRelatedFilesService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(EnumsPolSourceInfoRelatedFilesService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await EnumsPolSourceInfoRelatedFilesService.Run(args));
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

            Services.AddSingleton<IEnumsPolSourceInfoRelatedFilesService, EnumsPolSourceInfoRelatedFilesService>();
            Services.AddSingleton<IPolSourceGroupingExcelFileReadService, PolSourceGroupingExcelFileReadService>();

            Assert.True(await BuildServiceProvider());

            EnumsPolSourceInfoRelatedFilesService = Provider.GetService<IEnumsPolSourceInfoRelatedFilesService>();
            Assert.NotNull(EnumsPolSourceInfoRelatedFilesService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
