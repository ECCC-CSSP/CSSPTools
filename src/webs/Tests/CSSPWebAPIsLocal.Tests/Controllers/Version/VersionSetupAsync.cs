namespace CSSPWebAPIsLocal.Tests;

public partial class VersionControllerTests : CSSPWebAPIsLocalTests
{
    public VersionControllerTests()
    {
    }

    private async Task<bool> VersionControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

