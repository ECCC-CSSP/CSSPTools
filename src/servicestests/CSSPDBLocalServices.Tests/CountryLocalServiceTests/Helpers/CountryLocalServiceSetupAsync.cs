namespace CSSPDBLocalServices.Tests;

public partial class CountryLocalServiceTest : CSSPDBLocalServiceTest
{
    public CountryLocalServiceTest() : base()
    {

    }

    private async Task<bool> CountryLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

