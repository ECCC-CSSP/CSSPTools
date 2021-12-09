namespace CSSPDBLocalServices.Tests;

public partial class TelLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_Good_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllTels, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        Tel tel = FillTel();

        var actionRes = await TelLocalService.AddTelLocalAsync(tel);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Tel telRet = (Tel)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(telRet);

        Assert.Equal(1, (from c in dbLocal.Tels select c).Count());
        Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

        Assert.Equal(-1, telRet.TelID);
        Assert.Equal(DBCommandEnum.Created, telRet.DBCommand);
        Assert.Equal(-1, telRet.TelTVItemID);
        Assert.Equal(tel.TelNumber, telRet.TelNumber);
        Assert.Equal(tel.TelType, telRet.TelType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, telRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < telRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > telRet.LastUpdateDate_UTC);

        Tel telDB = (from c in dbLocal.Tels
                     where c.TelID == -1
                     select c).FirstOrDefault();
        Assert.NotNull(telDB);

        Assert.Equal(JsonSerializer.Serialize(telDB), JsonSerializer.Serialize(telRet));

        TVItem tvItemDB = (from c in dbLocal.TVItems
                           where c.TVItemID == -1
                           select c).FirstOrDefault();
        Assert.NotNull(tvItemDB);
        Assert.Equal(TVTypeEnum.Tel, tvItemDB.TVType);

        List<TVItemLanguage> tvItemLanguageListDB = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemID == -1
                                                     select c).ToList();
        Assert.NotNull(tvItemLanguageListDB);
        Assert.NotEmpty(tvItemLanguageListDB);
        Assert.Equal(2, tvItemLanguageListDB.Count);

        tel = FillTel();

        tel.TelNumber = "123878423";

        var actionRes2 = await TelLocalService.AddTelLocalAsync(tel);
        Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        Tel telRet2 = (Tel)((OkObjectResult)actionRes2.Result).Value;
        Assert.NotNull(telRet2);

        Assert.Equal(2, (from c in dbLocal.Tels select c).Count());
        Assert.Equal(3, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(6, (from c in dbLocal.TVItemLanguages select c).Count());

        Assert.Equal(-2, telRet2.TelID);
        Assert.Equal(DBCommandEnum.Created, telRet2.DBCommand);
        Assert.Equal(-2, telRet2.TelTVItemID);
        Assert.Equal(tel.TelNumber, telRet2.TelNumber);
        Assert.Equal(tel.TelType, telRet2.TelType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, telRet2.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < telRet2.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > telRet2.LastUpdateDate_UTC);

        Tel telDB2 = (from c in dbLocal.Tels
                      where c.TelID == -2
                      select c).FirstOrDefault();
        Assert.NotNull(telDB2);

        Assert.Equal(JsonSerializer.Serialize(telDB), JsonSerializer.Serialize(telRet));

        TVItem tvItemDB2 = (from c in dbLocal.TVItems
                            where c.TVItemID == -2
                            select c).FirstOrDefault();
        Assert.NotNull(tvItemDB2);
        Assert.Equal(TVTypeEnum.Tel, tvItemDB2.TVType);

        List<TVItemLanguage> tvItemLanguageListDB2 = (from c in dbLocal.TVItemLanguages
                                                      where c.TVItemID == -2
                                                      select c).ToList();
        Assert.NotNull(tvItemLanguageListDB2);
        Assert.NotEmpty(tvItemLanguageListDB2);
        Assert.Equal(2, tvItemLanguageListDB2.Count);

        WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllTels>(WebTypeEnum.WebAllTels, 0);

        Tel telWeb = (from c in webAllTels.TelList
                      where c.TelID == -1
                      select c).FirstOrDefault();
        Assert.NotNull(telWeb);
        Assert.Equal(-1, telWeb.TelTVItemID);

        Tel telWeb2 = (from c in webAllTels.TelList
                       where c.TelID == -2
                       select c).FirstOrDefault();
        Assert.NotNull(telWeb2);
        Assert.Equal(-2, telWeb2.TelTVItemID);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

        TVItemModel tvItemModel = new TVItemModel()
        {
            TVItem = tvItemDB,
            TVItemLanguageList = tvItemLanguageListDB,
        };

        tvItemModelParentList.Add(tvItemModel);

        CheckDBLocal(tvItemModelParentList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(2, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllTels }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel tel = FillTel();

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await TelLocalService.AddTelLocalAsync(tel);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel tel = FillTel();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await TelLocalService.AddTelLocalAsync(tel);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_Tel_null_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel tel = FillTel();

        tel = null;

        var actionRes = await TelLocalService.AddTelLocalAsync(tel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tel"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_TelID_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel tel = FillTel();

        tel.TelID = 10;

        var actionRes = await TelLocalService.AddTelLocalAsync(tel);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TelID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_TelNumber_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel telLocal = FillTel();

        telLocal.TelNumber = "";

        var actionRes = await TelLocalService.AddTelLocalAsync(telLocal);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TelNumber"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_TelNumber_length_50_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel telLocal = FillTel();

        telLocal.TelNumber = "a".PadRight(51);

        var actionRes = await TelLocalService.AddTelLocalAsync(telLocal);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "TelNumber", "50"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_TelType_Error_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        Tel telLocal = FillTel();

        telLocal.TelType = (TelTypeEnum)10000;

        var actionRes = await TelLocalService.AddTelLocalAsync(telLocal);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TelType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddTelLocal_Return_Existing_Tel_As_It_Already_Exist_Test(string culture)
    {
        Assert.True(await TelLocalServiceSetupAsync(culture));

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllTels, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllTels>(WebTypeEnum.WebAllTels, 0);

        Assert.True(webAllTels.TelList.Count > 10);

        Tel telLocal = FillTel();

        telLocal = webAllTels.TelList[7];

        int TelID = telLocal.TelID;

        telLocal.TelID = 0;

        var actionRes = await TelLocalService.AddTelLocalAsync(telLocal);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Tel telLocalRet = (Tel)((OkObjectResult)actionRes.Result).Value;
        telLocal.TelID = TelID;
        Assert.Equal(JsonSerializer.Serialize(telLocal), JsonSerializer.Serialize(telLocalRet));
    }
}

