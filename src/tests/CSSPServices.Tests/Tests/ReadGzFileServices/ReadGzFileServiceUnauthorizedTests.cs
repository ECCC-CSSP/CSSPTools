using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class ReadGzFileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests Generated CRUD
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebArea_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebArea = await CreateGzFileService.CreateWebAreaGzFile(629);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebArea.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebClimateDataValue_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebClimateDataValue = await CreateGzFileService.CreateWebClimateDataValueGzFile(229465);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebClimateDataValue.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebClimateSite_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebClimateSite = await CreateGzFileService.CreateWebClimateSiteGzFile(7);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebClimateSite.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebContact_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebContact = await CreateGzFileService.CreateWebContactGzFile();
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebContact.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebCountry_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebCountry = await CreateGzFileService.CreateWebCountryGzFile(5);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebCountry.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebDrogueRun_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebDrogueRun = await CreateGzFileService.CreateWebDrogueRunGzFile(556);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebDrogueRun.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebHelpDoc_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebHelpDoc = await CreateGzFileService.CreateWebHelpDocGzFile();
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebHelpDoc.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebHydrometricDataValue_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebHydrometricDataValue = await CreateGzFileService.CreateWebHydrometricDataValueGzFile(51705);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebHydrometricDataValue.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebHydrometricSite_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebHydrometricSite = await CreateGzFileService.CreateWebHydrometricSiteGzFile(7);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebHydrometricSite.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebMikeScenario_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMikeScenario = await CreateGzFileService.CreateWebMikeScenarioGzFile(12281);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMikeScenario.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebMunicipalities_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMunicipalities = await CreateGzFileService.CreateWebMunicipalitiesGzFile(7);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMunicipalities.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebMunicipality_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMunicipality = await CreateGzFileService.CreateWebMunicipalityGzFile(12110);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMunicipality.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebMWQMLookupMPN_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMLookupMPN = await CreateGzFileService.CreateWebMWQMLookupMPNGzFile();
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMLookupMPN.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebMWQMRun_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMRun = await CreateGzFileService.CreateWebMWQMRunGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMRun.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample1980_1989FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample1990_1999FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample2000_2009FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample2010_2019FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample2020_2029FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample2030_2039FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2030_2039FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample2040_2049FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2040_2049FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWeb10YearOfSample2050_2059FromSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSample = await CreateGzFileService.CreateWeb10YearOfSample2050_2059FromSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebMWQMSite_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebMWQMSite = await CreateGzFileService.CreateWebMWQMSiteGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSite.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebPolSourceGrouping_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebPolSourceGrouping = await CreateGzFileService.CreateWebPolSourceGroupingGzFile();
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebPolSourceGrouping.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebPolSourceSite_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebPolSourceSite = await CreateGzFileService.CreateWebPolSourceSiteGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebPolSourceSite.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebProvince_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebProvince = await CreateGzFileService.CreateWebProvinceGzFile(7);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebProvince.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebReportType_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebReportType = await CreateGzFileService.CreateWebReportTypeGzFile();
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebReportType.Result).StatusCode);
        //}
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateWebRoot_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            WebRoot webRoot = await ReadGzFileService.ReadWebRootGzFile();
            Assert.NotNull(webRoot);
            Assert.Null(webRoot.TVItem);
        }
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebSamplingPlan_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebSamplingPlan = await CreateGzFileService.CreateWebSamplingPlanGzFile(8);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebSamplingPlan.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebSector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebSector = await CreateGzFileService.CreateWebSectorGzFile(633);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebSector.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebSubsector_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebSubsector = await CreateGzFileService.CreateWebSubsectorGzFile(635);
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebSubsector.Result).StatusCode);
        //}
        //[Theory]
        //[InlineData("en-CA")]
        //[InlineData("fr-CA")]
        //public async Task CreateWebTideLocation_Unauthorized_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

        //    var actionWebTideLocation = await CreateGzFileService.CreateWebTideLocationGzFile();
        //    Assert.Equal(401, ((UnauthorizedResult)actionWebTideLocation.Result).StatusCode);
        //}
        #endregion Tests Generated CRUD

        #region Functions private
        #endregion Functions private
    }
}
