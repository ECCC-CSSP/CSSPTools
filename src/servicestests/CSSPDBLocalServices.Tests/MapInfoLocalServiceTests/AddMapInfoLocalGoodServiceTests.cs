namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Constructor_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Area_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Classification_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 635;

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Classification;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_ClimateSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.ClimateSite;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Country_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Country;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Email_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_EmailDistributionList_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Area_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 629;

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Country_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 5;

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Infrastructure_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Province_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_MikeScenario_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Municipality_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_MWQMSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 635;

        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

        TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

        MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];

        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_PolSourceSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 635;

        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

        TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

        PolSourceSiteModel mwqmSiteModel = webPolSourceSites.PolSourceSiteModelList[0];

        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Root_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 0;

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, TVItemID);

        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Sector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 633;

        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

        TVItem tvItemParent = webSector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Subsector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 635;

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_HydrometricSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.HydrometricSite;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Infrastructure_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Infrastructure;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeScenario_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeSource_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 27764;

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MikeSource;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Municipality_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Municipality;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MWQMRun_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MWQMSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 635;

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MWQMSite;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_PolSourceSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 635;

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.PolSourceSite;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Province_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 5;

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Province;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_RainExceedance_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_SamplingPlan_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Sector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 629;

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Subsector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 633;

        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

        TVItem tvItemParent = webSector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Subsector;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Tel_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TideSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.TideSite;

        await CheckAddedMapInfo(tvItemParent, tvType);
    }
}

