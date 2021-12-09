namespace CSSPDBLocalServices.Tests;

public partial class MWQMLookupMPNLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_Existing_Good_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllMWQMLookupMPNs, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
        Assert.NotNull(webAllMWQMLookupMPNs);
        Assert.NotEmpty(webAllMWQMLookupMPNs.MWQMLookupMPNList);
        Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Count > 5);

        MWQMLookupMPN mwqmLookupMPN = webAllMWQMLookupMPNs.MWQMLookupMPNList[3];

        mwqmLookupMPN.MPN_100ml = 5432;

        var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        MWQMLookupMPN mwqmLookupMPNRet = (MWQMLookupMPN)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(mwqmLookupMPNRet);

        MWQMLookupMPN mwqmLookupMPNDB = (from c in dbLocal.MWQMLookupMPNs
                                         where c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID
                                         select c).FirstOrDefault();
        Assert.NotNull(mwqmLookupMPNDB);

        Assert.Equal(JsonSerializer.Serialize(mwqmLookupMPNDB), JsonSerializer.Serialize(mwqmLookupMPNRet));

        WebAllMWQMLookupMPNs webAllMWQMLookupMPNs2 = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllMWQMLookupMPNs>(WebTypeEnum.WebAllMWQMLookupMPNs, 0);

        MWQMLookupMPN mwqmLookupMPNWeb = (from c in webAllMWQMLookupMPNs2.MWQMLookupMPNList
                                          where c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID
                                          select c).FirstOrDefault();
        Assert.NotNull(mwqmLookupMPNWeb);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_MWQMLookupMPNID_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = FillMWQMLookupMPN();

        mwqmLookupMPN.MWQMLookupMPNID = 0;

        var actionRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "MWQMLookupMPNID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_Tube10_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = FillMWQMLookupMPN();

        mwqmLookupMPN.Tubes10 = -1;

        var actionRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes10", "0", "5"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_Tube1_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = FillMWQMLookupMPN();

        mwqmLookupMPN.Tubes1 = -1;

        var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes1", "0", "5"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_Tube01_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = FillMWQMLookupMPN();

        mwqmLookupMPN.Tubes01 = -1;

        var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Tubes01", "0", "5"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_MPN_100ml_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        MWQMLookupMPN mwqmLookupMPN = FillMWQMLookupMPN();

        mwqmLookupMPN.MPN_100ml = -1;

        var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "MPN_100ml", "1", "99000000"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyMWQMLookupMPNLocal_MWQMLookupMPNID_Not_Found_Error_Test(string culture)
    {
        Assert.True(await MWQMLookupMPNLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllMWQMLookupMPNs, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        MWQMLookupMPN mwqmLookupMPN = FillMWQMLookupMPN();

        mwqmLookupMPN.MWQMLookupMPNID = 10000000;

        var actionPostTVItemModelRes = await MWQMLookupMPNLocalService.ModifyMWQMLookupMPNLocalAsync(mwqmLookupMPN);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString()), errRes.ErrList[0]);
    }
}

