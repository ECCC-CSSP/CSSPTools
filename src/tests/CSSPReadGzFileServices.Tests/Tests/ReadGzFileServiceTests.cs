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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebArea);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebClimateDataValue);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebClimateSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebContact;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebContact>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebContact webContact = (WebContact)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webContact);
            Assert.NotNull(webContact.ContactList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebContact);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebCountry);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebDrogueRun);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHelpDoc;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebHelpDoc>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebHelpDoc webHelpDoc = (WebHelpDoc)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webHelpDoc);
            Assert.NotNull(webHelpDoc.HelpDocList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebHelpDoc);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebHydrometricDataValue);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebHydrometricSite);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMikeScenario);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMunicipalities);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMunicipality);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMLookupMPN;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebMWQMLookupMPN>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebMWQMLookupMPN webMWQMLookupMPN = (WebMWQMLookupMPN)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webMWQMLookupMPN);
            Assert.NotNull(webMWQMLookupMPN.MWQMLookupMPNList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMLookupMPN);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMRun);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample1980_1989);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample1990_1999);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample2000_2009);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample2010_2019);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample2020_2029);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample2030_2039);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample2040_2049);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSample2050_2059);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebMWQMSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceGrouping;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebPolSourceGrouping>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebPolSourceGrouping webPolSourceGrouping = (WebPolSourceGrouping)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webPolSourceGrouping);
            Assert.NotNull(webPolSourceGrouping.PolSourceGroupingList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebPolSourceGrouping);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebPolSourceSite);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebPolSourceSiteEffectTerm_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSiteEffectTerm;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebPolSourceSiteEffectTerm>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebPolSourceSiteEffectTerm webPolSourceSiteEffectTerm = (WebPolSourceSiteEffectTerm)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webPolSourceSiteEffectTerm);
            Assert.NotNull(webPolSourceSiteEffectTerm.PolSourceSiteEffectTermList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebPolSourceSiteEffectTerm);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebProvince);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebReportType;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebReportType>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebReportType webReportType = (WebReportType)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webReportType);
            Assert.NotNull(webReportType.ReportTypeModelList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebReportType);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebRoot);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebSamplingPlan);
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
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebSector);
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
        public async Task ReadGzFileService_ReadWebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideLocation;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebTideLocation>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebTideLocation webTideLocation = (WebTideLocation)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webTideLocation);
            Assert.NotNull(webTideLocation.TideLocationList);
            Assert.NotNull(WebAppLoadedService.webAppLoaded.WebTideLocation);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTVItem_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItem;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllTVItem>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTVItem webWebAllTVItem = (WebAllTVItem)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webWebAllTVItem);
            Assert.NotNull(webWebAllTVItem.TVItemList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReadGzFileService_ReadWebAllTVItemLanguage_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguage;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            // Read gz
            var actionRes = await ReadGzFileService.ReadJSON<WebAllTVItemLanguage>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            WebAllTVItemLanguage webWebAllTVItemLanguage = (WebAllTVItemLanguage)((OkObjectResult)actionRes.Result).Value;
            Assert.NotNull(webWebAllTVItemLanguage);
            Assert.NotNull(webWebAllTVItemLanguage.TVItemLanguageList);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
