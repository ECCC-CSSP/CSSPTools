namespace CSSPSyncDBsServices.Tests;

[Collection("Sequential")]
public partial class SyncDBsServiceTest
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private ICSSPSyncDBsService CSSPSyncDBsService { get; set; }
    private CSSPDBLocalContext dbLocal { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> CSSPSyncDBsServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspsyncdbsservicestests.json")
           .AddUserSecrets("CSSPSyncDBsServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotEmpty(Configuration["CSSPDBLocal"]);
        Assert.NotEmpty(Configuration["CSSPDBManage"]);
        Assert.NotEmpty(Configuration["CSSPAzureUrl"]);
        Assert.NotEmpty(Configuration["LoginEmail"]);
        Assert.NotEmpty(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();
        Services.AddSingleton<ICSSPSyncDBsService, CSSPSyncDBsService>();

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDBAzure"]);
        });

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

