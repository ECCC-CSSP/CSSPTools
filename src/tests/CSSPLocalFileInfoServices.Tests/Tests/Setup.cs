using CSSPLocalFileInfoServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace LocalFileInfoServices.Tests
{
    public partial class LocalFileInfoServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ILocalFileInfoService LocalFileInfoService { get; set; }
        private string CSSPFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public LocalFileInfoServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_cssplocalfileinfoservicestests.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ILocalFileInfoService, LocalFileInfoService>();

            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
            Assert.NotNull(CSSPFilesPath);

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            LocalFileInfoService = Provider.GetService<ILocalFileInfoService>();
            Assert.NotNull(LocalFileInfoService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
