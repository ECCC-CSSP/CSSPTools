namespace CSSPWebAPIsLocal.Tests;

public partial class CountryLocalControllerTests : CSSPWebAPIsLocalTests
{
    public CountryLocalControllerTests() : base()
    {
    }

    private async Task<bool> CountryLocalSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

