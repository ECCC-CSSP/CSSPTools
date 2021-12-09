namespace CSSPDBLocalServices.Tests;

public partial class ClassificationLocalServiceTest : CSSPDBLocalServiceTest
{
    public ClassificationLocalServiceTest() : base()
    {

    }

    private async Task<bool> ClassificationLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "Classifications", "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

