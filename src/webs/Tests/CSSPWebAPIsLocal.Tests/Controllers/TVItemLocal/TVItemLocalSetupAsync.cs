namespace CSSPWebAPIsLocal.Tests;

public partial class TVItemLocalControllerTests : CSSPWebAPIsLocalTests
{
    public TVItemLocalControllerTests() : base()
    {
    }

    private async Task<bool> TVItemLocalControllerSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

