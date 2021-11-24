namespace CSSPDBLocalServices.Tests;

public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddHelpDocLocal_Good_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        HelpDoc helpDoc = FillHelpDoc();

        var actionHelpDocRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(200, ((ObjectResult)actionHelpDocRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionHelpDocRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionHelpDocRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(-1, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Created, helpDocRet.DBCommand);
        Assert.Equal(helpDoc.DocHTMLText, helpDocRet.DocHTMLText);
        Assert.Equal(helpDoc.DocKey, helpDocRet.DocKey);
        Assert.Equal(helpDoc.Language, helpDocRet.Language);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocRet.LastUpdateDate_UTC);

        HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                             where c.HelpDocID == -1
                             select c).FirstOrDefault();
        Assert.NotNull(helpDocDB);

        Assert.Equal(JsonSerializer.Serialize(helpDocDB), JsonSerializer.Serialize(helpDocRet));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocWeb = (from c in webAllHelpDocs.HelpDocList
                              where c.HelpDocID == -1
                              select c).FirstOrDefault();
        Assert.NotNull(helpDocWeb);

        await CSSPLogService.Save();

        List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                           select c).ToList();

        Assert.Single(commandLogList);
        Assert.Contains("HelpDocLocalService.AddHelpDocLocal(HelpDoc helpDoc)", commandLogList[0].Log);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddHelpDocLocal_HelpDocID_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        HelpDoc helpDoc = FillHelpDoc();

        helpDoc.HelpDocID = 10;

        var actionHelpDocRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionHelpDocRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionHelpDocRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "HelpDocID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddHelpDocLocal_DocKey_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        HelpDoc helpDoc = FillHelpDoc();

        helpDoc.DocKey = "";

        var actionHelpDocRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionHelpDocRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionHelpDocRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddHelpDocLocal_Language_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        HelpDoc helpDoc = FillHelpDoc();

        helpDoc.Language = (LanguageEnum)10000;

        var actionHelpDocRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionHelpDocRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionHelpDocRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddHelpDocLocal_DocHTMLText_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        HelpDoc helpDoc = FillHelpDoc();

        helpDoc.DocHTMLText = "";

        var actionHelpDocRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionHelpDocRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionHelpDocRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddHelpDocLocal_Return_Existing_HelpDoc_As_It_Already_Exist_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        Assert.True(webAllHelpDocs.HelpDocList.Count > 10);

        HelpDoc helpDoc = FillHelpDoc();

        helpDoc = webAllHelpDocs.HelpDocList[7];

        int HelpDocID = helpDoc.HelpDocID;

        helpDoc.HelpDocID = 0;

        var actionHelpDocRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(200, ((ObjectResult)actionHelpDocRes.Result).StatusCode);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionHelpDocRes.Result).Value;
        helpDoc.HelpDocID = HelpDocID;
        Assert.Equal(JsonSerializer.Serialize(helpDoc), JsonSerializer.Serialize(helpDocRet));
    }
}

