using AzureStorageServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AzureStorageServices.Tests
{
    public class AzureStorageServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        public IConfiguration Configuration { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services{ get; set; }
        IAzureStorageService AzureStorageService { get; set; }
        #endregion Properties

        #region Constructors
        public AzureStorageServicesTests()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AngularModelsGeneratedService_Run_Good_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture)));

            Assert.NotNull(Configuration);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(AzureStorageService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.True(await AzureStorageService.Run(args));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AngularModelsGeneratedService_Run_SomeFileMissing_Test(string culture)
        {
            Assert.True(await Setup(new CultureInfo(culture)));

            Assert.NotNull(Configuration);
            Assert.NotNull(Services);
            Assert.NotNull(Provider);
            Assert.NotNull(AzureStorageService);

            string[] args = new List<string>() { culture }.ToArray();

            Assert.False(await AzureStorageService.Run(args));
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets<AzureStorageServicesTests>()
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<IAzureStorageService, AzureStorageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            AzureStorageService = Provider.GetService<IAzureStorageService>();
            Assert.NotNull(AzureStorageService);

            string connectionString = Configuration.GetValue<string>("ConnectionString");
            Assert.NotEmpty(connectionString);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
