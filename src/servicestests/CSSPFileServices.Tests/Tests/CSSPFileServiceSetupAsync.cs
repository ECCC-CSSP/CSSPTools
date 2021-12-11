namespace CSSPFileServices.Tests;

[Collection("Sequential")]

public partial class FileServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private IEnums enums { get; set; }
    private IManageFileService ManageFileService { get; set; }
    private ICSSPFileService CSSPFileService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPReadGzFileService CSSPReadGzFileService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }
    private Contact contact { get; set; }

    private async Task<bool> CSSPFileServiceSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspfileservicestests.json")
           .AddUserSecrets("CSSPFileServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

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
        Assert.Contains("test", Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
        Services.AddSingleton<IManageFileService, ManageFileService>();
        Services.AddSingleton<ICSSPFileService, CSSPFileService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

        CheckRequiredDirectories();

        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBLocal"] }");
        });

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBManage"] }");
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        await GetProviderServices(culture);

        ClearCommandLogs();
        ClearManageFiles();

        ClearDirectory(Configuration["CSSPFilesPath"]);
        ClearDirectory(Configuration["CSSPJSONPath"]);
        ClearDirectory(Configuration["CSSPOtherFilesPath"]);
        ClearDirectory(Configuration["CSSPTempFilesPath"]);

        DeleteAllFilesInAzureTestStore();
        DeleteAllJsonFilesInAzureTestStore();

        return await Task.FromResult(true);
    }
}

