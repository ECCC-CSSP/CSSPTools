using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPWebServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebArea_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebAreaGzFile(629);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebClimateDataValueGzFile(229465);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebClimateSiteGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebContactGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebCountryGzFile(5);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebDrogueRunGzFile(556);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebHelpDocGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebHydrometricDataValueGzFile(51705);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebHydrometricSiteGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebMikeScenarioGzFile(12281);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebMunicipalitiesGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebMunicipalityGzFile(12110);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebMWQMLookupMPNGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebMWQMRunGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1990_1999FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2000_2009FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2010_2019FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2020_2029FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2030_2039FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2040_2049FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2050_2059FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebMWQMSiteGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebPolSourceGroupingGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebPolSourceSiteGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebProvinceGzFile(7);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebReportTypeGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebRootGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebSamplingPlanGzFile(8);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebSectorGzFile(633);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebSubsectorGzFile(635);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionRes = await CSSPWebService.CreateWebTideLocationGzFile();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
