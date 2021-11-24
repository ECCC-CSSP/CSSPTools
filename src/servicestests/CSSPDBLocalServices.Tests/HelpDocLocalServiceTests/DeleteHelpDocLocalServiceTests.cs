namespace CSSPDBLocalServices.Tests;

public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Good_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        var actionPostTVItemModelRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(helpDoc);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(-1, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Deleted, helpDocRet.DBCommand);
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

        webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocDeleted = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == -1).FirstOrDefault();
        Assert.NotNull(helpDocDeleted);
        Assert.Equal(DBCommandEnum.Deleted, helpDocDeleted.DBCommand);

        await CSSPLogService.Save();

        List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                           select c).ToList();

        Assert.Single(commandLogList);
        Assert.Contains("HelpDocLocalService.DeleteHelpDocLocal(HelpDoc helpDoc)", commandLogList[0].Log);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_HelpDocID_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.HelpDocID = 0;

        var actionPostTVItemModelRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Not_Found_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetup(culture));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSON<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        helpDoc.HelpDocID = 100000;

        var actionPostTVItemModelRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(helpDoc);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", helpDoc.HelpDocID.ToString()), errRes.ErrList[0]);
    }
}

