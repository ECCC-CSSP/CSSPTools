//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Root_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Country_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 5;

//        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Province_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Municipality_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Infrastructure_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        InfrastructureModel infrastructureModel = webMunicipality.InfrastructureModelList[0];

//        tvItemParent = infrastructureModel.TVItemModel.TVItem;

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

//        tvItemModelParentList.Add(infrastructureModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_MikeScenario_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

//        tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Area_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 629;

//        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

//        TVItem tvItemParent = webArea.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webArea.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Sector_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 633;

//        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

//        TVItem tvItemParent = webSector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_Subsector_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_MWQMSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//        TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList[0];

//        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMWQMSites.TVItemModelParentList;

//        tvItemModelParentList.Add(mwqmSiteModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task DeleteTVItemLocal_File_PolSourceSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//        TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        PolSourceSiteModel mwqmSiteModel = webPolSourceSites.PolSourceSiteModelList[0];

//        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;

//        TVItemModel tvItemModelAdded = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModelAdded, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModelAdded, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//        TVItemModel tvItemModel = await CheckDeleteTVItemLocal(tvItemParent, tvItemModelAdded);

//        CheckTVItem(tvItemModel, DBCommandEnum.Deleted);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Deleted, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webPolSourceSites.TVItemModelParentList;

//        tvItemModelParentList.Add(mwqmSiteModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//}

