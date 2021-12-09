namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadTempControllerTests : CSSPWebAPIsLocalTests
{
    public DownloadTempControllerTests()
    {

    }
    private async Task<bool> DownloadTempControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

