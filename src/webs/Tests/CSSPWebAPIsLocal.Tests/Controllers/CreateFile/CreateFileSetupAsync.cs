namespace CSSPWebAPIsLocal.Tests;

public partial class CreateFileControllerTests : CSSPWebAPIsLocalTests
{
    public CreateFileControllerTests() : base()
    {
    }

    private async Task<bool> CreateFileControllerSetupAsync(string culture)
    {
        //List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPWebAPIsLocalSetupAsync(culture));
        //Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

