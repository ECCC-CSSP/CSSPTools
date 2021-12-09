namespace CSSPDBLocalServices.Tests;

[Collection("Sequential")]
public partial class CSSPDBLocalServiceTest
{
    protected IAddressLocalService AddressLocalService { get; set; }
    protected IAppTaskLocalService AppTaskLocalService { get; set; }
    protected IClassificationLocalService ClassificationLocalService { get; set; }
    protected ICountryLocalService CountryLocalService { get; set; }
    protected IEmailLocalService EmailLocalService { get; set; }
    protected IHelpDocLocalService HelpDocLocalService { get; set; }
    protected IMapInfoLocalService MapInfoLocalService { get; set; }
    protected IMWQMLookupMPNLocalService MWQMLookupMPNLocalService { get; set; }
    protected IProvinceLocalService ProvinceLocalService { get; set; }
    protected IRootLocalService RootLocalService { get; set; }
    protected ITelLocalService TelLocalService { get; set; }
    protected ITVItemLocalService TVItemLocalService { get; set; }

    protected IConfiguration Configuration { get; set; }
    protected IServiceProvider Provider { get; set; }
    protected IServiceCollection Services { get; set; }
    protected IEnums enums { get; set; }
    protected ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    protected ICSSPLogService CSSPLogService { get; set; }
    protected ICSSPReadGzFileService CSSPReadGzFileService { get; set; }
    protected IHelperLocalService HelperLocalService { get; set; }
    protected ICSSPSQLiteService CSSPSQLiteService { get; set; }
    protected ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    protected ICSSPCultureService CSSPCultureService { get; set; }
    protected ICSSPScrambleService CSSPScrambleService { get; set; }
    protected ICSSPFileService CSSPFileService { get; set; }
    protected IManageFileService ManageFileService { get; set; }
    protected ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
 
    protected CSSPDBContext db { get; set; }
    protected CSSPDBLocalContext dbLocal { get; set; }
    protected CSSPDBManageContext dbManage { get; set; }

    public CSSPDBLocalServiceTest()
    {

    }

    public async Task<bool> CSSPDBLocalServiceSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspdblocalservicestests.json")
           .AddUserSecrets("CSSPDBLocalServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);
        Assert.NotNull(Configuration);

        Assert.NotNull(Configuration["CSSPDB"]);
        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.NotNull(Configuration["azure_csspjson_backup"]);
        Assert.NotNull(Configuration["CSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
        Assert.NotNull(Configuration["CSSPFilesPath"]);
        Assert.NotNull(Configuration["CSSPTempFilesPath"]);
        Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["CSSPLocalUrl"]);
        Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<IManageFileService, ManageFileService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPFileService, CSSPFileService>();
        Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
        Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

        Services.AddSingleton<IAddressLocalService, AddressLocalService>();
        Services.AddSingleton<IAppTaskLocalService, AppTaskLocalService>();
        Services.AddSingleton<ICountryLocalService, CountryLocalService>();
        Services.AddSingleton<IClassificationLocalService, ClassificationLocalService>();
        Services.AddSingleton<IEmailLocalService, EmailLocalService>();
        Services.AddSingleton<IHelpDocLocalService, HelpDocLocalService>();
        Services.AddSingleton<IHelperLocalService, HelperLocalService>();
        Services.AddSingleton<IMapInfoLocalService, MapInfoLocalService>();
        Services.AddSingleton<IMWQMLookupMPNLocalService, MWQMLookupMPNLocalService>();
        Services.AddSingleton<IProvinceLocalService, ProvinceLocalService>();
        Services.AddSingleton<IRootLocalService, RootLocalService>();
        Services.AddSingleton<ITelLocalService, TelLocalService>();
        Services.AddSingleton<ITVItemLocalService, TVItemLocalService>();

        CheckRequiredDirectories();

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDB"]);
        });

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBManage"] }");
        });

        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBLocal"] }");
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        await GetProviderServicesAsync(culture);

        await GetdbLocalProviderServicesAsync(culture);

        Assert.True(await ClearSomeTablesOfCSSPDBManageAsync());

        DeleteAllJsonFilesInAzureTestStore();
        DeleteAllJsonFilesLocal();
        DeleteAllJsonFiles();
        DeleteAllCSSPFiles();
        DeleteAllCSSPOtherFiles();
        DeleteAllCSSPTempFiles();
        DeleteAllBackupFilesLocal();

        return await Task.FromResult(true);
    }
}

