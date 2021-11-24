namespace CSSPDBLocalServices.Tests;

public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Good_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocalAsync(helpDoc);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(1, (from c in dbLocal.HelpDocs select c).Count());

        webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocModified = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == -1).FirstOrDefault();
        Assert.NotNull(helpDocModified);
        Assert.Equal(DBCommandEnum.Modified, helpDocModified.DBCommand);
        Assert.Equal("<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>", helpDocModified.DocHTMLText);

        Assert.Equal(-1, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Modified, helpDocRet.DBCommand);
        Assert.Equal(helpDocModified.DocHTMLText, helpDocRet.DocHTMLText);
        Assert.Equal(helpDocModified.DocKey, helpDocRet.DocKey);
        Assert.Equal(helpDocModified.Language, helpDocRet.Language);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocRet.LastUpdateDate_UTC);

        HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                             where c.HelpDocID == -1
                             select c).FirstOrDefault();
        Assert.NotNull(helpDocDB);

        Assert.Equal(JsonSerializer.Serialize(helpDocDB), JsonSerializer.Serialize(helpDocRet));

        await CSSPLogService.Save();

        List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                           select c).ToList();

        Assert.Single(commandLogList);
        Assert.Contains("HelpDocLocalService.ModifyHelpDocLocal(HelpDoc helpDoc)", commandLogList[0].Log);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_HelpDocID_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.HelpDocID = 0;

        var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "HelpDocID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_DocKey_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.DocKey = "";

        var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocKey"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Language_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.Language = (LanguageEnum)10000;

        var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_DocHTMLText_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.DocHTMLText = "";

        var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_HelpDocID_Not_Found_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.HelpDocID = 10000000;

        var actionPostTVItemModelRes = await HelpDocLocalService.ModifyHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDoc.HelpDocID.ToString()), errRes.ErrList[0]);
    }
}

