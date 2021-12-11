namespace CSSPReadGzFileServices.Tests;

[Collection("Sequential")]
public partial class CSSPReadGzFileServiceTests
{
    DateTime LastTime = DateTime.Now;

    protected IConfiguration Configuration { get; set; }
    protected IServiceProvider Provider { get; set; }
    protected IServiceCollection Services { get; set; }
    protected ICSSPCultureService CSSPCultureService { get; set; }
    protected IEnums enums { get; set; }
    protected IManageFileService ManageFileService { get; set; }
    protected ICSSPFileService CSSPFileService { get; set; }
    protected ICSSPReadGzFileService CSSPReadGzFileService { get; set; }
    protected ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    protected ICSSPScrambleService CSSPScrambleService { get; set; }
    protected ICSSPLogService CSSPLogService { get; set; }
    protected ICSSPSQLiteService CSSPSQLiteService { get; set; }
    protected ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    protected CSSPDBManageContext dbManage { get; set; }

    protected async Task<bool> CSSPReadGzFileServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspreadgzfileservicestests.json")
           .AddUserSecrets("CSSPReadGzFileServices_Tests")
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

