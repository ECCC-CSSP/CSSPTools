namespace CSSPServerTaskRunnerServices.Tests;

public partial class ServerTaskRunnerServiceTest
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
    private IServerTaskRunnerService ServerTaskRunnerService { get; set; }
    private CSSPDBContext db { get; set; }

    private async Task<bool> CSSPServerTaskRunnerServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspservertaskrunnerservicestests.json")
           .AddUserSecrets("CSSPServerTaskRunnerServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------
         */
        string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
        Assert.NotNull(CSSPDBManage);

        FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
        });

        /* ---------------------------------------------------------------------------------
         * using AzureCSSPDB
         * ---------------------------------------------------------------------------------      
         */
        string AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
        Assert.NotNull(AzureCSSPDB);

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(AzureCSSPDB);
        });

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<IServerTaskRunnerService, ServerTaskRunnerService>();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPServerLoggedInService = Provider.GetService<ICSSPServerLoggedInService>();
        Assert.NotNull(CSSPServerLoggedInService);

        string LoginEmail = Configuration.GetValue<string>("LoginEmail");
        Assert.True(await CSSPServerLoggedInService.SetLoggedInContactInfo(LoginEmail));

        db = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(db);

        ServerTaskRunnerService = Provider.GetService<IServerTaskRunnerService>();
        Assert.NotNull(ServerTaskRunnerService);

        return await Task.FromResult(true);
    }
}

