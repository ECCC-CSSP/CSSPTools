namespace CSSPDBLocalServices.Tests;

[Collection("Sequential")]
public partial class RootLocalServiceTest : CSSPDBLocalServiceTest
{
    public RootLocalServiceTest() : base()
    {


    }

    private async Task<bool> RootLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

