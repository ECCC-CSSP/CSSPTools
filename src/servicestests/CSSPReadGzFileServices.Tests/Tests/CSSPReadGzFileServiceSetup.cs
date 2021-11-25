namespace CSSPReadGzFileServices.Tests;

[Collection("Sequential")]
public partial class CSSPReadGzFileServiceTests
{
    DateTime LastTime = DateTime.Now;

    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private IEnums enums { get; set; }
    private IManageFileService ManageFileService { get; set; }
    private ICSSPFileService CSSPFileService { get; set; }
    private ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
    private ICSSPReadGzFileService CSSPReadGzFileService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> CSSPReadGzFileServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspreadgzfileservicestests.json")
           .AddUserSecrets("dec2fcbb-e800-447d-859c-16f40cffb968")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDB"]);
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
        Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["CSSPLocalUrl"]);
        Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.Contains("_test", Configuration["azure_csspjson_backup_uncompress"]);
        Assert.NotNull(Configuration["azure_csspjson_backup"]);
        Assert.Contains("_test", Configuration["azure_csspjson_backup"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<IManageFileService, ManageFileService>();
        Services.AddSingleton<ICSSPFileService, CSSPFileService>();
        Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
        Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

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

        DeleteAllJsonFilesInAzureTestStore();
        DeleteAllJsonFilesLocal();
        DeleteAllBackupFilesLocal();

        return await Task.FromResult(true);
    }
}

