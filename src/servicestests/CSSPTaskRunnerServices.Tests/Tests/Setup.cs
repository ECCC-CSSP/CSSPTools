using CSSPScrambleServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ScrambleServices.Tests
{
    public partial class ScrambleServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private IScrambleService ScrambleService { get; set; }
        #endregion Properties

        #region Constructors
        public ScrambleServicesTests()
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
                .AddJsonFile("appsettings_csspscrambleServicestests.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<IScrambleService, ScrambleService>();


            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            ScrambleService = Provider.GetService<IScrambleService>();
            Assert.NotNull(ScrambleService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
