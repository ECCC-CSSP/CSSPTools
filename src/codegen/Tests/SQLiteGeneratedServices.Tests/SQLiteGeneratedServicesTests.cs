using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GenerateCSSPSQLiteServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace SQLiteGeneratedServices.Tests
{
    public class SQLiteGeneratedServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ISQLiteGeneratedService SQLiteGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public SQLiteGeneratedServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task SQLiteGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(SQLiteGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await SQLiteGeneratedService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task SQLiteGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(SQLiteGeneratedService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await SQLiteGeneratedService.Run(args));
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

            Services.AddSingleton<ISQLiteGeneratedService, SQLiteGeneratedService>();

            Assert.True(await BuildServiceProvider());

            SQLiteGeneratedService = Provider.GetService<ISQLiteGeneratedService>();
            Assert.NotNull(SQLiteGeneratedService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
