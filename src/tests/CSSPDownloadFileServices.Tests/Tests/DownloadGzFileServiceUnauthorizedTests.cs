using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using CSSPCultureServices.Resources;

namespace DownloadFileServices.Tests
{
    public partial class DownloadFileServiceTests
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
        //[InlineData("fr-CA")]
        public async Task DownloadWebArea_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebClimateDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebClimateSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllContacts_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebCountry_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebDrogueRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllHelpDocs_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebHydrometricDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebHydrometricSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebMikeScenario_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebMunicipalities_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebMunicipality_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllMWQMLookupMPNs_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebMWQMRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample1980_1989FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample1990_1999FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample2000_2009FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample2010_2019FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample2020_2029FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample2030_2039FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample2040_2049FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWeb10YearOfSample2050_2059FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebMWQMSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllPolSourceGroupings_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebPolSourceSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllPolSourceSiteEffectTerms_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebProvince_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllReportTypes_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebRoot_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebSamplingPlan_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8; // which is SamplingPlanID in reality
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebSector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllTideLocations_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllTVItems_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllTVItems;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DownloadWebAllTVItemLanguages_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguages;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Download gz
            var actionRes = await DownloadFileService.DownloadGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionRes.Result).Value);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
