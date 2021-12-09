namespace CSSPDBLocalServices.Tests;

public partial class ProvinceLocalServiceTest : CSSPDBLocalServiceTest
{
    public ProvinceLocalServiceTest() : base()
    {

    }

    private async Task<bool> ProvinceLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

