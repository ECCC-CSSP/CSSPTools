namespace CSSPDBLocalServices.Tests;

public partial class CountryLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddCountryLocal_Good_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));
        
        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        var actionRes = await CountryLocalService.AddCountryLocalAsync(webRoot.TVItemModel.TVItem.TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemModelRet);

        CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

        foreach (MapInfoModel mapInfoModel in webRoot.TVItemModel.MapInfoModelList)
        {
            CheckMapInfoEmpty(mapInfoModel.MapInfo);
        }

        CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "New Country 1", LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "Nouveau Pays 1", LanguageEnum.fr);

        foreach (MapInfoModel mapInfoModel in tvItemModelRet.MapInfoModelList)
        {
            CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Created);

            foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
            {
                CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Created);
            }
        }

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
        {
            webRoot.TVItemModel,
            tvItemModelRet,
        };

        CheckDBLocal(tvItemModelList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(3, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());

        var actionRes2 = await CountryLocalService.AddCountryLocalAsync(webRoot.TVItemModel.TVItem.TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        TVItemModel tvItemModelRet2 = (TVItemModel)((OkObjectResult)actionRes2.Result).Value;
        Assert.NotNull(tvItemModelRet2);

        foreach (MapInfoModel mapInfoModel in tvItemModelRet2.MapInfoModelList)
        {
            CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Created);

            foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
            {
                CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Created);
            }
        }

        CheckTVItem(webRoot.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Root", LanguageEnum.en);
        CheckTVItemLanguage(webRoot.TVItemModel, DBCommandEnum.Original, "Base", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "New Country 1", LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, "Nouveau Pays 1", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet2, DBCommandEnum.Created);
        CheckTVItemLanguage(tvItemModelRet2, DBCommandEnum.Created, "New Country 2", LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet2, DBCommandEnum.Created, "Nouveau Pays 2", LanguageEnum.fr);

        List<TVItemModel> tvItemModelList2 = new List<TVItemModel>()
        {
            webRoot.TVItemModel,
            tvItemModelRet,
            tvItemModelRet2,
        };

        CheckDBLocal(tvItemModelList2);

        di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        fiList = di.GetFiles().ToList();

        Assert.Equal(4, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllCountries }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ tvItemModelRet2.TVItem.TVItemID }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddCountryLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int ParentTVItemID = 1;

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CountryLocalService.AddCountryLocalAsync(ParentTVItemID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddCountryLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        int ParentTVItemID = 1;

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CountryLocalService.AddCountryLocalAsync(ParentTVItemID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddCountryLocal_ParentTVItemID_Error_Test(string culture)
    {
        Assert.True(await CountryLocalServiceSetupAsync(culture));

        var actionRes = await CountryLocalService.AddCountryLocalAsync(0);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"), errRes.ErrList[0]);
    }
}

