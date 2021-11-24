namespace ManageServices.Tests;

[Collection("Sequential")]
public partial class ManageFileServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceCollection Services { get; set; }
    private IServiceProvider Provider { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private IManageFileService ManageFileService { get; set; }
    private CSSPDBLocalContext dbLocal { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    public ManageFileServicesTests()
    {
    }

    private async Task<bool> ManageFileServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings_csspdbmanageservicestests.json")
            .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IManageFileService, ManageFileService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

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

        await GetProviderServices(culture);

        ClearCommandLogs();
        ClearManageFiles();

        return await Task.FromResult(true);
    }
}

