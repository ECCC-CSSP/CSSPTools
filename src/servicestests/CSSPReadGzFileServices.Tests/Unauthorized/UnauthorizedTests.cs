namespace CSSPReadGzFileServices.Tests;

public partial class UnauthorizedTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebNNNNN_Unauthorized_Error_Test(string culture)
    {
        List<WebTypeEnum> webTypeList = new List<WebTypeEnum>()
            {
                WebTypeEnum.WebAllAddresses,
                WebTypeEnum.WebAllContacts,
                WebTypeEnum.WebAllCountries,
                WebTypeEnum.WebAllEmails,
                WebTypeEnum.WebAllHelpDocs,
                WebTypeEnum.WebAllMunicipalities,
                WebTypeEnum.WebAllMWQMAnalysisReportParameters,
                WebTypeEnum.WebAllMWQMLookupMPNs,
                WebTypeEnum.WebAllMWQMSubsectors,
                WebTypeEnum.WebAllPolSourceGroupings,
                WebTypeEnum.WebAllPolSourceSiteEffectTerms,
                WebTypeEnum.WebAllProvinces,
                WebTypeEnum.WebAllReportTypes,
                WebTypeEnum.WebAllSearch,
                WebTypeEnum.WebAllTels,
                WebTypeEnum.WebAllTideLocations,
                WebTypeEnum.WebAllUseOfSites,
                WebTypeEnum.WebArea,
                WebTypeEnum.WebClimateSites,
                WebTypeEnum.WebCountry,
                WebTypeEnum.WebDrogueRuns,
                WebTypeEnum.WebHydrometricSites,
                WebTypeEnum.WebLabSheets,
                WebTypeEnum.WebMikeScenarios,
                WebTypeEnum.WebMonitoringOtherStatsCountry,
                WebTypeEnum.WebMonitoringOtherStatsProvince,
                WebTypeEnum.WebMonitoringRoutineStatsCountry,
                WebTypeEnum.WebMonitoringRoutineStatsProvince,
                WebTypeEnum.WebMunicipality,
                WebTypeEnum.WebMWQMRuns,
                WebTypeEnum.WebMWQMSamples1980_2020,
                WebTypeEnum.WebMWQMSamples2021_2060,
                WebTypeEnum.WebMWQMSites,
                WebTypeEnum.WebPolSourceSites,
                WebTypeEnum.WebProvince,
                WebTypeEnum.WebRoot,
                WebTypeEnum.WebSector,
                WebTypeEnum.WebSubsector,
                WebTypeEnum.WebTideSites,
            };

        foreach (WebTypeEnum webTypeToTry in webTypeList)
        {
            Assert.True(await CSSPReadGzFileServiceSetup(culture));

            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

            WebTypeEnum webType = webTypeToTry;

            var actionWeb = await CSSPReadGzFileService.ReadJSONAsync<WebAllAddresses /* type not important */>(webType);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionWeb.Result).StatusCode);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionWeb.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();

            CSSPLocalLoggedInService.LoggedInContactInfo = null;

            webType = webTypeToTry;

            actionWeb = await CSSPReadGzFileService.ReadJSONAsync<WebAllAddresses /* type not important */>(webType);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionWeb.Result).StatusCode);
            errRes = (ErrRes)((UnauthorizedObjectResult)actionWeb.Result).Value;
            Assert.NotEmpty(errRes.ErrList);

            errRes = new ErrRes();
        }
    }
}

