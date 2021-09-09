using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;
using CSSPCultureServices.Resources;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FileServices.Tests
{
    //[Collection("Sequential")]
    public partial class FileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllCountries_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllCountries;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllEmails;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllProvinces_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllProvinces;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTels;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebArea_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSites;
            int TVItemID = 7;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;

            // Download gz
            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebDrogueRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;
            int TVItemID = 7;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
            int TVItemID = 7;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebLabSheet_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebLabSheets;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMikeScenarios_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            int TVItemID = 27764;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMonitoringOtherStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;
            int TVItemID = 5;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMonitoringOtherStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;
            int TVItemID = 7;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;
            int TVItemID = 5;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;
            int TVItemID = 7;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 27764;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMWQMRuns_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMWQMSamples1980_2020_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMWQMSamples2021_2060_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory(Skip = "WebTideSite does not yet have items")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebTideSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideSites;
            int TVItemID = 635;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_WebNNNNNN_Unauthorized_Error_Test(string culture)
        {
            List<WebTypeEnum> webTypeList = GetWebTypeList();

            foreach (WebTypeEnum webTypeToTry in webTypeList)
            {
                Assert.True(await Setup(culture));

                LoggedInService.LoggedInContactInfo = null;

                WebTypeEnum webType = webTypeToTry;

                var actionRes = await FileService.DownloadGzFile(webType);
                Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
                var ValidationResultList = (List<ValidationResult>)((UnauthorizedObjectResult)actionRes.Result).Value;
                Assert.NotNull(ValidationResultList);

                Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_AzureStore_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            config.AzureStore = "NotWorking" + config.AzureStore;

            await FileService.FillConfigModel(config);

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_AzureStoreCSSPJSONPath_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

            config.AzureStoreCSSPJSONPath = "notworking" + config.AzureStoreCSSPJSONPath;

            await FileService.FillConfigModel(config);

            var actionRes = await FileService.DownloadGzFile(webType);
            Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task FileService_DownloadGzFile_FileName_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 777777777;

            var actionRes = await FileService.DownloadGzFile(webType, TVItemID);
            Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionRes.Result).Value);
            var ValidationResultList = (List<ValidationResult>)((BadRequestObjectResult)actionRes.Result).Value;
            Assert.NotNull(ValidationResultList);

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
