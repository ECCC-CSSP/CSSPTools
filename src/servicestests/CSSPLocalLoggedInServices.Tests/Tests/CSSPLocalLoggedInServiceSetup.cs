namespace CSSPLocalLoggedInServices.Tests;

[Collection("Sequential")]
public partial class CSSPLocalLoggedInServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceCollection Services { get; set; }
    private IServiceProvider Provider { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> CSSPLocalLoggedInServiceSetup(string culture, int ErrNumber = 0)
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings_cssplocalloggedinservicestests.json")
            .AddUserSecrets("CSSPLocalLoggedInServices_Tests")
            .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

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

        return await Task.FromResult(true);
    }
}

