namespace CSSPAzureLoginServices.Tests;

[Collection("Sequential")]
public partial class CSSPAzureLoginServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> CSSPAzureLoginServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_CSSPAzureLoginServicestests.json")
           .AddUserSecrets("CSSPAzureLoginServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);

        CheckRequiredDirectories();

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

        await GetProviderServices();

        return await Task.FromResult(true);
    }
}

