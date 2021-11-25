namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteMapInfoLocal_Constructor_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        // no test needed
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteMapInfoLocal_Area_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        Assert.NotEmpty(webProvince.TVItemModelAreaList);

        TVItemModel tvItemModel = webProvince.TVItemModelAreaList[0];

        await CheckDeletedMapInfo(tvItemParent, tvItemModel, tvType, MapInfoDrawTypeEnum.Point);
        await CheckDeletedMapInfo(tvItemParent, tvItemModel, tvType, MapInfoDrawTypeEnum.Polygon);

        await CheckDeletedMapInfoOfAdded(tvItemParent, tvItemModel, tvType, MapInfoDrawTypeEnum.Point);
    }
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Classification_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 635;

    //    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

    //    TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Classification;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_ClimateSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 7;

    //    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

    //    TVItem tvItemParent = webProvince.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.ClimateSite;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Country_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

    //    TVItem tvItemParent = webRoot.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Country;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Email_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_EmailDistributionList_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Area_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 629;

    //    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

    //    TVItem tvItemParent = webArea.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Country_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 5;

    //    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

    //    TVItem tvItemParent = webCountry.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Infrastructure_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

    //    TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Province_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 7;

    //    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

    //    TVItem tvItemParent = webProvince.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_MikeScenario_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

    //    TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

    //    MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

    //    tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Municipality_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

    //    TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_MWQMSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 635;

    //    WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSON<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

    //    TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

    //    MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];

    //    tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_PolSourceSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 635;

    //    WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSON<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

    //    TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

    //    PolSourceSiteModel mwqmSiteModel = webPolSourceSites.PolSourceSiteModelList[0];

    //    tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Root_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 0;

    //    WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, TVItemID);

    //    TVItem tvItemParent = webRoot.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Sector_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 633;

    //    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

    //    TVItem tvItemParent = webSector.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_File_Subsector_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 635;

    //    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

    //    TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.File;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_HydrometricSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 7;

    //    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

    //    TVItem tvItemParent = webProvince.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.HydrometricSite;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Infrastructure_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

    //    TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Infrastructure;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

    //    TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;

    //    Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

    //    MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

    //    tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

    //    TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;

    //    Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

    //    MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

    //    tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_MikeScenario_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_MikeSource_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 27764;

    //    WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSON<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

    //    TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.MikeSource;

    //    Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

    //    MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

    //    tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Municipality_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 7;

    //    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

    //    TVItem tvItemParent = webProvince.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Municipality;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_MWQMRun_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_MWQMSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 635;

    //    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

    //    TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.MWQMSite;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_PolSourceSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 635;

    //    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

    //    TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.PolSourceSite;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Province_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 5;

    //    WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

    //    TVItem tvItemParent = webCountry.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Province;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_RainExceedance_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_SamplingPlan_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Sector_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 629;

    //    WebArea webArea = await CSSPReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, TVItemID);

    //    TVItem tvItemParent = webArea.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Sector;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Subsector_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 633;

    //    WebSector webSector = await CSSPReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, TVItemID);

    //    TVItem tvItemParent = webSector.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.Subsector;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_Tel_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    // no test needed
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task DeleteMapInfoLocal_TideSite_Good_Test(string culture)
    //{
    //    Assert.True(await MapInfoLocalServiceSetup(culture));

    //    int TVItemID = 7;

    //    WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

    //    TVItem tvItemParent = webProvince.TVItemModel.TVItem;
    //    TVTypeEnum tvType = TVTypeEnum.TideSite;

    //    await CheckDeletedMapInfo(tvItemParent, tvType);
    //}
}

