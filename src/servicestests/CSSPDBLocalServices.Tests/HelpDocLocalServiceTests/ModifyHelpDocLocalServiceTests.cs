namespace CSSPDBLocalServices.Tests;

public partial class HelpDocLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Existing_Good_Test(string culture)
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

        string DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(helpDoc.HelpDocID, DocHTMLText);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(1, (from c in dbLocal.HelpDocs select c).Count());

        webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocModified = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDoc.HelpDocID).FirstOrDefault();
        Assert.NotNull(helpDocModified);
        Assert.Equal(DBCommandEnum.Modified, helpDocModified.DBCommand);
        Assert.Equal(DocHTMLText, helpDocModified.DocHTMLText);

        Assert.Equal(helpDoc.HelpDocID, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Modified, helpDocRet.DBCommand);
        Assert.Equal(helpDocModified.DocHTMLText, helpDocRet.DocHTMLText);
        Assert.Equal(helpDocModified.DocKey, helpDocRet.DocKey);
        Assert.Equal(helpDocModified.Language, helpDocRet.Language);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocRet.LastUpdateDate_UTC);

        HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                             where c.HelpDocID == helpDoc.HelpDocID
                             select c).FirstOrDefault();
        Assert.NotNull(helpDocDB);

        Assert.Equal(JsonSerializer.Serialize(helpDocDB), JsonSerializer.Serialize(helpDocRet));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Good_Test(string culture)
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

        string DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(helpDocRet2.HelpDocID, DocHTMLText);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        HelpDoc helpDocRet = (HelpDoc)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(helpDocRet);

        Assert.Equal(1, (from c in dbLocal.HelpDocs select c).Count());

        WebAllHelpDocs webAllHelpDocs = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllHelpDocs>(WebTypeEnum.WebAllHelpDocs, 0);

        HelpDoc helpDocModified = webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID == helpDoc.HelpDocID).FirstOrDefault();
        Assert.NotNull(helpDocModified);
        Assert.Equal(DBCommandEnum.Modified, helpDocModified.DBCommand);
        Assert.Equal(DocHTMLText, helpDocModified.DocHTMLText);

        Assert.Equal(helpDoc.HelpDocID, helpDocRet.HelpDocID);
        Assert.Equal(DBCommandEnum.Modified, helpDocRet.DBCommand);
        Assert.Equal(helpDocModified.DocHTMLText, helpDocRet.DocHTMLText);
        Assert.Equal(helpDocModified.DocKey, helpDocRet.DocKey);
        Assert.Equal(helpDocModified.Language, helpDocRet.Language);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, helpDocRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < helpDocRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > helpDocRet.LastUpdateDate_UTC);

        HelpDoc helpDocDB = (from c in dbLocal.HelpDocs
                             where c.HelpDocID == helpDoc.HelpDocID
                             select c).FirstOrDefault();
        Assert.NotNull(helpDocDB);

        Assert.Equal(JsonSerializer.Serialize(helpDocDB), JsonSerializer.Serialize(helpDocRet));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        int HelpDocID = 0;
        string DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(HelpDocID, DocHTMLText);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        int HelpDocID = 0;
        string DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(HelpDocID, DocHTMLText);
        Assert.Equal(401, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_HelpDocID_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        int HelpDocID = 0;
        string DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(HelpDocID, DocHTMLText);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "HelpDocID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_DocHTMLText_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        int HelpDocID = 1;
        string DocHTMLText = "";

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(HelpDocID, DocHTMLText);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "DocHTMLText"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_DocHTMLText_length_100000_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        int HelpDocID = 1;
        string DocHTMLText = "a".PadRight(100001);

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(HelpDocID, DocHTMLText);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "DocHTMLText", "100000"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task ModifyHelpDocLocal_HelpDocID_Not_Found_Error_Test(string culture)
    {
        Assert.True(await HelpDocLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllHelpDocs, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        int HelpDocID = 10000000;
        string DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>";

        var actionRes = await HelpDocLocalService.ModifyDocHTMLTextHelpDocLocalAsync(HelpDocID, DocHTMLText);
        Assert.Equal(400, ((ObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "HelpDoc", "HelpDocID", HelpDocID.ToString()), errRes.ErrList[0]);
    }
}

