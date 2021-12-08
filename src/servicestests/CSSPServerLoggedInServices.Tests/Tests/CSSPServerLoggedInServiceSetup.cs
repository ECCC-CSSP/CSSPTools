namespace CSSPServerLoggedInServices.Tests;

[Collection("Sequential")]
public partial class CSSPServerLoggedInServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceCollection Services { get; set; }
    private IServiceProvider Provider { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
    private CSSPDBContext dbAzure { get; set; }

    public CSSPServerLoggedInServicesTests()
    {
    }

    private async Task<bool> CSSPServerLoggedInServiceSetup(string culture, int ErrNumber = 0)
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings_csspserverloggedinservicestests.json")
            .AddUserSecrets("CSSPServerLoggedInServices_Tests")
            .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotEmpty(Configuration["CSSPDBAzure"]);
        Assert.NotEmpty(Configuration["LoginEmail"]);
        Assert.NotEmpty(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();

        CheckRequiredDirectories();

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDBAzure"]);
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPServerLoggedInService = Provider.GetService<ICSSPServerLoggedInService>();
        Assert.NotNull(CSSPServerLoggedInService);

        dbAzure = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(dbAzure);

        return await Task.FromResult(true);
    }
}

