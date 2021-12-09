namespace CSSPWebAPIsLocal.Tests;

public partial class LoggedInContactControllerTests : CSSPWebAPIsLocalTests
{
    public LoggedInContactControllerTests()
    {
    }

    private async Task<bool> LoggedInContactControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

