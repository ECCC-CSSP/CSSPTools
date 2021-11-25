namespace CSSPDBLocalServices.Tests;

public partial class RootLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyRootLocal_Existing_Good_Test(string culture)
    {
        Assert.True(await RootLocalServiceSetup(culture));

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        Assert.NotNull(webRoot);

        TVItemModel tvItemModelRootToModify = webRoot.TVItemModel;

        string TVTextEN = "Changed Root";
        string TVTextFR = "Base changé";

        var actionRootRes = await RootLocalService.ModifyTVTextRootLocalAsync(TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionRootRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRootRes.Result).Value);
        TVItemModel tvItemModelChangedRet = (TVItemModel)((OkObjectResult)actionRootRes.Result).Value;
        Assert.NotNull(tvItemModelChangedRet);

        webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        TVItemModel tvItemModelRet = webRoot.TVItemModel;

        Assert.NotNull(tvItemModelRet);

        CheckTVItem(tvItemModelRet, DBCommandEnum.Original);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
        CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

        List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                tvItemModelChangedRet
            };

        CheckDBLocal(tvItemModelList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Single(fiList);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyRootLocal_TVTextEN_Error_Test(string culture)
    {
        Assert.True(await RootLocalServiceSetup(culture));

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        Assert.NotNull(webRoot.TVItemModel);

        TVItemModel tvItemModelRootToModify = webRoot.TVItemModel;

        string TVTextEN = "";
        string TVTextFR = "Base modifié";

        var actionRootRes = await RootLocalService.ModifyTVTextRootLocalAsync(TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRootRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRootRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyRootLocal_TVTextFR_Error_Test(string culture)
    {
        Assert.True(await RootLocalServiceSetup(culture));

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        Assert.NotNull(webRoot.TVItemModel);

        TVItemModel tvItemModelRootToModify = webRoot.TVItemModel;

        string TVTextEN = "Modified Root";
        string TVTextFR = "";

        var actionRootRes = await RootLocalService.ModifyTVTextRootLocalAsync(TVTextEN, TVTextFR);
        Assert.Equal(400, ((ObjectResult)actionRootRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRootRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), errRes.ErrList[0]);
    }
}

