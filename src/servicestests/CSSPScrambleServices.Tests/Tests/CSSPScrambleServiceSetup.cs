using CSSPScrambleServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPScrambleServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPScrambleServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPScrambleServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CSSPScrambleServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspscrambleservicestests.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();


            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            Assert.NotNull(CSSPScrambleService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
