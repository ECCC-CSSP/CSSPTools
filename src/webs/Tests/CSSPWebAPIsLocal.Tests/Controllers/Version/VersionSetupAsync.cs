namespace CSSPWebAPIsLocal.VersionController.Tests;

public partial class CSSPWebAPIsLocalVersionControllerTests
{
    private IConfiguration Configuration { get; set; }
    private string LocalUrl { get; set; }

    public CSSPWebAPIsLocalVersionControllerTests()
    {
    }

    private async Task<bool> VersionSetupAsync(string culture)
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

