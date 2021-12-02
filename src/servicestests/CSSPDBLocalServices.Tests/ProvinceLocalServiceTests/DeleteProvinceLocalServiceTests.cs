namespace CSSPDBLocalServices.Tests;

public partial class ProvinceLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_Good_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            //new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        var actionRes = await ProvinceLocalService.AddProvinceLocalAsync(webCountry.TVItemModel.TVItem.TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemModelRet);

        var actionRes2 = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, tvItemModelRet.TVItem.TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        TVItemModel tvItemModelDeleteRet = (TVItemModel)((OkObjectResult)actionRes2.Result).Value;
        Assert.NotNull(tvItemModelDeleteRet);

        webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

        tvItemModelRet = (from c in webCountry.TVItemModelProvinceList
                          where c.TVItem.TVItemID == tvItemModelRet.TVItem.TVItemID
                          select c).FirstOrDefault();

        Assert.NotNull(tvItemModelRet);

        foreach (MapInfoModel mapInfoModel in tvItemModelRet.MapInfoModelList)
        {
            CheckMapInfo(mapInfoModel.MapInfo, DBCommandEnum.Deleted);

            foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
            {
                CheckMapInfoPoint(mapInfoPoint, DBCommandEnum.Deleted);
            }
        }

        CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
        CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
        CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Deleted);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "New Province 1", LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Deleted, "Nouveau Pays 1", LanguageEnum.fr);

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
        {
            webCountry.TVItemModel,
            tvItemModelDeleteRet,
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
    public async Task DeleteProvinceLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_ParentTVItemID_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 0;
        int TVItemID = 7;

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ParentTVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_TVItemID_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 0;

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_CouldNotFind_WebCountry_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 10000;
        int TVItemID = 7;

        string fileName = await BaseGzFileService.GetFileName(WebTypeEnum.WebCountry, ParentTVItemID);

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_, $"{ Configuration["AzureStoreCSSPJsonPath"] }\\{ fileName }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_CouldNotFind_ProvinceItem_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 10000;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            //new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteProvinceLocal_Children_Exist_Error_Test(string culture)
    {
        Assert.True(await ProvinceLocalServiceSetupAsync(culture));

        int ParentTVItemID = 5;
        int TVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = TVItemID },
            new ToRecreate() { WebType = WebTypeEnum.WebCountry, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        var actionRes = await ProvinceLocalService.DeleteProvinceLocalAsync(ParentTVItemID, TVItemID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotDelete_BecauseItIsBeingUsedIn_, "TVItem Province", "Area"), errRes.ErrList[0]);
    }
}

