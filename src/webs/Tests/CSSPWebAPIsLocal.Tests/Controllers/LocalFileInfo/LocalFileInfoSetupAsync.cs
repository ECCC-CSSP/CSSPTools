namespace CSSPWebAPIsLocal.Tests;

public partial class LocalFileInfoControllerTests : CSSPWebAPIsLocalTests
{
    public LocalFileInfoControllerTests()
    {
    }

    private async Task<bool> LocalFileInfoControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

