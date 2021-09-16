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
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllAddresses>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllContacts>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllCountries;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllCountries>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllEmails;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllEmails>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllMWQMLookupMPNs>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceGroupings>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllPolSourceSiteEffectTerms>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllProvinces;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllProvinces>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllReportTypes>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTels;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllTels>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebAllTideLocations>(webType);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebArea_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebArea>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSites;
            int TVItemID = 7;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebClimateSites>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebCountry_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebCountry>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
            int TVItemID = 7;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebHydrometricSites>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebLabSheet_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebLabSheets;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebLabSheets>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            int TVItemID = 27764;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMikeScenarios>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 27764;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMunicipality>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMRuns>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMSamples1980_2020(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMSamples2021_2060(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSamples>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebMWQMSites>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebPolSourceSites>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebProvince_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebProvince>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebRoot_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebRoot>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebSector_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebSector>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebSubsector>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
        [Theory(Skip = "WebTideSite does not yet have items")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetUncompressJSON_WebTideSite_Good_Test(string culture)
        {
            Assert.True(await ReadGzFileServiceSetup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideSites;
            int TVItemID = 635;

            var JSONRes = await ReadGzFileService.GetUncompressJSON<WebSubsector>(webType, TVItemID);
            Assert.NotNull(JSONRes);
        }
    }
}
