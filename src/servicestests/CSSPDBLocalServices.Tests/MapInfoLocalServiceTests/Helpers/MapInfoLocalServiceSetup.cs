namespace CSSPDBLocalServices.Tests;

[Collection("Sequential")]
public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    public MapInfoLocalServiceTest() : base()
    {


    }

    private async Task<bool> MapInfoLocalServiceSetup(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

