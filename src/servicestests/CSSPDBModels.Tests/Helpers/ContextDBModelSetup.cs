namespace CSSPDBModels.Tests;

[Collection("Sequential")]
public partial class ContextTest
{
    private DateTime LastTime = DateTime.Now;
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private IEnums enums { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> ContextDBModelSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
         .AddJsonFile("appsettings_csspdbmodelstests.json")
         .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDB"]);
        Assert.Contains("Server=.", Configuration["CSSPDB"]);
        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.Contains("Test", Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.Contains("Test", Configuration["CSSPDBManage"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

        CheckRequiredDirectories();

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDB"]);
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

