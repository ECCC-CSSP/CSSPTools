namespace CSSPReadGzFileServices.Tests;

public partial class ReadJSONTests : CSSPReadGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllAddresses_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllContacts_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllContacts;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllCountries_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllCountries;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllEmails_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllEmails;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllHelpDocs_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllMunicipalities_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllMWQMAnalysisReportParameters_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllMWQMAnalysisReportParameters;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllMWQMLookupMPNs_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllMWQMSubsectors_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllMWQMSubsectors;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllPolSourceGroupings_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllProvinces_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllProvinces;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllReportTypes_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllSearch_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllSearch;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllTels_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllTels;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllTideLocations_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebAllUseOfSites_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllUseOfSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebArea_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 629;
        WebTypeEnum webType = WebTypeEnum.WebArea;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebClimateSite_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebClimateSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 5;
        WebTypeEnum webType = WebTypeEnum.WebCountry;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebDrogueRuns_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebHydrometricSite_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebLabSheets_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebLabSheets;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMikeScenarios_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 27764;
        WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory(Skip = "Temporary skipping because it takes a long time")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMonitoringOtherStatsCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 5;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory(Skip = "Temporary skipping because it takes a long time")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMonitoringOtherStatsProvince_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory(Skip = "Temporary skipping because it takes a long time")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMonitoringRoutineStatsCountry_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 5;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory(Skip = "Temporary skipping because it takes a long time")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMonitoringRoutineStatsProvince_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMunicipality_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 27764;
        WebTypeEnum webType = WebTypeEnum.WebMunicipality;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMWQMRun_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMWQMSamples1980_2020_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMWQMSamples2021_2060_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebMWQMSite_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebMWQMSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebPolSourceSite_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebProvince_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebProvince;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebRoot_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebRoot;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebSector_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 633;
        WebTypeEnum webType = WebTypeEnum.WebSector;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebSubsector_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebSubsector;

        await DoFullReadJSONTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ReadJSON_WebTideSites_Good_Test(string culture)
    {
        Assert.True(await CSSPReadGzFileServiceSetup(culture));

        int TVItemID = 7;
        WebTypeEnum webType = WebTypeEnum.WebTideSites;

        await DoFullReadJSONTest(webType, TVItemID);
    }
}

