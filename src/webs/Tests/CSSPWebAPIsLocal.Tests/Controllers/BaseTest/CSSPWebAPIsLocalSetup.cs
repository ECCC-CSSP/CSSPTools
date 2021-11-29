namespace CSSPWebAPIsLocal.Tests;

public partial class CSSPWebAPIsLocalTests
{
    //protected ICountryLocalService CountryLocalService { get; set; }

    protected IConfiguration Configuration { get; set; }
    protected CSSPDBLocalContext dbLocal { get; set; }
    protected CSSPDBManageContext dbManage { get; set; }
    //protected ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    //protected ICSSPLogService CSSPLogService { get; set; }
    //protected ICSSPReadGzFileService CSSPReadGzFileService { get; set; }

    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    //private ICSSPCultureService CSSPCultureService { get; set; }
    //private IEnums enums { get; set; }
    //private ICSSPScrambleService CSSPScrambleService { get; set; }
    //private ICSSPFileService FileService { get; set; }
    //private IManageFileService ManageFileService { get; set; }
    //private ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
    //private CSSPDBContext db { get; set; }
    private FileInfo fiCSSPDBLocal { get; set; }
    private FileInfo fiCSSPDBLocalTest { get; set; }
    private FileInfo fiCSSPDBManage { get; set; }
    private FileInfo fiCSSPDBManageTest { get; set; }

    public CSSPWebAPIsLocalTests()
    {
    }

    protected async Task<bool> CSSPWebAPIsLocalSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapislocaltests.json")
           //.AddUserSecrets("CSSPWebAPIsLocal_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDB"]);
        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["LocalUrl"]);
        Assert.NotNull(Configuration["CSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPJSONPathLocal"]);

        //Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        //Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        //Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        //Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        //Services.AddSingleton<IEnums, Enums>();
        //Services.AddSingleton<IManageFileService, ManageFileService>();
        //Services.AddSingleton<IEnums, Enums>();
        //Services.AddSingleton<ICSSPFileService, CSSPFileService>();
        //Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
        //Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();

        //Services.AddSingleton<ICountryLocalService, CountryLocalService>();

        Assert.True(await DirectoryAndDBSetup());

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        Assert.NotNull(Configuration);

        //CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        //Assert.NotNull(CSSPCultureService);

        //CSSPCultureService.SetCulture(culture);

        //CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        //Assert.NotNull(CSSPLocalLoggedInService);

        //Assert.True(await CSSPLocalLoggedInService.SetLoggedInContactInfo());
        //Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        //Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);

        //CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        //Assert.NotNull(CSSPScrambleService);

        //CSSPLogService = Provider.GetService<ICSSPLogService>();
        //Assert.NotNull(CSSPLogService);

        //enums = Provider.GetService<IEnums>();
        //Assert.NotNull(enums);

        //FileService = Provider.GetService<ICSSPFileService>();
        //Assert.NotNull(FileService);

        //ManageFileService = Provider.GetService<IManageFileService>();
        //Assert.NotNull(ManageFileService);

        //CSSPCreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
        //Assert.NotNull(CSSPCreateGzFileService);

        //CSSPReadGzFileService = Provider.GetService<ICSSPReadGzFileService>();
        //Assert.NotNull(CSSPReadGzFileService);

        //CountryLocalService = Provider.GetService<ICountryLocalService>();
        //Assert.NotNull(CountryLocalService);

        //db = Provider.GetService<CSSPDBContext>();
        //Assert.NotNull(db);

        dbLocal = Provider.GetService<CSSPDBLocalContext>();
        Assert.NotNull(dbLocal);

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        //Assert.True(await ClearSomeTablesOfCSSPDBManage());

        return await Task.FromResult(true);
    }
}

