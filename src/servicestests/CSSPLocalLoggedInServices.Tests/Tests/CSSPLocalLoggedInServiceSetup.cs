namespace CSSPLocalLoggedInServices.Tests;

public partial class CSSPLocalLoggedInServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceCollection Services { get; set; }
    private IServiceProvider Provider { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }

    private async Task<bool> CSSPLocalLoggedInServiceSetup(string culture, int ErrNumber = 0)
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings_cssplocalloggedinservicestests.json")
            .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);
        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();

        Assert.NotNull(Configuration["CSSPDBManage"]);

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */

        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        Assert.True(fiCSSPDBManage.Exists);

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);

        return await Task.FromResult(true);
    }
}

