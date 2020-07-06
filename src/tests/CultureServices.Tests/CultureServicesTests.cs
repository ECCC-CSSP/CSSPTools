using CultureServices.Resources;
using CultureServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace CultureServices.Tests
{
    public partial class CultureServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        #endregion Properties

        #region Constructors
        public CultureServicesTests()
        {
            
        }
        #endregion Constructors

        #region Tests Functions public

        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SetCulture_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

             
            CultureService.SetCulture(culture);

            Assert.Equal(new CultureInfo(culture), CultureEnumsRes.Culture);
            Assert.Equal(new CultureInfo(culture), CultureModelsRes.Culture);
            Assert.Equal(new CultureInfo(culture), CulturePolSourcesRes.Culture);
            Assert.Equal(new CultureInfo(culture), CultureServicesRes.Culture);
        }
        [Theory]
        [InlineData("en-US")]
        [InlineData("fr-FR")]
        public async Task SetCulture_Unsuported_Culture_Should_Default_To_en_CA_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CultureService.SetCulture(culture);

            Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CultureEnumsRes.Culture);
            Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CultureModelsRes.Culture);
            Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CulturePolSourcesRes.Culture);
            Assert.Equal(new CultureInfo(CultureService.AllowableCultures[0]), CultureServicesRes.Culture);
        }
        #endregion Tests Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            ServiceCollection Services = new ServiceCollection();

            Services.AddSingleton<ICultureService, CultureService>();

            IServiceProvider Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
