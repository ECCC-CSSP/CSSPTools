namespace CSSPWebAPIsLocal.DownloadController.Tests;

public partial class CSSPWebAPIsLocalDownloadControllerTests
{
    private IConfiguration Configuration { get; set; }

    private string LocalUrl { get; set; }

    public CSSPWebAPIsLocalDownloadControllerTests()
    {
    }

    private async Task<bool> DownloadSetupAsync(string culture)
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

