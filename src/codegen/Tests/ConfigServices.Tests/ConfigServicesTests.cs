using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CSSPCultureServices.Services;
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
        private IConfiguration Configuration { get; set; }
        private IServiceProvider ServiceProvider { get; set; }
        private IServiceCollection ServiceCollection { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IConfigService ConfigService { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public ConfigServiceTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")] // good
        //[InlineData("fr-CA")] // good
        //[InlineData("en-GB")] // good will default to en-CA
        public async Task ConfigService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(ConfigService);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            ServiceCollection = new ServiceCollection();

            ServiceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceCollection.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            ServiceCollection.AddSingleton<IConfigService, ConfigService>();

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            Assert.NotNull(ServiceProvider);

            CSSPCultureService = ServiceProvider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ConfigService = ServiceProvider.GetService<IConfigService>();
            Assert.NotNull(ConfigService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }

}
