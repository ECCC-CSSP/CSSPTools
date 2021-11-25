namespace CSSPSQLiteServices.Tests;

[Collection("Sequential")]
public partial class CSSPSQLiteServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private CSSPDBLocalContext dbLocal { get; set; }
    private CSSPDBManageContext dbManage { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }

    private async Task<bool> CSSPSQLiteServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspsqliteservicestests.json")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        CheckRequiredDirectories();

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

        CheckCSSPDBLocalContext();

        CheckCSSPDBManageContext();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);
        if (culture == "fr")
        {
            Assert.Equal(1, CSSPCultureService.LangID);
        }
        else
        {
            Assert.Equal(0, CSSPCultureService.LangID);
        }

        CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
        Assert.NotNull(CSSPSQLiteService);

        dbLocal = Provider.GetService<CSSPDBLocalContext>();
        Assert.NotNull(dbLocal);

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        return await Task.FromResult(true);
    }
}

