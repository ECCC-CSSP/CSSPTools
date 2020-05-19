using ActionCommandDBServices.Services;
using BaseCodeGenerateServices.Services;
using ConfigServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using Xunit;

namespace BaseCodeGenerateServices.Tests
{
    public class BaseCodeGenerateServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        IBaseCodeGenerateService BaseCodeGenerateService { get; set; }
        public IConfiguration Config { get; set; }
        public IActionCommandDBService ActionCommandDBService { get; set; }
        public IGenerateCodeBaseService GenerateCodeBaseService { get; set; }
        public IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        public List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private string ActionParameterText = "Action";
        private string CommandParameterText = "Command";
        #endregion Properties

        #region Constructors
        public BaseCodeGenerateServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        [InlineData("fr-CA")] // good
        [InlineData("en-GB")] // good will default to en-CA
        public async Task BaseCodeGenerateService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            //Assert.NotNull(Services);
            //Assert.NotNull(Provider);
            Assert.NotNull(BaseCodeGenerateService);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture, string appsettingjsonFileName)
        {          
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettingjsonFileName)
               .Build();

            BaseCodeGenerateService = new BaseCodeGenerateService(Config);

            //Services = new ServiceCollection();

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
