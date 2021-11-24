namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllAddresses, 0);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_webType_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = (WebTypeEnum)10000;
        int TVItemID = 10;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._NotImplementedYet, $"{ webType }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebArea_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebArea;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Area.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebClimateSites_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebClimateSites;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebCountry_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebCountry;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebDrogueRuns_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebDrogueRuns;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebHydrometricSites_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebLabSheets_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebLabSheets;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMikeScenarios_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMonitoringOtherStatsCountry_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsCountry;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
            "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMonitoringOtherStatsProvince_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringOtherStatsProvince;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
            "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMonitoringRoutineStatsCountry_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsCountry;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Country.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMonitoringRoutineStatsProvince_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMonitoringRoutineStatsProvince;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMunicipality_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMunicipality;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Municipality.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMWQMRuns_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMRuns;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMWQMSamples1980_2020_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMWQMSamples2021_2060_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebMWQMSites_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSites;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebPolSourceSites_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebPolSourceSites;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebProvince_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebProvince;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebSector_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebSector;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Sector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebSubsector_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebSubsector;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateGzFiles_WebTideSites_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        WebTypeEnum webType = WebTypeEnum.WebTideSites;
        int TVItemID = 1000000;

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                "TVItem", TVItemID.ToString(), "TVType", TVTypeEnum.Province.ToString()), errRes.ErrList[0]);
    }
}

