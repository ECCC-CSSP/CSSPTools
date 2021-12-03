//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Root_Country_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webRoot.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVTextEN = webRoot.TVItemModelCountryList[0].TVItemLanguageList[0].TVText;
//        TVTextFR = webRoot.TVItemModelCountryList[0].TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Root_Address_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // No test required here
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Root_Email_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // no test required here
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Root_Tel_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // no test required here
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Country_Province_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 5;

//        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Province;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webCountry.TVItemModelProvinceList);

//        TVTextEN = webCountry.TVItemModelProvinceList[0].TVItemLanguageList[0].TVText;
//        TVTextFR = webCountry.TVItemModelProvinceList[0].TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Country_RainExceedance_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 5;

//        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.RainExceedance;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webCountry.RainExceedanceModelList);

//        TVTextEN = webCountry.RainExceedanceModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webCountry.RainExceedanceModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Country_EmailDistributionList_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // no test required here
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Province_Area_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Area;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webProvince.TVItemModelAreaList);

//        TVTextEN = webProvince.TVItemModelAreaList[0].TVItemLanguageList[0].TVText;
//        TVTextFR = webProvince.TVItemModelAreaList[0].TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Province_SamplingPlan_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // no test required here
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Province_Municipality_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Municipality;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webProvince.TVItemModelMunicipalityList);

//        TVTextEN = webProvince.TVItemModelMunicipalityList[0].TVItemLanguageList[0].TVText;
//        TVTextFR = webProvince.TVItemModelMunicipalityList[0].TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Province_ClimateSite_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);
//        WebClimateSites webClimateSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebClimateSites>(WebTypeEnum.WebClimateSites, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.ClimateSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webClimateSites.ClimateSiteModelList);

//        TVTextEN = webClimateSites.ClimateSiteModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webClimateSites.ClimateSiteModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Province_HydrometricSite_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);
//        WebHydrometricSites webHydrometricSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebHydrometricSites>(WebTypeEnum.WebHydrometricSites, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webHydrometricSites.HydrometricSiteModelList);

//        TVTextEN = webHydrometricSites.HydrometricSiteModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webHydrometricSites.HydrometricSiteModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Province_TideSite_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);
//        WebTideSites webTideSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebTideSites>(WebTypeEnum.WebTideSites, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.TideSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webTideSites.TideSiteModelList);

//        TVTextEN = webTideSites.TideSiteModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webTideSites.TideSiteModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Municipality_Infrastructure_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Infrastructure;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webMunicipality.InfrastructureModelList);

//        TVTextEN = webMunicipality.InfrastructureModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webMunicipality.InfrastructureModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Municipality_MikeScenario_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);
//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeScenario;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        Assert.NotEmpty(webMikeScenarios.MikeScenarioModelList);

//        TVTextEN = webMikeScenarios.MikeScenarioModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webMikeScenarios.MikeScenarioModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_MikeScenario_MikeSource_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeSource;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(mikeScenarioModel.MikeSourceModelList);

//        TVTextEN = mikeScenarioModel.MikeSourceModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = mikeScenarioModel.MikeSourceModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_MikeScenario_MikeBoundaryConditionMesh_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionMesh).ToList();

//        Assert.NotEmpty(mikeBoundaryConditionModelList);

//        TVTextEN = mikeBoundaryConditionModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = mikeBoundaryConditionModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_MikeScenario_MikeBoundaryConditionWebTide_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.MikeBoundaryCondition.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).ToList();

//        Assert.NotEmpty(mikeBoundaryConditionModelList);

//        TVTextEN = mikeBoundaryConditionModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = mikeBoundaryConditionModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Area_Sector_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 629;

//        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

//        TVItem tvItemParent = webArea.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Sector;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webArea.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webArea.TVItemModelSectorList);

//        TVTextEN = webArea.TVItemModelSectorList[0].TVItemLanguageList[0].TVText;
//        TVTextFR = webArea.TVItemModelSectorList[0].TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Sector_Subsector_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 633;

//        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

//        TVItem tvItemParent = webSector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Subsector;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webSector.TVItemModelSubsectorList);

//        TVTextEN = webSector.TVItemModelSubsectorList[0].TVItemLanguageList[0].TVText;
//        TVTextFR = webSector.TVItemModelSubsectorList[0].TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Subsector_MWQMRun_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);
//        WebMWQMRuns webMWQMRuns = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMRuns>(WebTypeEnum.WebMWQMRuns, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MWQMRun;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webMWQMRuns.MWQMRunModelList);

//        TVTextEN = webMWQMRuns.MWQMRunModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webMWQMRuns.MWQMRunModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Subsector_MWQMSite_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);
//        WebMWQMSites webMWQMSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMWQMSites>(WebTypeEnum.WebMWQMSites, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MWQMSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webMWQMSites.MWQMSiteModelList);

//        TVTextEN = webMWQMSites.MWQMSiteModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webMWQMSites.MWQMSiteModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Subsector_PolSourceSite_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);
//        WebPolSourceSites webPolSourceSites = await CSSPReadGzFileService.GetUncompressJSONAsync<WebPolSourceSites>(WebTypeEnum.WebPolSourceSites, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.PolSourceSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webPolSourceSites.PolSourceSiteModelList);

//        TVTextEN = webPolSourceSites.PolSourceSiteModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webPolSourceSites.PolSourceSiteModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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
//    public async Task AddTVItemLocal_Subsector_Classification_Already_Exist_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Classification;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        Assert.NotEmpty(webSubsector.ClassificationModelList);

//        TVTextEN = webSubsector.ClassificationModelList[0].TVItemModel.TVItemLanguageList[0].TVText;
//        TVTextFR = webSubsector.ClassificationModelList[0].TVItemModel.TVItemLanguageList[1].TVText;

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

