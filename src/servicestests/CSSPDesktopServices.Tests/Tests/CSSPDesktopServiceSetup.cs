using CSSPDesktopInstallPostBuildServices.Services;

namespace CSSPDesktopServices.Tests;

[Collection("Sequential")]
public partial class CSSPDesktopServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private IManageFileService ManageFileService { get; set; }
    private ICSSPFileService CSSPFileService { get; set; }
    private ICSSPDesktopService CSSPDesktopService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }
    private ICSSPDesktopInstallPostBuildService CSSPDesktopInstallPostBuildService { get; set; }

    private async Task<bool> CSSPDesktopServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspdesktopservicestests.json")
           .AddUserSecrets("CSSPDesktopServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDB"]);
        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.Contains("Test", Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.Contains("Test", Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["CSSPDesktopPath"]);
        Assert.Contains("Test", Configuration["CSSPDesktopPath"]);
        Assert.NotNull(Configuration["CSSPDatabasesPath"]);
        Assert.Contains("Test", Configuration["CSSPDatabasesPath"]);
        Assert.NotNull(Configuration["CSSPWebAPIsLocalPath"]);
        Assert.Contains("Test", Configuration["CSSPWebAPIsLocalPath"]);
        Assert.NotNull(Configuration["CSSPJSONPath"]);
        Assert.Contains("Test", Configuration["CSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
        Assert.Contains("Test", Configuration["CSSPJSONPathLocal"]);
        Assert.NotNull(Configuration["CSSPFilesPath"]);
        Assert.Contains("Test", Configuration["CSSPFilesPath"]);
        Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
        Assert.Contains("Test", Configuration["CSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["CSSPTempFilesPath"]);
        Assert.Contains("Test", Configuration["CSSPTempFilesPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["CSSPLocalUrl"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);
        Assert.NotNull(Configuration["LocalCSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["AfterInstallLocalCSSPJsonPath"]);
        Assert.NotNull(Configuration["AfterInstallLocalCSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["AfterInstallLocalCSSPWebAPIsLocalPath"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<IManageFileService, ManageFileService>();
        Services.AddSingleton<ICSSPFileService, CSSPFileService>();
        Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();
        Services.AddSingleton<ICSSPDesktopService, CSSPDesktopService>();
        Services.AddSingleton<ICSSPDesktopInstallPostBuildService, CSSPDesktopInstallPostBuildService>();

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

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        Assert.NotNull(CSSPScrambleService);

        CSSPLogService = Provider.GetService<ICSSPLogService>();
        Assert.NotNull(CSSPLogService);

        ManageFileService = Provider.GetService<IManageFileService>();
        Assert.NotNull(ManageFileService);

        CSSPFileService = Provider.GetService<ICSSPFileService>();
        Assert.NotNull(CSSPFileService);

        CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
        Assert.NotNull(CSSPSQLiteService);

        CSSPAzureLoginService = Provider.GetService<ICSSPAzureLoginService>();
        Assert.NotNull(CSSPAzureLoginService);

        CSSPDesktopService = Provider.GetService<ICSSPDesktopService>();
        Assert.NotNull(CSSPDesktopService);

        CSSPDesktopInstallPostBuildService = Provider.GetService<ICSSPDesktopInstallPostBuildService>();
        Assert.NotNull(CSSPDesktopInstallPostBuildService);

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        return await Task.FromResult(true);
    }
}

