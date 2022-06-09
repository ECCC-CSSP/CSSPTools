namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private IEnums enums { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
    public ICSSPUpdateService CSSPUpdateService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBContext db { get; set; }
    private CSSPDBManageContext dbManage { get; set; }
    private CSSPDBLocalContext dbLocal { get; set; }

    private async Task<bool> CSSPUpdateServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspupdateservicestests.json")
           .AddUserSecrets("CSSPUpdateServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["azure_csspjson_backup"]);
        Assert.Contains("_test", Configuration["azure_csspjson_backup"]);
        Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.Contains("_test", Configuration["azure_csspjson_backup_uncompress"]);
        Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.Contains("csspwebapis.", Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["CSSPLocalUrl"]);
        Assert.Contains("localhost:", Configuration["CSSPLocalUrl"]);
        Assert.NotNull(Configuration["CSSPDatabasesPath"]);
        Assert.Contains("Test", Configuration["CSSPDatabasesPath"]);
        Assert.NotNull(Configuration["CSSPDesktopPath"]);
        Assert.Contains("Test", Configuration["CSSPDesktopPath"]);
        Assert.NotNull(Configuration["CSSPDB"]);
        Assert.Contains("Server=.", Configuration["CSSPDB"]);
        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.Contains("Test", Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.Contains("Test", Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["CSSPFilesPath"]);
        Assert.Contains("Test", Configuration["CSSPFilesPath"]);
        Assert.NotNull(Configuration["CSSPJSONPath"]);
        Assert.Contains("Test", Configuration["CSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
        Assert.Contains("Test", Configuration["CSSPJSONPathLocal"]);
        Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
        Assert.Contains("Test", Configuration["CSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["CSSPTempFilesPath"]);
        Assert.Contains("Test", Configuration["CSSPTempFilesPath"]);
        Assert.NotNull(Configuration["LocalAppDataPath"]);
        Assert.NotNull(Configuration["NationalBackupAppDataPath"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();
        Services.AddSingleton<ICSSPUpdateService, CSSPUpdateService>();

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

        await GetProviderServices(culture);

        ClearCommandLogs();
        ClearManageFiles();

        DeleteAllTestBackupFilesLocal();
        DeleteAllTestFiles();
        DeleteAllTestFilesInAzure();
        DeleteAllTestJsonFiles();
        DeleteAllTestJsonFilesInAzure();
        DeleteAllTestJsonFilesLocal();
        DeleteAllTestLocalAppDataDirectory();
        DeleteAllTestExternalHardDriveAppDataDirectory();
        DeleteAllTestNationalBackupAppDataDirectory();
        DeleteAllTestOtherFiles();
        DeleteAllTestTempFiles();

        return await Task.FromResult(true);
    }
}

