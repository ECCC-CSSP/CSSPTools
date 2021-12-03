//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Root_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webRoot.TVFileModelList);

//        TVTextEN = webRoot.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webRoot.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Country_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 5;

//        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webCountry.TVFileModelList);

//        TVTextEN = webCountry.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webCountry.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Province_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webProvince.TVFileModelList);

//        TVTextEN = webProvince.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webProvince.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Municipality_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webMunicipality.TVFileModelList);

//        TVTextEN = webMunicipality.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webMunicipality.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Infrastructure_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
//                                                   where c.TVFileModelList.Count > 0
//                                                   select c).FirstOrDefault();
//        Assert.NotNull(infrastructureModel);

//        tvItemParent = infrastructureModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(infrastructureModel.TVFileModelList);

//        TVTextEN = infrastructureModel.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = infrastructureModel.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MikeScenario_File_Already_Exist_Error_Test(string culture)
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

//        Assert.NotEmpty(mikeScenarioModel.TVFileModelList);

//        TVTextEN = mikeScenarioModel.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = mikeScenarioModel.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Area_File_Already_Exist_Error_Test(string culture)
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

//        Assert.NotEmpty(webArea.TVFileModelList);

//        TVTextEN = webArea.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webArea.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Sector_File_Already_Exist_Error_Test(string culture)
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

//        Assert.NotEmpty(webSector.TVFileModelList);

//        TVTextEN = webSector.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webSector.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Subsector_File_Already_Exist_Error_Test(string culture)
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

//        Assert.NotEmpty(webSubsector.TVFileModelList);

//        TVTextEN = webSubsector.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = webSubsector.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MWQMSite_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//        TVItem tvItemParent = webMWQMSites.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MWQMSiteModel mwqmSiteModel = (from c in webMWQMSites.MWQMSiteModelList
//                                       where c.TVFileModelList.Count > 0
//                                       select c).FirstOrDefault();
//        Assert.NotNull(mwqmSiteModel);

//        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(mwqmSiteModel.TVFileModelList);

//        TVTextEN = mwqmSiteModel.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = mwqmSiteModel.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_PolSourceSite_File_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//        TVItem tvItemParent = webPolSourceSites.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.File;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        PolSourceSiteModel polSourceSiteModel = (from c in webPolSourceSites.PolSourceSiteModelList
//                                                 where c.TVFileModelList.Count > 0
//                                                 select c).FirstOrDefault();
//        Assert.NotNull(polSourceSiteModel);

//        tvItemParent = polSourceSiteModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(polSourceSiteModel.TVFileModelList);

//        TVTextEN = polSourceSiteModel.TVFileModelList[0].TVFile.ServerFileName;
//        TVTextFR = polSourceSiteModel.TVFileModelList[0].TVFile.ServerFileName;

//        string message = "";
//        message = $"{ TVTextEN } (en)";
//        message = message + $"     { TVTextFR } (fr)";

//        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
//        Assert.Equal(400, ((ObjectResult)actionTVItemModel.Result).StatusCode);
//        Assert.NotNull(((BadRequestObjectResult)actionTVItemModel.Result).Value);
//        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionTVItemModel.Result).Value;
//        Assert.NotNull(errRes);
//        Assert.Equal(0, (from c in dbLocal.TVItems select c).Count());
//        Assert.Equal(0, (from c in dbLocal.TVItemLanguages select c).Count());
//        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), CSSPLogService.ErrRes.ErrList[0]);
//    }
//}

