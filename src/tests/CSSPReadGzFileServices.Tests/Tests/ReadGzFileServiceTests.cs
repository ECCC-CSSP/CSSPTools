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
    [Collection("Sequential")]
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
        public async Task ReadGzFileService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebArea>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebArea webArea = (WebArea)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webArea);
            Assert.NotNull(webArea.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebClimateDataValue>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebClimateDataValue webClimateDataValue = (WebClimateDataValue)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webClimateDataValue);
            Assert.NotNull(webClimateDataValue.ClimateDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebClimateSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebClimateSite webClimateSite = (WebClimateSite)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webClimateSite);
            Assert.NotNull(webClimateSite.ClimateSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllContacts_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllContacts;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllContacts>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllContacts webAllContacts = (WebAllContacts)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllContacts);
            Assert.NotNull(webAllContacts.ContactList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllAddresses_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllAddresses>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllAddresses WebAllAddresses = (WebAllAddresses)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(WebAllAddresses);
            Assert.NotNull(WebAllAddresses.AddressList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllEmails_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllEmails;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllEmails>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllEmails WebAllEmails = (WebAllEmails)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(WebAllEmails);
            Assert.NotNull(WebAllEmails.EmailList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTels_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTels;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllTels>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTels WebAllTels = (WebAllTels)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(WebAllTels);
            Assert.NotNull(WebAllTels.TelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebCountry>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebCountry webCountry = (WebCountry)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebDrogueRun>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebDrogueRun webDrogueRun = (WebDrogueRun)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webDrogueRun);
            Assert.NotNull(webDrogueRun.DrogueRunList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllHelpDocs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllHelpDocs>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllHelpDocs webAllHelpDocs = (WebAllHelpDocs)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllHelpDocs);
            Assert.NotNull(webAllHelpDocs.HelpDocList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebHydrometricDataValue>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebHydrometricDataValue webHydrometricDataValue = (WebHydrometricDataValue)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webHydrometricDataValue);
            Assert.NotNull(webHydrometricDataValue.HydrometricDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebHydrometricSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebHydrometricSite webHydrometricSite = (WebHydrometricSite)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webHydrometricSite);
            Assert.NotNull(webHydrometricSite.HydrometricSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMikeScenario>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMikeScenario webMikeScenario = (WebMikeScenario)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMikeScenario);
            Assert.NotNull(webMikeScenario.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMunicipalities>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMunicipalities webMunicipalities = (WebMunicipalities)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMunicipalities);
            Assert.NotNull(webMunicipalities.TVItemMunicipalityList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMunicipality>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMunicipality webMunicipality = (WebMunicipality)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMunicipality);
            Assert.NotNull(webMunicipality.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllMWQMLookupMPNs_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllMWQMLookupMPNs>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = (WebAllMWQMLookupMPNs)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllMWQMLookupMPNs);
            Assert.NotNull(webAllMWQMLookupMPNs.MWQMLookupMPNList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMRun>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMRun webMWQMRun = (WebMWQMRun)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMRun);
            Assert.NotNull(webMWQMRun.MWQMRunModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample1990_1999FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2000_2009FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2010_2019FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2020_2029FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2030_2039FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2040_2049FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWeb10YearOfSample2050_2059FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMSite webMWQMSite = (WebMWQMSite)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMSite);
            Assert.NotNull(webMWQMSite.MWQMSiteModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllPolSourceGroupings_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllPolSourceGroupings>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllPolSourceGroupings webAllPolSourceGroupings = (WebAllPolSourceGroupings)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllPolSourceGroupings);
            Assert.NotNull(webAllPolSourceGroupings.PolSourceGroupingList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebPolSourceSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebPolSourceSite webPolSourceSite = (WebPolSourceSite)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webPolSourceSite);
            Assert.NotNull(webPolSourceSite.PolSourceSiteModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllPolSourceSiteEffectTerms>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = (WebAllPolSourceSiteEffectTerms)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllPolSourceSiteEffectTerms);
            Assert.NotNull(webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebProvince>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebProvince webProvince = (WebProvince)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webProvince);
            Assert.NotNull(webProvince.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllReportTypes_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllReportTypes>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllReportTypes webAllReportTypes = (WebAllReportTypes)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllReportTypes);
            Assert.NotNull(webAllReportTypes.ReportTypeModelList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            var actionRes = await ReadGzFileService.ReadJSON<WebRoot>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebRoot webRoot = (WebRoot)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8; // TVItemID is SamplingPlanID in this case
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebSamplingPlan>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebSamplingPlan webSamplingPlan = (WebSamplingPlan)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webSamplingPlan);
            Assert.NotNull(webSamplingPlan.SamplingPlanModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebSector>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebSector webSector = (WebSector)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webSector);
            Assert.NotNull(webSector.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebSubsector>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebSubsector webSubsector = (WebSubsector)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webSubsector);
            Assert.NotNull(webSubsector.TVItemModel);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTideLocations_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllTideLocations>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTideLocations webAllTideLocations = (WebAllTideLocations)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webAllTideLocations);
            Assert.NotNull(webAllTideLocations.TideLocationList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTVItems_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItems;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllTVItems>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTVItems webWebAllTVItems = (WebAllTVItems)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webWebAllTVItems);
            Assert.NotNull(webWebAllTVItems.TVItemList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTVItemLanguages_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguages;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllTVItemLanguages>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTVItemLanguages webWebAllTVItemLanguages = (WebAllTVItemLanguages)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webWebAllTVItemLanguages);
            Assert.NotNull(webWebAllTVItemLanguages.TVItemLanguageList);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
