namespace CSSPDBLocalServices.Tests;

public partial class EmailLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_Good_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllEmails, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        Email email = FillEmail();

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(200, ((ObjectResult)actionEmailRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionEmailRes.Result).Value);
        Email emailRet = (Email)((OkObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(emailRet);

        Assert.Equal(1, (from c in dbLocal.Emails select c).Count());
        Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

        Assert.Equal(-1, emailRet.EmailID);
        Assert.Equal(DBCommandEnum.Created, emailRet.DBCommand);
        Assert.Equal(-1, emailRet.EmailTVItemID);
        Assert.Equal(email.EmailAddress, emailRet.EmailAddress);
        Assert.Equal(email.EmailType, emailRet.EmailType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, emailRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < emailRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > emailRet.LastUpdateDate_UTC);

        Email emailDB = (from c in dbLocal.Emails
                         where c.EmailID == -1
                         select c).FirstOrDefault();
        Assert.NotNull(emailDB);

        Assert.Equal(JsonSerializer.Serialize(emailDB), JsonSerializer.Serialize(emailRet));

        TVItem tvItemDB = (from c in dbLocal.TVItems
                           where c.TVItemID == -1
                           select c).FirstOrDefault();
        Assert.NotNull(tvItemDB);
        Assert.Equal(TVTypeEnum.Email, tvItemDB.TVType);

        List<TVItemLanguage> tvItemLanguageListDB = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemID == -1
                                                     select c).ToList();
        Assert.NotNull(tvItemLanguageListDB);
        Assert.NotEmpty(tvItemLanguageListDB);
        Assert.Equal(2, tvItemLanguageListDB.Count);

        email = FillEmail();

        email.EmailAddress = "NewEmailAddress@gmail.com";

        var actionEmailRes2 = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(200, ((ObjectResult)actionEmailRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionEmailRes2.Result).Value);
        Email emailRet2 = (Email)((OkObjectResult)actionEmailRes2.Result).Value;
        Assert.NotNull(emailRet2);

        Assert.Equal(2, (from c in dbLocal.Emails select c).Count());
        Assert.Equal(3, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(6, (from c in dbLocal.TVItemLanguages select c).Count());

        Assert.Equal(-2, emailRet2.EmailID);
        Assert.Equal(DBCommandEnum.Created, emailRet2.DBCommand);
        Assert.Equal(-2, emailRet2.EmailTVItemID);
        Assert.Equal(email.EmailAddress, emailRet2.EmailAddress);
        Assert.Equal(email.EmailType, emailRet2.EmailType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, emailRet2.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < emailRet2.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > emailRet2.LastUpdateDate_UTC);

        Email emailDB2 = (from c in dbLocal.Emails
                          where c.EmailID == -2
                          select c).FirstOrDefault();
        Assert.NotNull(emailDB2);

        Assert.Equal(JsonSerializer.Serialize(emailDB), JsonSerializer.Serialize(emailRet));

        TVItem tvItemDB2 = (from c in dbLocal.TVItems
                            where c.TVItemID == -2
                            select c).FirstOrDefault();
        Assert.NotNull(tvItemDB2);
        Assert.Equal(TVTypeEnum.Email, tvItemDB2.TVType);

        List<TVItemLanguage> tvItemLanguageListDB2 = (from c in dbLocal.TVItemLanguages
                                                      where c.TVItemID == -2
                                                      select c).ToList();
        Assert.NotNull(tvItemLanguageListDB2);
        Assert.NotEmpty(tvItemLanguageListDB2);
        Assert.Equal(2, tvItemLanguageListDB2.Count);

        WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

        Email emailWeb = (from c in webAllEmails.EmailList
                          where c.EmailID == -1
                          select c).FirstOrDefault();
        Assert.NotNull(emailWeb);
        Assert.Equal(-1, emailWeb.EmailTVItemID);

        Email emailWeb2 = (from c in webAllEmails.EmailList
                           where c.EmailID == -2
                           select c).FirstOrDefault();
        Assert.NotNull(emailWeb2);
        Assert.Equal(-2, emailWeb2.EmailTVItemID);

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

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllEmails }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(401, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(401, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_Email_null_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        email = null;

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Email"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_EmailID_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        email.EmailID = 10;

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "EmailID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_EmailAddress_Required_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        email.EmailAddress = "";

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "EmailAddress"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_EmailAddress_length_255_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        email.EmailAddress = "a".PadRight(256);

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "EmailAddress", "255"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_EmailAddress_Valid_Email_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        email.EmailAddress = "lasjlfiajslefij";

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, email.EmailAddress), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_EmailType_Error_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        Email email = FillEmail();

        email.EmailType = (EmailTypeEnum)10000;

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(400, ((ObjectResult)actionEmailRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionEmailRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "EmailType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddEmailLocal_Return_Existing_Email_As_It_Already_Exist_Test(string culture)
    {
        Assert.True(await EmailLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllEmails, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

        Assert.True(webAllEmails.EmailList.Count > 10);

        Email email = FillEmail();

        email = webAllEmails.EmailList[7];

        int EmailID = email.EmailID;

        email.EmailID = 0;

        var actionEmailRes = await EmailLocalService.AddEmailLocalAsync(email);
        Assert.Equal(200, ((ObjectResult)actionEmailRes.Result).StatusCode);
        Email emailRet = (Email)((OkObjectResult)actionEmailRes.Result).Value;
        email.EmailID = EmailID;
        Assert.Equal(JsonSerializer.Serialize(email), JsonSerializer.Serialize(emailRet));
    }
}

