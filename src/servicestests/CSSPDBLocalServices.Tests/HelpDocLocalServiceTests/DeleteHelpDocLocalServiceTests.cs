namespace CSSPDBLocalServices.Tests;

public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Existing_Good_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllHelpDocs, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);
        Assert.NotNull(webAllHelpDocs);
        Assert.NotEmpty(webAllHelpDocs.HelpDocList);
        Assert.True(webAllHelpDocs.HelpDocList.Count > 5);

        HelpDoc helpDoc = webAllHelpDocs.HelpDocList[3];

        var actionRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(helpDoc.HelpDocID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(helpDoc.HelpDocID, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Deleted, helpDocRet.DBCommand);
        Assert.Equal(helpDoc.DocHTMLText, helpDocRet.DocHTMLText);
        Assert.Equal(helpDoc.DocKey, helpDocRet.DocKey);
        Assert.Equal(helpDoc.Language, helpDocRet.Language);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocRet.LastUpdateDate_UTC);

        HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                             where c.HelpDocID == helpDoc.HelpDocID
                             select c).FirstOrDefault();
        Assert.NotNull(helpDocDB);

        Assert.Equal(JsonSerializer.Serialize(helpDocDB), JsonSerializer.Serialize(helpDocRet));

        webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocDeleted = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDoc.HelpDocID).FirstOrDefault();
        Assert.NotNull(helpDocDeleted);
        Assert.Equal(DBCommandEnum.Deleted, helpDocDeleted.DBCommand);
        Assert.Equal(helpDocDeleted.LastUpdateContactTVItemID, CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocDeleted.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocDeleted.LastUpdateDate_UTC);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Good_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllHelpDocs, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        HelpDoc helpDoc = FillHelpDoc();

        var actionAddRes = await HelpDocLocalService.AddHelpDocLocalAsync(helpDoc);
        Assert.Equal(200, ((ObjectResult)actionAddRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddRes.Result).Value);
        HelpDoc helpDocRet2 = (HelpDoc)((OkObjectResult)actionAddRes.Result).Value;
        Assert.NotNull(helpDocRet2);

        var actionRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(helpDocRet2.HelpDocID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(helpDocRet2.HelpDocID, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Deleted, helpDocRet.DBCommand);
        Assert.Equal(helpDocRet2.DocHTMLText, helpDocRet.DocHTMLText);
        Assert.Equal(helpDocRet2.DocKey, helpDocRet.DocKey);
        Assert.Equal(helpDocRet2.Language, helpDocRet.Language);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocRet.LastUpdateDate_UTC);

        HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                             where c.HelpDocID == helpDoc.HelpDocID
                             select c).FirstOrDefault();
        Assert.NotNull(helpDocDB);

        Assert.Equal(JsonSerializer.Serialize(helpDocDB), JsonSerializer.Serialize(helpDocRet));

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocDeleted = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDoc.HelpDocID).FirstOrDefault();
        Assert.NotNull(helpDocDeleted);
        Assert.Equal(DBCommandEnum.Deleted, helpDocDeleted.DBCommand);
        Assert.Equal(helpDocDeleted.LastUpdateContactTVItemID, CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocDeleted.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocDeleted.LastUpdateDate_UTC);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        HelpDoc helpDoc = FillHelpDoc();

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        int HelpDocID = 1;

        var actionRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(HelpDocID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        HelpDoc helpDoc = FillHelpDoc();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        int HelpDocID = 1;

        var actionRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(HelpDocID);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_HelpDocID_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        int HelpDocID = 0;

        var action = await HelpDocLocalService.DeleteHelpDocLocalAsync(HelpDocID);
        Assert.Equal(400, ((ObjectResult)action.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)action.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "HelpDocID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteHelpDocLocal_Not_Found_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllHelpDocs, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        int HelpDocID = 100000;

        var actionRes = await HelpDocLocalService.DeleteHelpDocLocalAsync(HelpDocID);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", HelpDocID.ToString()), errRes.ErrList[0]);
    }
}

