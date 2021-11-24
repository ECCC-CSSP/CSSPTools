namespace CSSPCultureServices.Tests;

public partial class CultureServicesTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }


    private async Task<bool> CSSPCultureServiceSetup(string culture)
    {
        ServiceCollection Services = new ServiceCollection();

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();

        IServiceProvider Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        return await Task.FromResult(true);
    }
}

