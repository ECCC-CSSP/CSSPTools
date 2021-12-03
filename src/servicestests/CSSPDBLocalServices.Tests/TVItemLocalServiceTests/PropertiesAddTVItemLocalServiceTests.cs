//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_tvItemParent_null_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvItemParent = null;

//        string errMessage = string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_tvItemParent_TVItemID_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvItemParent.TVItemID = 0;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_TVItemParent_TVLevel_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvItemParent.TVLevel = -1;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVLevel");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_TVItemParent_TVPath_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvItemParent.TVPath = "";

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVPath");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvType = (TVTypeEnum)10000;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvType");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_tvItemParent_TVType_Is_Truly_A_Parent_of_tvItemModel_TVItem_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvType = TVTypeEnum.MWQMSite;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString());

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_tvItemParent_TVType_Is_not_implemented_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        tvItemParent.TVType = TVTypeEnum.BoxModel;
//        tvItemParent.TVLevel = 1;

//        string errMessage = string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- HelperLocalService.CheckTVTypeParentAndTVType";

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_TVTextEN_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        TVTextEN = "";

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_AddTVItemLocal_TVTextFR_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Country";
//        string TVTextFR = "Nouveau Pays";

//        TVTextFR = "";

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR");

//        await CheckPropertyAddTVItemLocalError(tvItemParent, tvType, TVTextEN, TVTextFR, errMessage);
//    }
//}

