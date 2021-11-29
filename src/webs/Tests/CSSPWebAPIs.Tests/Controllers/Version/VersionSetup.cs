namespace CSSPWebAPIs.VersionController.Tests;

[Collection("Sequential")]
public partial class CSSPWebAPIsVersionControllerTests
{
    private IConfiguration Configuration { get; set; }

    private async Task<bool> VersionSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapistests.json")
           .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
           .Build();

        Assert.NotNull(Configuration["CSSPAzureUrl"]);

        return await Task.FromResult(true);
    }
}

