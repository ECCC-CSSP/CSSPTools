namespace CSSPWebAPIsLocal.Tests;

public partial class DownloadOtherControllerTests : CSSPWebAPIsLocalTests
{
    public DownloadOtherControllerTests()
    {
    }

    private async Task<bool> DownloadOtherControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

