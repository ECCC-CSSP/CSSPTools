namespace CSSPWebAPIsLocal.LoggedInContactController.Tests;

public partial class CSSPWebAPIsLocalLoggedInContactControllerTests
{
    private IConfiguration Configuration { get; set; }
    private string LocalUrl { get; set; }

    public CSSPWebAPIsLocalLoggedInContactControllerTests()
    {
    }

    private async Task<bool> LoggedInContactSetupAsync(string culture)
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

