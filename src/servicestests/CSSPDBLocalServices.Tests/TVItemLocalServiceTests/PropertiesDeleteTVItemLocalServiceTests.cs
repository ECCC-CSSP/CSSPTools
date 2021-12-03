//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemParent_null_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent = null;

//        string errMessage = string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent");

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemModel_null_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel = null;

//        string errMessage = string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemModel");

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemParent_TVItemID_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent.TVItemID = 0;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID");

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemParent_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent.TVType = (TVTypeEnum)100000;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType");

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemModel_TVItem_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = (TVTypeEnum)100000;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemModel.TVItem.TVType");

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemParent_TVType_Is_Truly_A_Parent_of_tvItemModel_TVItem_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = TVTypeEnum.MWQMSite;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvItemModel.TVItem.TVType.ToString());

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_DeleteTVItemLocal_tvItemParent_TVType_Is_not_implemented_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent.TVType = TVTypeEnum.BoxModel;
//        tvItemParent.TVLevel = 1;

//        string errMessage = string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- HelperLocalService.CheckTVTypeParentAndTVType";

//        await CheckPropertyDeleteTVItemLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//}

