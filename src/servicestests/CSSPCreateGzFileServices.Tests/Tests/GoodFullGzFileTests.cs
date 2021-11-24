namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllAddresses_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllContacts_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllContacts;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllCountries_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllCountries;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllEmails_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllEmails;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllHelpDocs_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllMunicipalities_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllMWQMAnalysisReportParameters_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllMWQMAnalysisReportParameters;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllMWQMLookupMPNs_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllMWQMSubsectors_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllMWQMSubsectors;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllPolSourceGroupings_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllPolSourceSiteEffectTerms_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllProvinces_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllProvinces;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllReportTypes_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllSearch_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllSearch;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllTels_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllTels;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllTideLocations_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllUseOfSites_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllUseOfSites;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAreaGzFile_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebArea;
        int TVItemID = 629;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebClimateSites_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebClimateSites;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebCountry_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebCountry;
        int TVItemID = 5;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebDrogueRuns_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebHydrometricSites_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebLabSheets_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebLabSheets;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMikeScenarios_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
        int TVItemID = 27764;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringOtherStatsCountry_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;
        int TVItemID = 5;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringOtherStatsProvince_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringRoutineStatsCountry_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;
        int TVItemID = 5;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMonitoringRoutineStatsProvince_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMunicipality_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMunicipality;
        int TVItemID = 27764;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMRuns_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMSamples1980_2020_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMSamples2021_2060_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMSites_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebPolSourceSites_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebProvince_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebProvince;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebRoot_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebRoot;
        int TVItemID = 0;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebSector_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebSector;
        int TVItemID = 633;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebSubsector_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebSubsector;
        int TVItemID = 635;

        await DoFullTest(webType, TVItemID);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebTideSites_Full_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebTideSites;
        int TVItemID = 7;

        await DoFullTest(webType, TVItemID);
    }
}

