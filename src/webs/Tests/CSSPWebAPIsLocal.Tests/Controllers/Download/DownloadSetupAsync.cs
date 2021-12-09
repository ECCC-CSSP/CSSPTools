namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadControllerTests : CSSPWebAPIsLocalTests
{
    public DownloadControllerTests()
    {
    }

    private async Task<bool> DownloadControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

