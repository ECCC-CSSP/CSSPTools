using ActionCommandDBServices.Services;
using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ConfigServices.Tests
{
    public class ConfigServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        IConfigService ConfigService { get; set; }
        public IConfiguration Config { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }
        public IActionCommandDBService ActionCommandDBService { get; set; }
        public string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public ConfigServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("en-GB")] // good will default to en-CA
        public async Task ConfigService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            //Assert.NotNull(Services);
            //Assert.NotNull(Provider);
            Assert.NotNull(ConfigService);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture, string appsettingjsonFileName)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettingjsonFileName)
               .Build();

            ConfigService = new ConfigService(Config);

            //Services = new ServiceCollection();

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
