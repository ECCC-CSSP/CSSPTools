namespace CSSPDBLocalServices.Tests;

public partial class CountryLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_Existing_Good_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        Assert.NotEmpty(webRoot.TVItemModelCountryList);

        TVItemModel tvItemModelCountryToModify = webRoot.TVItemModelCountryList[0];

        string TVTextEN = "Changed Country";
        string TVTextFR = "Pays changé";

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(tvItemModelCountryToModify.TVItem.TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemModel tvItemModelChangedRet = (TVItemModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemModelChangedRet);

        webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        TVItemModel tvItemModelRet = (from c in webRoot.TVItemModelCountryList
                                      where c.TVItem.TVItemID == tvItemModelCountryToModify.TVItem.TVItemID
                                      select c).FirstOrDefault();

        Assert.NotNull(tvItemModelRet);

        CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Modified);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
        {
            webRoot.TVItemModel,
            tvItemModelChangedRet,
        };

        CheckDBLocal(tvItemModelList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(3, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_Good_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        var actionRes = await CountryLocalService.AddCountryLocalAsync(webRoot.TVItemModel.TVItem.TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemModelRet);

        string TVTextEN = "Modified Country";
        string TVTextFR = "Pays modifié";

        var actionRes2 = await CountryLocalService.ModifyTVTextCountryLocalAsync(tvItemModelRet.TVItem.TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        TVItemModel tvItemModelModifiedRet = (TVItemModel)((OkObjectResult)actionRes2.Result).Value;
        Assert.NotNull(tvItemModelModifiedRet);

        webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        tvItemModelRet = (from c in webRoot.TVItemModelCountryList
                          where c.TVItem.TVItemID == tvItemModelRet.TVItem.TVItemID
                          select c).FirstOrDefault();

        Assert.NotNull(tvItemModelRet);

        CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, TVTextEN, LanguageEnum.en); // Created stays created when modified
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr); // Created stays created when modified

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
        {
            webRoot.TVItemModel,
            tvItemModelModifiedRet,
        };

        CheckDBLocal(tvItemModelList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(3, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 5;
        string TVTextEN = "Modified Country";
        string TVTextFR = "Pays modifié";

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 5;
        string TVTextEN = "Modified Country";
        string TVTextFR = "Pays modifié";

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 0;
        string TVTextEN = "Modified Country";
        string TVTextFR = "Pays modifié";

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_TVTextEN_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 5;
        string TVTextEN = "";
        string TVTextFR = "Pays modifié";

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_TVTextFR_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 5;
        string TVTextEN = "Modified Country";
        string TVTextFR = "";

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_CouldNotFind_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        int TVItemID = 100000;
        string TVTextEN = "Modified Country";
        string TVTextFR = "Pays Changé";

        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyCountryLocal_SiblingWithSameName_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        Assert.NotEmpty(webRoot.TVItemModelCountryList);
        Assert.True(webRoot.TVItemModelCountryList.Count > 1);

        TVItemModel tvItemModelCountryToDelete = webRoot.TVItemModelCountryList[1];

        string TVTextEN = webRoot.TVItemModelCountryList[0].TVItemLanguageList[0].TVText;
        string TVTextFR = webRoot.TVItemModelCountryList[0].TVItemLanguageList[1].TVText;

        string message = $"{ TVTextEN } (en)     { TVTextFR } (fr)";

        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, message));
        var actionRes = await CountryLocalService.ModifyTVTextCountryLocalAsync(tvItemModelCountryToDelete.TVItem.TVItemID, TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), errRes.ErrList[0]);
    }
}

