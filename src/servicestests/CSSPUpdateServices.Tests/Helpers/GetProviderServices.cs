namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private async Task GetProviderServices(string culture)
    {
        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        enums = Provider.GetService<IEnums>();
        Assert.NotNull(enums);

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        Assert.NotNull(CSSPScrambleService);

        CSSPLogService = Provider.GetService<ICSSPLogService>();
        Assert.NotNull(CSSPLogService);

        CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
        Assert.NotNull(CSSPSQLiteService);

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDB"]);
        });

        db = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(db);

        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
        if (!fiCSSPDBLocal.Exists)
        {
            await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync();
        }

        fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
        Assert.True(fiCSSPDBLocal.Exists);

        dbLocal = Provider.GetService<CSSPDBLocalContext>();
        Assert.NotNull(dbLocal);

        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fiCSSPDBManage.Exists)
        {
            await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
        }

        fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        Assert.True(fiCSSPDBManage.Exists);

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);

        CSSPUpdateService = Provider.GetService<ICSSPUpdateService>();
        Assert.NotNull(CSSPUpdateService);

        Contact contact = (from c in dbManage.Contacts
                           select c).FirstOrDefault();

        if (contact == null)
        {
            CSSPAzureLoginService = Provider.GetService<ICSSPAzureLoginService>();
            Assert.NotNull(CSSPAzureLoginService);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            var actionRes = await CSSPAzureLoginService.AzureLoginAsync(loginModel);
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
            Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
            Assert.Empty(CSSPLogService.ErrRes.ErrList);
        }

        contact = (from c in dbManage.Contacts
                   select c).FirstOrDefault();
        Assert.NotNull(contact);
        Assert.NotNull(contact.AzureStoreHash);

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();

        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.Equal(contact.ContactTVItemID, CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID);

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID > 0);

        CSSPCreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
        Assert.NotNull(CSSPCreateGzFileService);
    }
}

