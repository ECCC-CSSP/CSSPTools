namespace CSSPDBLocalServices.Tests;

[Collection("Sequential")]
public partial class AddressLocalServiceTest : CSSPDBLocalServiceTest
{
    public AddressLocalServiceTest() : base()
    {

    }

    private async Task<bool> AddressLocalServiceSetup(string culture)
    {
        List<string> TableList = new List<string>() { "Addresses", "TVItems", "TVItemLanguages" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

        return await Task.FromResult(true);
    }
}

