namespace CSSPScrambleServices.Tests;

[Collection("Sequential")]
public partial class CSSPScrambleServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceCollection Services { get; set; }
    private IServiceProvider Provider { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }

    private async Task<bool> CSSPScrambleServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings_csspscrambleservicestests.json")
            .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();


        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        Assert.NotNull(CSSPScrambleService);

        return await Task.FromResult(true);
    }
}

