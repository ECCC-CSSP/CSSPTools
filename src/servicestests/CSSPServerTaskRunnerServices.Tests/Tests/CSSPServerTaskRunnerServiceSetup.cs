namespace CSSPServerTaskRunnerServices.Tests;

[Collection("Sequential")]
public partial class ServerTaskRunnerServiceTest
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
    private IServerTaskRunnerService ServerTaskRunnerService { get; set; }
    private CSSPDBContext dbAzure { get; set; }

    private async Task<bool> CSSPServerTaskRunnerServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspservertaskrunnerservicestests.json")
           .AddUserSecrets("CSSPServerTaskRunnerServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotEmpty(Configuration["CSSPDBAzure"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();
        Services.AddSingleton<IServerTaskRunnerService, ServerTaskRunnerService>();

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

        ServerTaskRunnerService = Provider.GetService<IServerTaskRunnerService>();
        Assert.NotNull(ServerTaskRunnerService);

        dbAzure = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(dbAzure);

        return await Task.FromResult(true);
    }
}

