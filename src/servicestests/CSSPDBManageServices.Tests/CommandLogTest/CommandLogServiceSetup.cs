namespace ManageServices.Tests;

[Collection("Sequential")]
public partial class CommandLogServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceCollection Services { get; set; }
    private IServiceProvider Provider { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICommandLogService CommandLogService { get; set; }
    private CSSPDBLocalContext dbLocal { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    public CommandLogServicesTests()
    {
    }

    private async Task<bool> CommandLogServiceSetup(string culture)
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
        Services.AddSingleton<ICommandLogService, CommandLogService>();
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

