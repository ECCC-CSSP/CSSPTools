namespace CSSPWebAPIsLocal.Tests;

public partial class CSSPWebAPIsLocalDownloadTempControllerTests
{
    private IConfiguration Configuration { get; set; }

    private string LocalUrl { get; set; }
    private string CSSPTempFilesPath { get; set; }

    public CSSPWebAPIsLocalDownloadTempControllerTests()
    {
    }
    private async Task<bool> DownloadTempSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapislocaltests.json")
           .AddUserSecrets("CSSPWebAPIsLocal_Tests")
           .Build();

        LocalUrl = Configuration.GetValue<string>("LocalUrl");
        Assert.NotNull(LocalUrl);

        CSSPTempFilesPath = Configuration.GetValue<string>("CSSPTempFilesPath");
        Assert.NotNull(CSSPTempFilesPath);

        return await Task.FromResult(true);
    }
}

