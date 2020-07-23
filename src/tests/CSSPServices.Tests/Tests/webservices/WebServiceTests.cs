using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class WebServiceTests
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
        [InlineData("fr-CA")]
        public async Task GetWebArea_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebArea = await WebService.GetWebArea(629);
            Assert.Equal(200, ((ObjectResult)actionWebArea.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebArea.Result).Value);
            WebArea webArea = (WebArea)((OkObjectResult)actionWebArea.Result).Value;
            Assert.NotNull(webArea);
            Assert.NotNull(webArea.TVItem);
            Assert.NotNull(webArea.TVItemLanguageList);
            Assert.NotNull(webArea.TVItemStatList);
            Assert.NotNull(webArea.MapInfoList);
            Assert.NotNull(webArea.MapInfoPointList);
            Assert.NotNull(webArea.TVFileList);
            Assert.NotNull(webArea.TVFileLanguageList);
            Assert.NotNull(webArea.TVItemSectorList);
            Assert.NotNull(webArea.TVItemLanguageSectorList);
            Assert.NotNull(webArea.TVItemStatSectorList);
            Assert.NotNull(webArea.MapInfoSectorList);
            Assert.NotNull(webArea.MapInfoPointSectorList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebClimateDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebClimateDataValue = await WebService.GetWebClimateDataValue(229465);
            Assert.Equal(200, ((ObjectResult)actionWebClimateDataValue.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebClimateDataValue.Result).Value);
            WebClimateDataValue webClimateDataValue = (WebClimateDataValue)((OkObjectResult)actionWebClimateDataValue.Result).Value;
            Assert.NotNull(webClimateDataValue);
            Assert.NotNull(webClimateDataValue.ClimateDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebClimateSite = await WebService.GetWebClimateSite(7);
            Assert.Equal(200, ((ObjectResult)actionWebClimateSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebClimateSite.Result).Value);
            WebClimateSite webClimateSite = (WebClimateSite)((OkObjectResult)actionWebClimateSite.Result).Value;
            Assert.NotNull(webClimateSite);
            Assert.NotNull(webClimateSite.ClimateSiteList);
            Assert.NotNull(webClimateSite.TVItemList);
            Assert.NotNull(webClimateSite.TVItemLanguageList);
            Assert.NotNull(webClimateSite.MapInfoList);
            Assert.NotNull(webClimateSite.MapInfoPointList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebContact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebContact = await WebService.GetWebContact();
            Assert.Equal(200, ((ObjectResult)actionWebContact.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebContact.Result).Value);
            WebContact webContact = (WebContact)((OkObjectResult)actionWebContact.Result).Value;
            Assert.NotNull(webContact);
            Assert.NotNull(webContact.ContactList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebCountry_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebCountry = await WebService.GetWebCountry(5);
            Assert.Equal(200, ((ObjectResult)actionWebCountry.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebCountry.Result).Value);
            WebCountry webCountry = (WebCountry)((OkObjectResult)actionWebCountry.Result).Value;
            Assert.NotNull(webCountry);
            Assert.NotNull(webCountry.TVItem);
            Assert.NotNull(webCountry.TVItemLanguageList);
            Assert.NotNull(webCountry.TVItemStatList);
            Assert.NotNull(webCountry.MapInfoList);
            Assert.NotNull(webCountry.MapInfoPointList);
            Assert.NotNull(webCountry.TVFileList);
            Assert.NotNull(webCountry.TVFileLanguageList);
            Assert.NotNull(webCountry.TVItemProvinceList);
            Assert.NotNull(webCountry.TVItemLanguageProvinceList);
            Assert.NotNull(webCountry.TVItemStatProvinceList);
            Assert.NotNull(webCountry.MapInfoProvinceList);
            Assert.NotNull(webCountry.MapInfoPointProvinceList);
            Assert.NotNull(webCountry.EmailDistributionListList);
            Assert.NotNull(webCountry.EmailDistributionListLanguageList);
            Assert.NotNull(webCountry.EmailDistributionListContactList);
            Assert.NotNull(webCountry.EmailDistributionListContactLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebDrogueRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebDrogueRun = await WebService.GetWebDrogueRun(556);
            Assert.Equal(200, ((ObjectResult)actionWebDrogueRun.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebDrogueRun.Result).Value);
            WebDrogueRun webDrogueRun = (WebDrogueRun)((OkObjectResult)actionWebDrogueRun.Result).Value;
            Assert.NotNull(webDrogueRun);
            Assert.NotNull(webDrogueRun.DrogueRunList);
            Assert.NotNull(webDrogueRun.DrogueRunPositionList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebHelpDoc_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebHelpDoc = await WebService.GetWebHelpDoc();
            Assert.Equal(200, ((ObjectResult)actionWebHelpDoc.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebHelpDoc.Result).Value);
            WebHelpDoc webHelpDoc = (WebHelpDoc)((OkObjectResult)actionWebHelpDoc.Result).Value;
            Assert.NotNull(webHelpDoc);
            Assert.NotNull(webHelpDoc.HelpDocList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebHydrometricDataValue_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebHydrometricDataValue = await WebService.GetWebHydrometricDataValue(51705);
            Assert.Equal(200, ((ObjectResult)actionWebHydrometricDataValue.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebHydrometricDataValue.Result).Value);
            WebHydrometricDataValue webHydrometricDataValue = (WebHydrometricDataValue)((OkObjectResult)actionWebHydrometricDataValue.Result).Value;
            Assert.NotNull(webHydrometricDataValue);
            Assert.NotNull(webHydrometricDataValue.HydrometricDataValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebHydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebHydrometricSite = await WebService.GetWebHydrometricSite(7);
            Assert.Equal(200, ((ObjectResult)actionWebHydrometricSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebHydrometricSite.Result).Value);
            WebHydrometricSite webHydrometricSite = (WebHydrometricSite)((OkObjectResult)actionWebHydrometricSite.Result).Value;
            Assert.NotNull(webHydrometricSite);
            Assert.NotNull(webHydrometricSite.HydrometricSiteList);
            Assert.NotNull(webHydrometricSite.TVItemList);
            Assert.NotNull(webHydrometricSite.TVItemLanguageList);
            Assert.NotNull(webHydrometricSite.MapInfoList);
            Assert.NotNull(webHydrometricSite.MapInfoPointList);
            Assert.NotNull(webHydrometricSite.RatingCurveList);
            Assert.NotNull(webHydrometricSite.RatingCurveValueList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMikeScenario = await WebService.GetWebMikeScenario(12281);
            Assert.Equal(200, ((ObjectResult)actionWebMikeScenario.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMikeScenario.Result).Value);
            WebMikeScenario webMikeScenario = (WebMikeScenario)((OkObjectResult)actionWebMikeScenario.Result).Value;
            Assert.NotNull(webMikeScenario);
            Assert.NotNull(webMikeScenario.TVItem);
            Assert.NotNull(webMikeScenario.TVItemLanguageList);
            Assert.NotNull(webMikeScenario.TVItemStatList);
            Assert.NotNull(webMikeScenario.MapInfoList);
            Assert.NotNull(webMikeScenario.MapInfoPointList);
            Assert.NotNull(webMikeScenario.TVFileList);
            Assert.NotNull(webMikeScenario.TVFileLanguageList);
            Assert.NotNull(webMikeScenario.MikeScenario);
            Assert.NotNull(webMikeScenario.MikeBoundaryConditionList);
            Assert.NotNull(webMikeScenario.TVItemMikeBoundaryConditionList);
            Assert.NotNull(webMikeScenario.TVItemLanguageMikeBoundaryConditionList);
            Assert.NotNull(webMikeScenario.TVItemStatMikeBoundaryConditionList);
            Assert.NotNull(webMikeScenario.MapInfoMikeBoundaryConditionList);
            Assert.NotNull(webMikeScenario.MapInfoPointMikeBoundaryConditionList);
            Assert.NotNull(webMikeScenario.MikeSourceList);
            Assert.NotNull(webMikeScenario.TVItemMikeSourceList);
            Assert.NotNull(webMikeScenario.TVItemLanguageMikeSourceList);
            Assert.NotNull(webMikeScenario.TVItemStatMikeSourceList);
            Assert.NotNull(webMikeScenario.MapInfoMikeSourceList);
            Assert.NotNull(webMikeScenario.MapInfoPointMikeSourceList);
            Assert.NotNull(webMikeScenario.MikeSourceStartEndList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMunicipalities_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMunicipalities = await WebService.GetWebMunicipalities(7);
            Assert.Equal(200, ((ObjectResult)actionWebMunicipalities.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMunicipalities.Result).Value);
            WebMunicipalities webMunicipalities = (WebMunicipalities)((OkObjectResult)actionWebMunicipalities.Result).Value;
            Assert.NotNull(webMunicipalities);
            Assert.NotNull(webMunicipalities.TVItemList);
            Assert.NotNull(webMunicipalities.TVItemLanguageList);
            Assert.NotNull(webMunicipalities.TVItemStatList);
            Assert.NotNull(webMunicipalities.MapInfoList);
            Assert.NotNull(webMunicipalities.MapInfoPointList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMunicipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMunicipality = await WebService.GetWebMunicipality(12110);
            Assert.Equal(200, ((ObjectResult)actionWebMunicipality.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMunicipality.Result).Value);
            WebMunicipality webMunicipality = (WebMunicipality)((OkObjectResult)actionWebMunicipality.Result).Value;
            Assert.NotNull(webMunicipality);
            Assert.NotNull(webMunicipality.TVItem);
            Assert.NotNull(webMunicipality.TVItemLanguageList);
            Assert.NotNull(webMunicipality.TVItemStatList);
            Assert.NotNull(webMunicipality.MapInfoList);
            Assert.NotNull(webMunicipality.MapInfoPointList);
            Assert.NotNull(webMunicipality.TVFileList);
            Assert.NotNull(webMunicipality.TVFileLanguageList);
            Assert.NotNull(webMunicipality.TVItemInfrastructureList);
            Assert.NotNull(webMunicipality.TVItemLanguageInfrastructureList);
            Assert.NotNull(webMunicipality.TVItemStatInfrastructureList);
            Assert.NotNull(webMunicipality.TVItemMikeScenarioList);
            Assert.NotNull(webMunicipality.TVItemLanguageMikeScenarioList);
            Assert.NotNull(webMunicipality.TVItemStatMikeScenarioList);
            Assert.NotNull(webMunicipality.InfrastructureList);
            Assert.NotNull(webMunicipality.MunicipalityTVItemLinkList);
            Assert.NotNull(webMunicipality.InfrastructureCivicAddressList);
            Assert.NotNull(webMunicipality.TVItemMapInfoInfrastructureList);
            Assert.NotNull(webMunicipality.TVItemMapInfoPointInfrastructureList);
            Assert.NotNull(webMunicipality.InfrastructureLanguageList);
            Assert.NotNull(webMunicipality.BoxModelList);
            Assert.NotNull(webMunicipality.BoxModelLanguageList);
            Assert.NotNull(webMunicipality.BoxModelResultList);
            Assert.NotNull(webMunicipality.VPScenarioList);
            Assert.NotNull(webMunicipality.VPScenarioLanguageList);
            Assert.NotNull(webMunicipality.VPAmbientList);
            Assert.NotNull(webMunicipality.VPResultList);
            Assert.NotNull(webMunicipality.MunicipalityContactList);
            Assert.NotNull(webMunicipality.MunicipalityContactEmailList);
            Assert.NotNull(webMunicipality.MunicipalityContactTelList);
            Assert.NotNull(webMunicipality.MunicipalityContactAddressList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMWQMLookupMPN_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMLookupMPN = await WebService.GetWebMWQMLookupMPN();
            Assert.Equal(200, ((ObjectResult)actionWebMWQMLookupMPN.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMLookupMPN.Result).Value);
            WebMWQMLookupMPN webMWQMLookupMPN = (WebMWQMLookupMPN)((OkObjectResult)actionWebMWQMLookupMPN.Result).Value;
            Assert.NotNull(webMWQMLookupMPN);
            Assert.NotNull(webMWQMLookupMPN.MWQMLookupMPNList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMRun = await WebService.GetWebMWQMRun(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMRun.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMRun.Result).Value);
            WebMWQMRun webMWQMRun = (WebMWQMRun)((OkObjectResult)actionWebMWQMRun.Result).Value;
            Assert.NotNull(webMWQMRun);
            Assert.NotNull(webMWQMRun.MWQMRunList);
            Assert.NotNull(webMWQMRun.MWQMRunLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample1980_1989FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample1990_1999FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample1990_1999FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2000_2009FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2000_2009FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2010_2019FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2010_2019FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2020_2029FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2020_2029FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2030_2039FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2030_2039FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2040_2049FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2040_2049FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWeb10YearOfSample2050_2059FromSubsector(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSample = await WebService.GetWeb10YearOfSample2050_2059FromSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSample.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSample.Result).Value);
            WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionWebMWQMSample.Result).Value;
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleList);
            Assert.NotNull(webMWQMSample.MWQMSampleLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebMWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebMWQMSite = await WebService.GetWebMWQMSite(635);
            Assert.Equal(200, ((ObjectResult)actionWebMWQMSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebMWQMSite.Result).Value);
            WebMWQMSite webMWQMSite = (WebMWQMSite)((OkObjectResult)actionWebMWQMSite.Result).Value;
            Assert.NotNull(webMWQMSite);
            Assert.NotNull(webMWQMSite.MWQMSiteList);
            Assert.NotNull(webMWQMSite.MWQMSiteStartEndDateList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebPolSourceGrouping_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebPolSourceGrouping = await WebService.GetWebPolSourceGrouping();
            Assert.Equal(200, ((ObjectResult)actionWebPolSourceGrouping.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebPolSourceGrouping.Result).Value);
            WebPolSourceGrouping webPolSourceGrouping = (WebPolSourceGrouping)((OkObjectResult)actionWebPolSourceGrouping.Result).Value;
            Assert.NotNull(webPolSourceGrouping);
            Assert.NotNull(webPolSourceGrouping.PolSourceGroupingList);
            Assert.NotNull(webPolSourceGrouping.PolSourceGroupingLanguageList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebPolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebPolSourceSite = await WebService.GetWebPolSourceSite(635);
            Assert.Equal(200, ((ObjectResult)actionWebPolSourceSite.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebPolSourceSite.Result).Value);
            WebPolSourceSite webPolSourceSite = (WebPolSourceSite)((OkObjectResult)actionWebPolSourceSite.Result).Value;
            Assert.NotNull(webPolSourceSite);
            Assert.NotNull(webPolSourceSite.PolSourceSiteList);
            Assert.NotNull(webPolSourceSite.PolSourceObservationList);
            Assert.NotNull(webPolSourceSite.PolSourceObservationIssueList);
            Assert.NotNull(webPolSourceSite.PolSourceSiteEffectList);
            Assert.NotNull(webPolSourceSite.PolSourceSiteEffectTermList);
            Assert.NotNull(webPolSourceSite.PolSourceSiteCivicAddressList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebProvince_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebProvince = await WebService.GetWebProvince(7);
            Assert.Equal(200, ((ObjectResult)actionWebProvince.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebProvince.Result).Value);
            WebProvince webProvince = (WebProvince)((OkObjectResult)actionWebProvince.Result).Value;
            Assert.NotNull(webProvince);
            Assert.NotNull(webProvince.TVItem);
            Assert.NotNull(webProvince.TVItemLanguageList);
            Assert.NotNull(webProvince.TVItemStatList);
            Assert.NotNull(webProvince.MapInfoList);
            Assert.NotNull(webProvince.MapInfoPointList);
            Assert.NotNull(webProvince.TVFileList);
            Assert.NotNull(webProvince.TVFileLanguageList);
            Assert.NotNull(webProvince.TVItemAreaList);
            Assert.NotNull(webProvince.TVItemLanguageAreaList);
            Assert.NotNull(webProvince.TVItemStatAreaList);
            Assert.NotNull(webProvince.MapInfoAreaList);
            Assert.NotNull(webProvince.MapInfoPointAreaList);
            Assert.NotNull(webProvince.SamplingPlanList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebReportType_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebReportType = await WebService.GetWebReportType();
            Assert.Equal(200, ((ObjectResult)actionWebReportType.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebReportType.Result).Value);
            WebReportType webReportType = (WebReportType)((OkObjectResult)actionWebReportType.Result).Value;
            Assert.NotNull(webReportType);
            Assert.NotNull(webReportType.ReportTypeList);
            Assert.NotNull(webReportType.ReportSectionList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebRoot_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebRoot = await WebService.GetWebRoot();
            Assert.Equal(200, ((ObjectResult)actionWebRoot.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebRoot.Result).Value);
            WebRoot webRoot = (WebRoot)((OkObjectResult)actionWebRoot.Result).Value;
            Assert.NotNull(webRoot);
            Assert.NotNull(webRoot.TVItem);
            Assert.NotNull(webRoot.TVItemLanguageList);
            Assert.NotNull(webRoot.TVItemStatList);
            Assert.NotNull(webRoot.MapInfoList);
            Assert.NotNull(webRoot.MapInfoPointList);
            Assert.NotNull(webRoot.TVFileList);
            Assert.NotNull(webRoot.TVFileLanguageList);
            Assert.NotNull(webRoot.TVItemCountryList);
            Assert.NotNull(webRoot.TVItemLanguageCountryList);
            Assert.NotNull(webRoot.TVItemStatCountryList);
            Assert.NotNull(webRoot.MapInfoCountryList);
            Assert.NotNull(webRoot.MapInfoPointCountryList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebSamplingPlan_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebSamplingPlan = await WebService.GetWebSamplingPlan(8);
            Assert.Equal(200, ((ObjectResult)actionWebSamplingPlan.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebSamplingPlan.Result).Value);
            WebSamplingPlan webSamplingPlan = (WebSamplingPlan)((OkObjectResult)actionWebSamplingPlan.Result).Value;
            Assert.NotNull(webSamplingPlan);
            Assert.NotNull(webSamplingPlan.SamplingPlan);
            Assert.NotNull(webSamplingPlan.SamplingPlanEmailList);
            Assert.NotNull(webSamplingPlan.SamplingPlanSubsectorList);
            Assert.NotNull(webSamplingPlan.SamplingPlanSubsectorSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebSector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebSector = await WebService.GetWebSector(633);
            Assert.Equal(200, ((ObjectResult)actionWebSector.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebSector.Result).Value);
            WebSector webSector = (WebSector)((OkObjectResult)actionWebSector.Result).Value;
            Assert.NotNull(webSector);
            Assert.NotNull(webSector.TVItem);
            Assert.NotNull(webSector.TVItemLanguageList);
            Assert.NotNull(webSector.TVItemStatList);
            Assert.NotNull(webSector.MapInfoList);
            Assert.NotNull(webSector.MapInfoPointList);
            Assert.NotNull(webSector.TVFileList);
            Assert.NotNull(webSector.TVFileLanguageList);
            Assert.NotNull(webSector.TVItemSubsectorList);
            Assert.NotNull(webSector.TVItemLanguageSubsectorList);
            Assert.NotNull(webSector.TVItemStatSubsectorList);
            Assert.NotNull(webSector.MapInfoSubsectorList);
            Assert.NotNull(webSector.MapInfoPointSubsectorList);
            Assert.NotNull(webSector.TVItemMikeScenarioList);
            Assert.NotNull(webSector.TVItemLanguageMikeScenarioList);
            Assert.NotNull(webSector.TVItemStatMikeScenarioList);
            Assert.NotNull(webSector.MapInfoMikeScenarioList);
            Assert.NotNull(webSector.MapInfoPointMikeScenarioList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebSubsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebSubsector = await WebService.GetWebSubsector(635);
            Assert.Equal(200, ((ObjectResult)actionWebSubsector.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebSubsector.Result).Value);
            WebSubsector webSubsector = (WebSubsector)((OkObjectResult)actionWebSubsector.Result).Value;
            Assert.NotNull(webSubsector);
            Assert.NotNull(webSubsector.TVItem);
            Assert.NotNull(webSubsector.TVItemLanguageList);
            Assert.NotNull(webSubsector.TVItemStatList);
            Assert.NotNull(webSubsector.MapInfoList);
            Assert.NotNull(webSubsector.MapInfoPointList);
            Assert.NotNull(webSubsector.TVFileList);
            Assert.NotNull(webSubsector.TVFileLanguageList);
            Assert.NotNull(webSubsector.TVItemMWQMSiteList);
            Assert.NotNull(webSubsector.TVItemLanguageMWQMSiteList);
            Assert.NotNull(webSubsector.TVItemStatMWQMSiteList);
            Assert.NotNull(webSubsector.MapInfoMWQMSiteList);
            Assert.NotNull(webSubsector.MapInfoPointMWQMSiteList);
            Assert.NotNull(webSubsector.TVItemMWQMRunList);
            Assert.NotNull(webSubsector.TVItemLanguageMWQMRunList);
            Assert.NotNull(webSubsector.TVItemStatMWQMRunList);
            Assert.NotNull(webSubsector.TVItemPolSourceSiteList);
            Assert.NotNull(webSubsector.TVItemLanguagePolSourceSiteList);
            Assert.NotNull(webSubsector.TVItemStatPolSourceSiteList);
            Assert.NotNull(webSubsector.MapInfoPolSourceSiteList);
            Assert.NotNull(webSubsector.MapInfoPointPolSourceSiteList);
            Assert.NotNull(webSubsector.MWQMAnalysisReportParameterList);
            Assert.NotNull(webSubsector.LabSheetList);
            Assert.NotNull(webSubsector.LabSheetDetailList);
            Assert.NotNull(webSubsector.LabSheetTubeMPNDetailList);
            Assert.NotNull(webSubsector.MWQMSubsector);
            Assert.NotNull(webSubsector.MWQMSubsectorLanguageList);
            Assert.NotNull(webSubsector.UseOfSiteList);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task GetWebTideLocation_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            var actionWebTideLocation = await WebService.GetWebTideLocation();
            Assert.Equal(200, ((ObjectResult)actionWebTideLocation.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionWebTideLocation.Result).Value);
            WebTideLocation webTideLocation = (WebTideLocation)((OkObjectResult)actionWebTideLocation.Result).Value;
            Assert.NotNull(webTideLocation);
            Assert.NotNull(webTideLocation.TideLocationList);
        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
