//using CSSPEnums;
//using CSSPHelperModels;
//using CSSPWebModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace CSSPFileServices.Tests
//{
//    //[Collection("Sequential")]
//    public partial class FileServiceTests
//    {
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllAddresses_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            int TVItemID = 0;
//            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());


//            var actionRes2 = await CSSPReadGzFileService.ReadJSON<WebAllAddresses>(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
//            Assert.NotNull((WebAllAddresses)((OkObjectResult)actionRes2.Result).Value);

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllContacts_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllContacts;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllCountries_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllCountries;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllEmails_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllEmails;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllHelpDocs_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllMunicipalities_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllMWQMLookupMPNs_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllPolSourceGroupings_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllProvinces_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllProvinces;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllReportTypes_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllTels_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllTels;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebAllTideLocations_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebArea_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebArea;
//            int TVItemID = 629;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebClimateSite_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebClimateSites;
//            int TVItemID = 7;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebCountry_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebCountry;
//            int TVItemID = 5;

//            // Download gz
//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebDrogueRuns_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;
//            int TVItemID = 7;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebHydrometricSite_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
//            int TVItemID = 7;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebLabSheet_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebLabSheets;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMikeScenarios_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
//            int TVItemID = 27764;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMonitoringOtherStatsCountry_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;
//            int TVItemID = 5;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMonitoringOtherStatsProvince_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;
//            int TVItemID = 7;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;
//            int TVItemID = 5;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;
//            int TVItemID = 7;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMunicipality_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
//            int TVItemID = 27764;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMWQMRuns_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMWQMSamples1980_2020_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
//            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMWQMSamples2021_2060_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());
            
//            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebMWQMSite_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebPolSourceSite_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebProvince_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebProvince;
//            int TVItemID = 7;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebRoot_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebRoot;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebSector_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebSector;
//            int TVItemID = 633;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebSubsector_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebSubsector;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory(Skip = "WebTideSite does not yet have items")]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebTideSite_Good_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebTideSites;
//            int TVItemID = 635;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
//            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_WebNNNNNN_Unauthorized_Error_Test(string culture)
//        {
//            List<WebTypeEnum> webTypeList = GetWebTypeList();

//            foreach (WebTypeEnum webTypeToTry in webTypeList)
//            {
//                Assert.True(await CSSPFileServiceSetup(culture));

//                Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//                CSSPLocalLoggedInService.LoggedInContactInfo = null;

//                WebTypeEnum webType = webTypeToTry;

//                var actionRes = await CSSPFileService.DownloadGzFile(webType);
//                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
//                ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
//                Assert.NotEmpty(errRes.ErrList);

//                await CSSPLogService.Save();

//                Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//            }
//        }
//        [Theory(Skip = "Will need to rewrite this one")]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_AzureStore_Error_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

//            //config.AzureStore = "NotWorking" + config.AzureStore;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
//            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
//            Assert.NotEmpty(errRes.ErrList);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory(Skip = "Will need to rewrite this one")]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_AzureStoreCSSPJSONPath_Error_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

//            //config.AzureStoreCSSPJSONPath = "notworking" + config.AzureStoreCSSPJSONPath;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType);
//            Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
//            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
//            Assert.NotEmpty(errRes.ErrList);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task DownloadGzFile_FileName_Error_Test(string culture)
//        {
//            Assert.True(await CSSPFileServiceSetup(culture));

//            Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

//            WebTypeEnum webType = WebTypeEnum.WebProvince;
//            int TVItemID = 777777777;

//            var actionRes = await CSSPFileService.DownloadGzFile(webType, TVItemID);
//            Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
//            Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
//            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
//            Assert.NotEmpty(errRes.ErrList);

//            await CSSPLogService.Save();

//            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
//        }
//    }
//}