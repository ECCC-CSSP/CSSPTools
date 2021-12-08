namespace CSSPDesktopInstallPostBuildServices.Tests;

[Collection("Sequential")]
public partial class CSSPDesktopInstallPostBuildServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPDesktopInstallPostBuildService CSSPDesktopInstallPostBuildService { get; set; }

    private async Task<bool> CSSPDesktopInstallPostBuildServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspdesktopinstallpostbuildservicestests.json")
           .AddUserSecrets("CSSPDesktopInstallPostBuildServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPClientPath"]);
        Assert.NotNull(Configuration["CSSPClientZipFile"]);
        Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["CSSPOtherFilesZipFile"]);
        Assert.NotNull(Configuration["CSSPWebAPIsLocalPath"]);
        Assert.NotNull(Configuration["CSSPWebAPIsLocalZipFile"]);
        Assert.NotNull(Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
        Assert.Contains("test", Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPDesktopInstallPostBuildService, CSSPDesktopInstallPostBuildService>();

        List<string> DirList = new List<string>()
        {
            Configuration["CSSPClientPath"],
            Configuration["CSSPOtherFilesPath"],
            Configuration["CSSPWebAPIsLocalPath"],
        };

        foreach (string dir in DirList)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            Assert.True(di.Exists);
        }

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        Assert.NotNull(CSSPScrambleService);

        CSSPDesktopInstallPostBuildService = Provider.GetService<ICSSPDesktopInstallPostBuildService>();
        Assert.NotNull(CSSPDesktopInstallPostBuildService);

        return await Task.FromResult(true);
    }
}

