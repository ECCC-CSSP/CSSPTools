namespace CSSPWebAPIsLocal.LocalFileInfoController.Tests;

public partial class CSSPWebAPIsLocalLocalFileInfoControllerTests
{
    private IConfiguration Configuration { get; set; }
    private string LocalUrl { get; set; }
    private string CSSPFilesPath { get; set; }

    public CSSPWebAPIsLocalLocalFileInfoControllerTests()
    {
    }

    private async Task<bool> LocalFileInfoSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapislocaltests.json")
           .AddUserSecrets("CSSPWebAPIsLocal_Tests")
           .Build();

        LocalUrl = Configuration.GetValue<string>("LocalUrl");
        Assert.NotNull(LocalUrl);

        CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
        Assert.NotNull(CSSPFilesPath);

        return await Task.FromResult(true);
    }
}

