using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class WebServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see Helpers.cs
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebArea_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebArea = await WebService.GetWebArea(629);
            Assert.Equal(401, ((UnauthorizedResult)actionWebArea.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebClimateDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebClimateDataValue = await WebService.GetWebClimateDataValue(229465);
            Assert.Equal(401, ((UnauthorizedResult)actionWebClimateDataValue.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebClimateSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebClimateSite = await WebService.GetWebClimateSite(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebClimateSite.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebContact_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebContact = await WebService.GetWebContact();
            Assert.Equal(401, ((UnauthorizedResult)actionWebContact.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebCountry_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebCountry = await WebService.GetWebCountry(5);
            Assert.Equal(401, ((UnauthorizedResult)actionWebCountry.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebDrogueRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebDrogueRun = await WebService.GetWebDrogueRun(556);
            Assert.Equal(401, ((UnauthorizedResult)actionWebDrogueRun.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebHelpDoc_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebHelpDoc = await WebService.GetWebHelpDoc();
            Assert.Equal(401, ((UnauthorizedResult)actionWebHelpDoc.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebHydrometricDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebHydrometricDataValue = await WebService.GetWebHydrometricDataValue(51705);
            Assert.Equal(401, ((UnauthorizedResult)actionWebHydrometricDataValue.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebHydrometricSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebHydrometricSite = await WebService.GetWebHydrometricSite(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebHydrometricSite.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMikeScenario_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMikeScenario = await WebService.GetWebMikeScenario(12281);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMikeScenario.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMunicipalities_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMunicipalities = await WebService.GetWebMunicipalities(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMunicipalities.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMunicipality_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMunicipality = await WebService.GetWebMunicipality(12110);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMunicipality.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMWQMLookupMPN_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMLookupMPN = await WebService.GetWebMWQMLookupMPN();
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMLookupMPN.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMWQMRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMRun = await WebService.GetWebMWQMRun(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMRun.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample1980_1989FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample1980_1989FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample1990_1999FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample1990_1999FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2000_2009FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2000_2009FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2010_2019FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2010_2019FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2020_2029FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2020_2029FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2030_2039FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2030_2039FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2040_2049FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2040_2049FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2050_2059FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2050_2059FromSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSample.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMWQMSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebMWQMSite = await WebService.GetWebMWQMSite(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebMWQMSite.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebPolSourceGrouping_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebPolSourceGrouping = await WebService.GetWebPolSourceGrouping();
            Assert.Equal(401, ((UnauthorizedResult)actionWebPolSourceGrouping.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebPolSourceSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebPolSourceSite = await WebService.GetWebPolSourceSite(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebPolSourceSite.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebProvince_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebProvince = await WebService.GetWebProvince(7);
            Assert.Equal(401, ((UnauthorizedResult)actionWebProvince.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebReportType_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebReportType = await WebService.GetWebReportType();
            Assert.Equal(401, ((UnauthorizedResult)actionWebReportType.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebRoot_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebRoot = await WebService.GetWebRoot();
            Assert.Equal(401, ((UnauthorizedResult)actionWebRoot.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebSamplingPlan_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebSamplingPlan = await WebService.GetWebSamplingPlan(8);
            Assert.Equal(401, ((UnauthorizedResult)actionWebSamplingPlan.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebSector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebSector = await WebService.GetWebSector(633);
            Assert.Equal(401, ((UnauthorizedResult)actionWebSector.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebSubsector = await WebService.GetWebSubsector(635);
            Assert.Equal(401, ((UnauthorizedResult)actionWebSubsector.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebTideLocation_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            await LoggedInService.SetLoggedInContactInfo("NotAnExistingId");

            var actionWebTideLocation = await WebService.GetWebTideLocation();
            Assert.Equal(401, ((UnauthorizedResult)actionWebTideLocation.Result).StatusCode);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        #endregion Functions private
    }
}
