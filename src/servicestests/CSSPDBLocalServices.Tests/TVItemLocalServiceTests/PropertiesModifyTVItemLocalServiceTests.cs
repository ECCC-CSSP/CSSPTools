//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemParent_null_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent = null;

//        string errMessage = string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_null_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel = null;

//        string errMessage = string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemModel");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemParent_TVItemID_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent.TVItemID = 0;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemParent_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent.TVType = (TVTypeEnum)100000;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItem_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = (TVTypeEnum)100000;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "tvItemModel.TVItem.TVType");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemParent_TVType_Is_Truly_A_Parent_of_tvItemModel_TVItem_TVType_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = TVTypeEnum.MWQMSite;

//        string errMessage = string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvItemModel.TVItem.TVType.ToString());

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemParent_TVType_Is_not_implemented_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemParent.TVType = TVTypeEnum.BoxModel;
//        tvItemParent.TVLevel = 1;

//        string errMessage = string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- HelperLocalService.CheckTVTypeParentAndTVType";

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItemLanguageList_Count_2_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItemLanguageList.Remove(tvItemModel.TVItemLanguageList[0]);

//        string errMessage = string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "tvItemModel.TVItemLanguageList.Count", 2);

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItemLanguageList_TVTextEN_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        tvItemModel.TVItemLanguageList[0].TVText = "";

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "TVText (en)");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItemLanguageList_TVTextFR_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        tvItemModel.TVItemLanguageList[1].TVText = "";

//        string errMessage = string.Format(CSSPCultureServicesRes._IsRequired, "TVText (fr)");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItem_TVType_Address_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = TVTypeEnum.Address;

//        string errMessage = string.Format(CSSPCultureServicesRes.ModifyOf_IsNotAllowed, "Address");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItem_TVType_Email_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = TVTypeEnum.Email;

//        string errMessage = string.Format(CSSPCultureServicesRes.ModifyOf_IsNotAllowed, "Email");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task Properties_ModifyTVTextLocal_tvItemModel_TVItem_TVType_Tel_Error_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;

//        Assert.NotEmpty(webRoot.TVItemModelCountryList);

//        TVItemModel tvItemModel = webRoot.TVItemModelCountryList[0];

//        tvItemModel.TVItem.TVType = TVTypeEnum.Tel;

//        string errMessage = string.Format(CSSPCultureServicesRes.ModifyOf_IsNotAllowed, "Tel");

//        await CheckPropertyModifyTVTextLocalError(tvItemParent, tvItemModel, errMessage);
//    }
//}

