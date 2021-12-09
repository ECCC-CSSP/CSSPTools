namespace CSSPDBLocalServices.Tests;

[Collection("Sequential")]
public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    protected List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };
    public MapInfoLocalServiceTest() : base()
    {

    }

    private async Task<bool> MapInfoLocalServiceSetupAsync(string culture)
    {
        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

