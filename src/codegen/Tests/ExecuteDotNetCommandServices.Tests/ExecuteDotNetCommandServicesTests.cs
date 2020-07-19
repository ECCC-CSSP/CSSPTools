using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Services;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAppSettingsServices.Services;
using ConfigServices.Services;
using CSSPCultureServices.Resources;

namespace ExecuteDotNetCommandServices.Tests
{
    public partial class ExecuteDotNetCommandServiceTests : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IExecuteDotNetCommandService ExecuteDotNetCommandService { get; set; }
        #endregion Properties

        #region Constructors
        public ExecuteDotNetCommandServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task ExecuteDotNetCommandService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ExecuteDotNetCommandService);

            string[] args = new List<string>() { culture, "run", "AngularEnumsGenerated" }.ToArray();

            Assert.True(await ExecuteDotNetCommandService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        public async Task ExecuteDotNetCommandService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture), "appsettings_bad1.json"));

            Assert.NotNull(Config);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(ExecuteDotNetCommandService);

            string[] args = new List<string>() { culture, "run", "AngularEnumsGenerated" }.ToArray();

            Assert.False(await ExecuteDotNetCommandService.Run(args));
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

            Services.AddSingleton<IExecuteDotNetCommandService, ExecuteDotNetCommandService>();

            Assert.True(await BuildServiceProvider());

            ExecuteDotNetCommandService = Provider.GetService<IExecuteDotNetCommandService>();
            Assert.NotNull(ExecuteDotNetCommandService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
