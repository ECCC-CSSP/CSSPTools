using ConfigServices.Services;
using CSSPCultureServices.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DBModelsModelClassNameTestServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DBModelsModelClassNameTestServices.Tests
{
    public class DBModelsModelClassNameTestServicesTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IDBModelsModelClassNameTestService DBModelsModelClassNameTestService { get; set; }
        #endregion Properties

        #region Constructors
        public DBModelsModelClassNameTestServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task DBModelsModelClassNameTestService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(DBModelsModelClassNameTestService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await DBModelsModelClassNameTestService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task DBModelsModelClassNameTestService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(DBModelsModelClassNameTestService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await DBModelsModelClassNameTestService.Run(args));
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

            Services.AddSingleton<IDBModelsModelClassNameTestService, DBModelsModelClassNameTestService>();

            Assert.True(await BuildServiceProvider());

            DBModelsModelClassNameTestService = Provider.GetService<IDBModelsModelClassNameTestService>();
            Assert.NotNull(DBModelsModelClassNameTestService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
