using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace CSSPCultureServices.Tests
{
    public partial class CultureServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
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

             
            CSSPCultureService.SetCulture(culture);

            Assert.Equal(new CultureInfo(culture), CSSPCultureEnumsRes.Culture);
            Assert.Equal(new CultureInfo(culture), CSSPCultureModelsRes.Culture);
            Assert.Equal(new CultureInfo(culture), CSSPCulturePolSourcesRes.Culture);
            Assert.Equal(new CultureInfo(culture), CSSPCultureServicesRes.Culture);
        }
        [Theory]
        [InlineData("en-US")]
        [InlineData("fr-FR")]
        public async Task SetCulture_Unsuported_Culture_Should_Default_To_en_CA_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPCultureService.SetCulture(culture);

            Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureEnumsRes.Culture);
            Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureModelsRes.Culture);
            Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCulturePolSourcesRes.Culture);
            Assert.Equal(new CultureInfo(CSSPCultureService.AllowableCultures[0]), CSSPCultureServicesRes.Culture);
        }
        #endregion Tests Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            ServiceCollection Services = new ServiceCollection();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();

            IServiceProvider Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
