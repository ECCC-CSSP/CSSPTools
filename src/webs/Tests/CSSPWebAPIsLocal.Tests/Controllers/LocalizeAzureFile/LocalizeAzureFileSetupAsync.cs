namespace CSSPWebAPIsLocal.Tests;

public partial class LocalizeAzureFileControllerTests : CSSPWebAPIsLocalTests
{

    public LocalizeAzureFileControllerTests()
    {

    }

    private async Task<bool> LocalizeAzureFileControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

