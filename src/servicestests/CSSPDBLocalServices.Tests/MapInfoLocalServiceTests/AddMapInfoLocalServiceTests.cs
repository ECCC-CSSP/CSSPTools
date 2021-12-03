namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Area_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, ParentTVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webProvince.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Classification_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebSubsector, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, ParentTVItemID);

        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Classification;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webSubsector.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_ClimateSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebClimateSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, ParentTVItemID);

        TVItem tvItemParent = webClimateSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.ClimateSite;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webClimateSites.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Country_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 0;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, ParentTVItemID);

        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Country;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webRoot.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Area_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webArea.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Country_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webCountry.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Infrastructure_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMunicipality, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, ParentTVItemID);

        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMunicipality.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Province_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, ParentTVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webProvince.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_MikeScenario_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMikeScenarios, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, ParentTVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMikeScenarios.TVItemModelParentList, true);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Municipality_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMunicipality, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, ParentTVItemID);

        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMunicipality.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_MWQMSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMWQMSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, ParentTVItemID);

        TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

        MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];

        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMWQMSites.TVItemModelParentList, true);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_PolSourceSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebPolSourceSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, ParentTVItemID);

        TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

        PolSourceSiteModel mwqmSiteModel = webPolSourceSites.PolSourceSiteModelList[0];

        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webPolSourceSites.TVItemModelParentList, true);

    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Root_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 0;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, ParentTVItemID);

        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webRoot.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Sector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 633;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebSector, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, ParentTVItemID);

        TVItem tvItemParent = webSector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webSector.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_File_Subsector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebSubsector, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, ParentTVItemID);

        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.File;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webSubsector.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_HydrometricSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebHydrometricSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, ParentTVItemID);

        TVItem tvItemParent = webHydrometricSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.HydrometricSite;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webHydrometricSites.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Infrastructure_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMunicipality, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, ParentTVItemID);

        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Infrastructure;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMunicipality.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMikeScenarios, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, ParentTVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMikeScenarios.TVItemModelParentList, true);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMikeScenarios, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, ParentTVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMikeScenarios.TVItemModelParentList, true);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MikeSource_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 27764;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMikeScenarios, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, ParentTVItemID);

        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MikeSource;

        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMikeScenarios.TVItemModelParentList, true);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Municipality_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, ParentTVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Municipality;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webProvince.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MWQMSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebMWQMSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, ParentTVItemID);

        TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.MWQMSite;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webMWQMSites.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_PolSourceSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebPolSourceSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, ParentTVItemID);

        TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.PolSourceSite;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webPolSourceSites.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Province_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Province;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webCountry.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Sector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webArea.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Subsector_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 633;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebSector, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, ParentTVItemID);

        TVItem tvItemParent = webSector.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Subsector;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webSector.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TideSite_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebTideSites, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, ParentTVItemID);

        TVItem tvItemParent = webTideSites.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.TideSite;

        await CheckAddedMapInfo(tvItemParent, tvType);

        CheckCreatedLocalFilesAndDBForAdd(webTideSites.TVItemModelParentList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(new TVItem(), new TVItem(), TVTypeEnum.Province, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(401, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(new TVItem(), new TVItem(), TVTypeEnum.Province, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(401, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItemParent_null_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent = null;

        // tvItemParent null
        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItem_null_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem = null;

        // tvItemParent null
        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItem"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItemParent_TVItemID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.TVItemID = 0;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItemParent_ParentID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.ParentID = 0;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.ParentID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItemParent_TVType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.TVType = (TVTypeEnum)100000;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItem_TVItemID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem.TVItemID = 0;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItem_ParentID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem.ParentID = 0;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.ParentID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_TVItem_TVType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem.TVType = (TVTypeEnum)100000;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_tvType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvType = (TVTypeEnum)100000;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MapInfoDrawType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        MapInfoDrawTypeEnum mapInfoDrawType = (MapInfoDrawTypeEnum)100000;

        // mapInfoDrawType
        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, mapInfoDrawType, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoDrawType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_CheckTVTypeParentAndTVType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvType = TVTypeEnum.Country;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_CheckTVTypeParentAndTVType_notimplemented_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Sector;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.TVType = TVTypeEnum.Restricted;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- HelperLocalService.CheckTVTypeParentAndTVType", errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddMapInfoLocal_MapInfo_AlreadyExist_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 629;

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebArea, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, ParentTVItemID);

        TVItem tvItemParent = webArea.TVItemModel.TVItem;
        //TVTypeEnum tvType = TVTypeEnum.Sector;

        Assert.NotEmpty(webArea.TVItemModelSectorList);

        TVItem tvItemSectorExist = webArea.TVItemModelSectorList[0].TVItem;

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemSectorExist, tvItemSectorExist.TVType, MapInfoDrawTypeEnum.Point, new List<Coord>());
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, "MapInfo"), errRes.ErrList[0]);
    }
}

