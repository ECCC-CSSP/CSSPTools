namespace CSSPDBLocalServices.Tests;

public partial class CountryLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteCountryLocal_Good_Test(string culture)
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

        var actionRes2 = await CountryLocalService.DeleteCountryLocalAsync(tvItemModelRet.TVItem.TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        TVItemModel tvItemModelDeleteRet = (TVItemModel)((OkObjectResult)actionRes2.Result).Value;
        Assert.NotNull(tvItemModelDeleteRet);

        webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        tvItemModelRet = (from c in webRoot.TVItemModelCountryList
                          where c.TVItem.TVItemID == tvItemModelRet.TVItem.TVItemID
                          select c).FirstOrDefault();

        Assert.NotNull(tvItemModelRet);

        foreach (MapInfoModel mapInfoModel in tvItemModelDeleteRet.MapInfoModelList)
        {
            CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Deleted);

            foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
            {
                CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Deleted);
            }
        }

        CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Deleted);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "New Country 1", LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "Nouveau Pays 1", LanguageEnum.fr);

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                webRoot.TVItemModel,
                tvItemModelDeleteRet,
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
    public async Task DeleteCountryLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 1;

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteCountryLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 1;

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteCountryLocal_TVItemID_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 0;

        var actionRes = await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteCountryLocal_CouldNotFind_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        int TVItemID = 10000;

        var actionRes = await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteCountryLocal_Children_Exist_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int TVItemID = 5;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = TVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        var actionRes = await CountryLocalService.DeleteCountryLocalAsync(TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_Because_ChildrenExist, "TVItem Country", "Province"), errRes.ErrList[0]);
    }
}

