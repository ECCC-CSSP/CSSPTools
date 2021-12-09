namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    public ReadControllerTests()
    {
    }

    private async Task<bool> ReadControllerSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}
