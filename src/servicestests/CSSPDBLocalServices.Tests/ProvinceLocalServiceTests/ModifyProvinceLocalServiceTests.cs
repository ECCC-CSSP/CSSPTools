namespace CSSPDBLocalServices.Tests;

public partial class ProvinceLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_Existing_Good_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        string TVTextEN = "Changed Province";
        string TVTextFR = "Province changé";

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemModel tvItemModelChangedRet = (TVItemModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemModelChangedRet);

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, 5);

        TVItemModel tvItemModelRet = (from c in webCountry.TVItemModelProvinceList
                                      where c.TVItem.TVItemID == TVItemID
                                      select c).FirstOrDefault();

        Assert.NotNull(tvItemModelRet);

        CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
        CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Modified);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
        {
            webCountry.TVItemModel,
            tvItemModelChangedRet,
        };

        CheckDBLocal(tvItemModelList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(3, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_Good_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        //int TVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        var actionAddRes = await ProvinceLocalService.AddProvinceLocalAsync(ParentTVItemID);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        TVItemModel tvItemAddRet = (TVItemModel)((OkObjectResult)actionAddRes.Result).Value;

        string TVTextEN = "Changed Province";
        string TVTextFR = "Province changé";

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, tvItemAddRet.TVItem.TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemModel tvItemModifyRet = (TVItemModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemModifyRet);

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, 5);

        TVItemModel tvItemModelRet = (from c in webCountry.TVItemModelProvinceList
                                      where c.TVItem.TVItemID == tvItemAddRet.TVItem.TVItemID
                                      select c).FirstOrDefault();

        Assert.NotNull(tvItemModelRet);

        CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
        CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
        {
            webCountry.TVItemModel,
            tvItemAddRet,
        };

        CheckDBLocal(tvItemModelList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(3, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        string TVTextEN = "Modified Province";
        string TVTextFR = "Province modifié";

        int ParentTVItemID = 0;
        int TVItemID = 7;

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        string TVTextEN = "Modified Province";
        string TVTextFR = "Province modifié";

        int ParentTVItemID = 0;
        int TVItemID = 7;

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_ParentTVItemID_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        string TVTextEN = "Modified Province";
        string TVTextFR = "Province modifié";

        int ParentTVItemID = 0;
        int TVItemID = 7;

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_TVItemID_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        string TVTextEN = "Modified Province";
        string TVTextFR = "Province modifié";

        int ParentTVItemID = 5;
        int TVItemID = 0;

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_TVTextEN_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        string TVTextEN = "";
        string TVTextFR = "Province modifié";

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_TVTextEN_length_200_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        string TVTextEN = "a".PadRight(201);
        string TVTextFR = "Province modifié";

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVTextEN", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_TVTextFR_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        string TVTextEN = "Province modified";
        string TVTextFR = "";

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_TVTextFR_length_200_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        string TVTextEN = "Province modified";
        string TVTextFR = "a".PadRight(201);

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TVTextFR", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_CouldNotFind_WebCountry_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        ParentTVItemID = 1000000;

        string TVTextEN = "Province modified";
        string TVTextFR = "Province modifier";

        string fileName = await BaseGzFileService.GetFileName(WebTypeEnum.WebCountry, ParentTVItemID);

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_, $"{ Configuration["AzureStoreCSSPJsonPath"] }\\{ fileName }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_CouldNotFind_Province_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 100000;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        string TVTextEN = "Modified Province";
        string TVTextFR = "Province Changé";

        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyProvinceLocal_SiblingWithSameName_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        Assert.NotEmpty(webCountry.TVItemModelProvinceList);
        Assert.True(webCountry.TVItemModelProvinceList.Count > 1);

        TVItemModel tvItemModelProvinceToDelete = webCountry.TVItemModelProvinceList[1];

        string TVTextEN = webCountry.TVItemModelProvinceList[0].TVItemLanguageList[0].TVText;
        string TVTextFR = webCountry.TVItemModelProvinceList[0].TVItemLanguageList[1].TVText;

        string message = $"{ TVTextEN } (en)     { TVTextFR } (fr)";

        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, message));
        var actionRes = await ProvinceLocalService.ModifyTVTextProvinceLocalAsync(webCountry.TVItemModel.TVItem.TVItemID, tvItemModelProvinceToDelete.TVItem.TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), errRes.ErrList[0]);
    }
}

