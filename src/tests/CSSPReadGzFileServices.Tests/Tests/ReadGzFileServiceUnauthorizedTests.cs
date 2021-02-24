using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;

namespace ReadGzFileServices.Tests
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

        #region Tests 
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebArea_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebArea>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebClimateDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebClimateDataValue>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebClimateSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebClimateSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebContact_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebContact;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebContact>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebCountry_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebCountry>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebDrogueRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebDrogueRun>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebHelpDoc_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebHelpDoc;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebHelpDoc>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebHydrometricDataValue_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebHydrometricDataValue>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebHydrometricSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebHydrometricSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMikeScenario_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMikeScenario>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMunicipalities_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMunicipalities>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMunicipality_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMunicipality>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMWQMLookupMPN_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMLookupMPN;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMLookupMPN>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMWQMRun_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMRun>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample1980_1989FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample1990_1999FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2000_2009FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2010_2019FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2020_2029FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2030_2039FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2040_2049FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2050_2059FromSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMWQMSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebMWQMSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebPolSourceGrouping_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebPolSourceGrouping;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebPolSourceGrouping>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebPolSourceSite_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebPolSourceSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebPolSourceSiteEffectTerm_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSiteEffectTerm;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebPolSourceSiteEffectTerm>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebProvince_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebProvince>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebReportType_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebReportType;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebReportType>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebRoot_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebRoot>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebSamplingPlan_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8; // which is SamplingPlanID in reality
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebSamplingPlan>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebSector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebSector>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebSubsector_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebSubsector>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebTideLocation_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebTideLocation;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebTideLocation>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTVItem_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllTVItem;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebAllTVItem>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTVItemLanguage_Unauthorized_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguage;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionWeb = await ReadGzFileService.ReadJSON<WebAllTVItemLanguage>(webType, TVItemID, webTypeYear);
            Assert.Equal(401, ((UnauthorizedResult)actionWeb.Result).StatusCode);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
