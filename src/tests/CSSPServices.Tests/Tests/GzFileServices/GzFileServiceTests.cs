using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class GzFileServiceTests
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
        public async Task CreateWebAreaGzFile_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebArea;
            int TVItemID = 629;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebArea = await ReadGzFileService.ReadJSON<WebArea>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebArea.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebArea.Result).Value);
            WebArea webArea = ((WebArea)((OkObjectResult)actionWebArea.Result).Value);
            Assert.NotNull(webArea);
            Assert.NotNull(webArea.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
            int TVItemID = 229465;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebClimateDataValue = await ReadGzFileService.ReadJSON<WebClimateDataValue>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebClimateDataValue.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebClimateDataValue.Result).Value);
            WebClimateDataValue webClimateDataValue = ((WebClimateDataValue)((OkObjectResult)actionWebClimateDataValue.Result).Value);
            Assert.NotNull(webClimateDataValue);
            Assert.NotNull(webClimateDataValue.ClimateDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebClimateSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebClimateSite = await ReadGzFileService.ReadJSON<WebClimateSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebClimateSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebClimateSite.Result).Value);
            WebClimateSite webClimateSite = ((WebClimateSite)((OkObjectResult)actionWebClimateSite.Result).Value);
            Assert.NotNull(webClimateSite);
            Assert.NotNull(webClimateSite.TVItemList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebContact;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebContact = await ReadGzFileService.ReadJSON<WebContact>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebContact.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebContact.Result).Value);
            WebContact webContact = ((WebContact)((OkObjectResult)actionWebContact.Result).Value);
            Assert.NotNull(webContact);
            Assert.NotNull(webContact.ContactList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebCountry;
            int TVItemID = 5;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebCountry = await ReadGzFileService.ReadJSON<WebCountry>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebCountry.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebCountry.Result).Value);
            WebCountry webCountry = ((WebCountry)((OkObjectResult)actionWebCountry.Result).Value);
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItemLinkList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
            int TVItemID = 556;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebDrogueRun = await ReadGzFileService.ReadJSON<WebDrogueRun>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebDrogueRun.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebDrogueRun.Result).Value);
            WebDrogueRun webDrogueRun = ((WebDrogueRun)((OkObjectResult)actionWebDrogueRun.Result).Value);
            Assert.NotNull(webDrogueRun);
            Assert.NotNull(webDrogueRun.DrogueRunList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHelpDoc;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebHelpDoc = await ReadGzFileService.ReadJSON<WebHelpDoc>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebHelpDoc.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebHelpDoc.Result).Value);
            WebHelpDoc webHelpDoc = ((WebHelpDoc)((OkObjectResult)actionWebHelpDoc.Result).Value);
            Assert.NotNull(webHelpDoc);
            Assert.NotNull(webHelpDoc.HelpDocList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
            int TVItemID = 51705;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebHydrometricDataValue = await ReadGzFileService.ReadJSON<WebHydrometricDataValue>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebHydrometricDataValue.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebHydrometricDataValue.Result).Value);
            WebHydrometricDataValue webHydrometricDataValue = ((WebHydrometricDataValue)((OkObjectResult)actionWebHydrometricDataValue.Result).Value);
            Assert.NotNull(webHydrometricDataValue);
            Assert.NotNull(webHydrometricDataValue.HydrometricDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebHydrometricSite = await ReadGzFileService.ReadJSON<WebHydrometricSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebHydrometricSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebHydrometricSite.Result).Value);
            WebHydrometricSite webHydrometricSite = ((WebHydrometricSite)((OkObjectResult)actionWebHydrometricSite.Result).Value);
            Assert.NotNull(webHydrometricSite);
            Assert.NotNull(webHydrometricSite.HydrometricSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
            int TVItemID = 12281;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMikeScenario = await ReadGzFileService.ReadJSON<WebMikeScenario>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMikeScenario.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMikeScenario.Result).Value);
            WebMikeScenario webMikeScenario = ((WebMikeScenario)((OkObjectResult)actionWebMikeScenario.Result).Value);
            Assert.NotNull(webMikeScenario);
            Assert.NotNull(webMikeScenario.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMunicipalities = await ReadGzFileService.ReadJSON<WebMunicipalities>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMunicipalities.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMunicipalities.Result).Value);
            WebMunicipalities webMunicipalities = ((WebMunicipalities)((OkObjectResult)actionWebMunicipalities.Result).Value);
            Assert.NotNull(webMunicipalities);
            Assert.NotNull(webMunicipalities.TVItemList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            int TVItemID = 12110;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMunicipality = await ReadGzFileService.ReadJSON<WebMunicipality>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMunicipality.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMunicipality.Result).Value);
            WebMunicipality webMunicipality = ((WebMunicipality)((OkObjectResult)actionWebMunicipality.Result).Value);
            Assert.NotNull(webMunicipality);
            Assert.NotNull(webMunicipality.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMLookupMPN;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMLookupMPN = await ReadGzFileService.ReadJSON<WebMWQMLookupMPN>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMLookupMPN.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMLookupMPN.Result).Value);
            WebMWQMLookupMPN webMWQMLookupMPN = ((WebMWQMLookupMPN)((OkObjectResult)actionWebMWQMLookupMPN.Result).Value);
            Assert.NotNull(webMWQMLookupMPN);
            Assert.NotNull(webMWQMLookupMPN.MWQMLookupMPNList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMRun = await ReadGzFileService.ReadJSON<WebMWQMRun>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMRun.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMRun.Result).Value);
            WebMWQMRun webMWQMRun = ((WebMWQMRun)((OkObjectResult)actionWebMWQMRun.Result).Value);
            Assert.NotNull(webMWQMRun);
            Assert.NotNull(webMWQMRun.MWQMRunList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample1990_1999FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2000_2009FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2010_2019FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2020_2029FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2030_2039FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2040_2049FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWeb10YearOfSample2050_2059FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSample = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = ((WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebMWQMSite = await ReadGzFileService.ReadJSON<WebMWQMSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSite.Result).Value);
            WebMWQMSite webMWQMSite = ((WebMWQMSite)((OkObjectResult)actionWebMWQMSite.Result).Value);
            Assert.NotNull(webMWQMSite);
            Assert.NotNull(webMWQMSite.MWQMSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceGrouping;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebPolSourceGrouping = await ReadGzFileService.ReadJSON<WebPolSourceGrouping>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebPolSourceGrouping.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebPolSourceGrouping.Result).Value);
            WebPolSourceGrouping webPolSourceGrouping = ((WebPolSourceGrouping)((OkObjectResult)actionWebPolSourceGrouping.Result).Value);
            Assert.NotNull(webPolSourceGrouping);
            Assert.NotNull(webPolSourceGrouping.PolSourceGroupingList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebPolSourceSite = await ReadGzFileService.ReadJSON<WebPolSourceSite>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebPolSourceSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebPolSourceSite.Result).Value);
            WebPolSourceSite webPolSourceSite = ((WebPolSourceSite)((OkObjectResult)actionWebPolSourceSite.Result).Value);
            Assert.NotNull(webPolSourceSite);
            Assert.NotNull(webPolSourceSite.PolSourceSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebProvince;
            int TVItemID = 7;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebProvince = await ReadGzFileService.ReadJSON<WebProvince>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebProvince.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebProvince.Result).Value);
            WebProvince webProvince = ((WebProvince)((OkObjectResult)actionWebProvince.Result).Value);
            Assert.NotNull(webProvince);
            Assert.NotNull(webProvince.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebReportType;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebReportType = await ReadGzFileService.ReadJSON<WebReportType>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebReportType.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebReportType.Result).Value);
            WebReportType webReportType = ((WebReportType)((OkObjectResult)actionWebReportType.Result).Value);
            Assert.NotNull(webReportType);
            Assert.NotNull(webReportType.ReportTypeList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebRoot;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebRoot = await ReadGzFileService.ReadJSON<WebRoot>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebRoot.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebRoot.Result).Value);
            WebRoot webRoot = ((WebRoot)((OkObjectResult)actionWebRoot.Result).Value);
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
            int TVItemID = 8; // TVItemID is SamplingPlanID in this case
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebSamplingPlan = await ReadGzFileService.ReadJSON<WebSamplingPlan>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebSamplingPlan.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebSamplingPlan.Result).Value);
            WebSamplingPlan webSamplingPlan = ((WebSamplingPlan)((OkObjectResult)actionWebSamplingPlan.Result).Value);
            Assert.NotNull(webSamplingPlan);
            Assert.NotNull(webSamplingPlan.SamplingPlan);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSector;
            int TVItemID = 633;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebSector = await ReadGzFileService.ReadJSON<WebSector>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebSector.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebSector.Result).Value);
            WebSector webSector = ((WebSector)((OkObjectResult)actionWebSector.Result).Value);
            Assert.NotNull(webSector);
            Assert.NotNull(webSector.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            int TVItemID = 635;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebSubsector = await ReadGzFileService.ReadJSON<WebSubsector>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebSubsector.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebSubsector.Result).Value);
            WebSubsector webSubsector = ((WebSubsector)((OkObjectResult)actionWebSubsector.Result).Value);
            Assert.NotNull(webSubsector);
            Assert.NotNull(webSubsector.TVItem);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateWebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            WebTypeEnum webType = WebTypeEnum.WebTideLocation;
            int TVItemID = 0;
            WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

            string fileName = GetFileName(webType, TVItemID, webTypeYear);

            // Create gz
            var actionRes = await CreateGzFileService.CreateGzFile(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

            // Download gz
            var actionRes2 = await DownloadGzFileService.DownloadGzFile(fileName);
            Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes2.Result).Value);

            // Read gz
            var actionWebTideLocation = await ReadGzFileService.ReadJSON<WebTideLocation>(webType, TVItemID, webTypeYear);
            Assert.Equal(200, ((ObjectResult)actionWebTideLocation.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebTideLocation.Result).Value);
            WebTideLocation webTideLocation = ((WebTideLocation)((OkObjectResult)actionWebTideLocation.Result).Value);
            Assert.NotNull(webTideLocation);
            Assert.NotNull(webTideLocation.TideLocationList);
        }
        #endregion Tests 

        #region Functions private
        private string GetFileName(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            int Year = 0;
            string fileName = "";
            switch (webTypeYear)
            {
                case WebTypeYearEnum.Year1980:
                    Year = 1980;
                    break;
                case WebTypeYearEnum.Year1990:
                    Year = 1990;
                    break;
                case WebTypeYearEnum.Year2000:
                    Year = 2000;
                    break;
                case WebTypeYearEnum.Year2010:
                    Year = 2010;
                    break;
                case WebTypeYearEnum.Year2020:
                    Year = 2020;
                    break;
                case WebTypeYearEnum.Year2030:
                    Year = 2030;
                    break;
                case WebTypeYearEnum.Year2040:
                    Year = 2040;
                    break;
                case WebTypeYearEnum.Year2050:
                    Year = 2050;
                    break;
                default:
                    Year = 0;
                    break;
            }

            switch (webType)
            {
                case WebTypeEnum.WebRoot:
                    fileName = "WebRoot.gz";
                    break;
                case WebTypeEnum.WebCountry:
                    fileName = $"WebCountry_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebProvince:
                    fileName = $"WebProvince_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebArea:
                    fileName = $"WebArea_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipalities:
                    fileName = $"WebMunicipalities_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSector:
                    fileName = $"WebSector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebSubsector:
                    fileName = $"WebSubsector_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMunicipality:
                    fileName = $"WebMunicipality_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSample:
                    fileName = $"WebMWQMSample_{ TVItemID }_{ Year }_{ Year + 9 }.gz";
                    break;
                case WebTypeEnum.WebSamplingPlan:
                    fileName = $"WebSamplingPlan_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMRun:
                    fileName = $"WebMWQMRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMSite:
                    fileName = $"WebMWQMSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebContact:
                    fileName = $"WebContact.gz";
                    break;
                case WebTypeEnum.WebClimateSite:
                    fileName = $"WebClimateSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricSite:
                    fileName = $"WebHydrometricSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebDrogueRun:
                    fileName = $"WebDrogueRun_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebMWQMLookupMPN:
                    fileName = $"WebMWQMLookupMPN.gz";
                    break;
                case WebTypeEnum.WebMikeScenario:
                    fileName = $"WebMikeScenario_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebClimateDataValue:
                    fileName = $"WebClimateDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHydrometricDataValue:
                    fileName = $"WebHydrometricDataValue_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebHelpDoc:
                    fileName = $"WebHelpDoc.gz";
                    break;
                case WebTypeEnum.WebTideLocation:
                    fileName = $"WebTideLocation.gz";
                    break;
                case WebTypeEnum.WebPolSourceSite:
                    fileName = $"WebPolSourceSite_{ TVItemID }.gz";
                    break;
                case WebTypeEnum.WebPolSourceGrouping:
                    fileName = $"WebPolSourceGrouping.gz";
                    break;
                case WebTypeEnum.WebReportType:
                    fileName = $"WebReportType.gz";
                    break;
                default:
                    break;
            }

            return fileName;
        }
        #endregion Functions private
    }
}
