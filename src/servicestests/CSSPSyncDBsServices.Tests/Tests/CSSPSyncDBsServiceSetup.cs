namespace CSSPSyncDBsServices.Tests;

public partial class SyncDBsServiceTest
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPSyncDBsService CSSPSyncDBsService { get; set; }
    private CSSPDBContext db { get; set; }

    private async Task<bool> CSSPSyncDBsServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspsyncdbsservicestests.json")
           .AddUserSecrets("74f56089-4db8-46b3-8b49-6108e031a474")
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
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPSyncDBsService, CSSPSyncDBsService>();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);

        //string LoginEmail = Configuration.GetValue<string>("LoginEmail");
        Assert.True(await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync());

        db = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(db);

        CSSPSyncDBsService = Provider.GetService<ICSSPSyncDBsService>();
        Assert.NotNull(CSSPSyncDBsService);

        return await Task.FromResult(true);
    }
}

