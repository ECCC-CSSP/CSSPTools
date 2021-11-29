namespace CSSPWebAPIsLocal.ReadController.Tests;

public partial class CSSPWebAPIsLocalReadControllerTests
{
    private IConfiguration Configuration { get; set; }
    private string LocalUrl { get; set; }

    public CSSPWebAPIsLocalReadControllerTests()
    {
    }

    private async Task<bool> ReadSetupAsync(string culture)
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

