namespace CSSPWebAPIsLocal.DownloadOtherController.Tests;

public partial class CSSPWebAPIsLocalDownloadOtherControllerTests
{
    private IConfiguration Configuration { get; set; }

    private string LocalUrl { get; set; }

    public CSSPWebAPIsLocalDownloadOtherControllerTests()
    {
    }

    private async Task<bool> DownloadOtherSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapislocaltests.json")
           .AddUserSecrets("CSSPWebAPIsLocal_Tests")
           .Build();

        LocalUrl = Configuration.GetValue<string>("LocalUrl");
        Assert.NotNull(LocalUrl);

        return await Task.FromResult(true);
    }
}

