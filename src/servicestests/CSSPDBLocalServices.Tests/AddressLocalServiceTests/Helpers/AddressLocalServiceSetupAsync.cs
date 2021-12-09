namespace CSSPDBLocalServices.Tests;

public partial class AddressLocalServiceTest : CSSPDBLocalServiceTest
{
    public AddressLocalServiceTest() : base()
    {

    }

    private async Task<bool> AddressLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "Addresses", "TVItems", "TVItemLanguages" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

