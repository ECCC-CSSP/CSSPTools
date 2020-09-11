/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIsLocal.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace EmptyControllers.Tests
{
    public partial class EmptyControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        #endregion Properties

        #region Constructors
        public EmptyControllerTests()
        {
        }
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task EmptyController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
        }
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapislocaltests.json")
               .AddUserSecrets("61f396b6-8b79-4328-a2b7-a07921135f96")
               .Build();

            Services = new ServiceCollection();


            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
