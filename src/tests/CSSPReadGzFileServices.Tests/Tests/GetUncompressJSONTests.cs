using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
        //see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebArea>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebClimateDataValue>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebClimateSite>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllContacts>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebCountry>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebDrogueRun>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebHydrometricDataValue>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMikeScenario>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMunicipalities>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMunicipality>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMRun>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample1990_1999FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample2000_2009FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample2010_2019FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample2020_2029FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample2030_2039FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample2040_2049FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWeb10YearOfSample2050_2059FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSite>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceGroupings>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceSiteEffectTerms>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebProvince>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllReportTypes>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebRoot>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8; // TVItemID is SamplingPlanID in this case
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebSamplingPlan>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebSector>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebSubsector>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllTideLocations>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllTVItems_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItems;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllTVItems>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_ReadWebAllTVItemLanguages_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguages;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read uncompress JSON
            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllTVItemLanguages>(webType, TVItemID, webTypeYear);
            Assert.NotNull(JSONRes);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
