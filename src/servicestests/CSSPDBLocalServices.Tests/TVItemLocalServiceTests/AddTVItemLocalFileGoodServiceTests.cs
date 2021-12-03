//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Root_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Country_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 5;

//        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Province_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Municipality_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Infrastructure_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];
//        Assert.NotNull(infrastructureModel);

//        tvItemParent = infrastructureModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

//        tvItemModelParentList.Add(infrastructureModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_MikeScenario_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

//        tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Area_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 629;

//        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

//        TVItem tvItemParent = webArea.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webArea.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webArea.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Sector_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 633;

//        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

//        TVItem tvItemParent = webSector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_Subsector_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_MWQMSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//        TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];
//        Assert.NotNull(mwqmSiteModel);

//        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMWQMSites.TVItemModelParentList;

//        tvItemModelParentList.Add(mwqmSiteModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_File_PolSourceSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//        TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        PolSourceSiteModel polSourceSiteModel = webPolSourceSites.PolSourceSiteModelList[0];
//        Assert.NotNull(polSourceSiteModel);

//        tvItemParent = polSourceSiteModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webPolSourceSites.TVItemModelParentList;

//        tvItemModelParentList.Add(polSourceSiteModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//}

