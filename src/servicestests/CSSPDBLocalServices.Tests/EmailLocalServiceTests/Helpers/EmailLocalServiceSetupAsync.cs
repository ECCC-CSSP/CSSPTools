namespace CSSPDBLocalServices.Tests;

public partial class EmailLocalServiceTest : CSSPDBLocalServiceTest
{
    public EmailLocalServiceTest() : base()
    {


    }

    private async Task<bool> EmailLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "Emails", "TVItems", "TVItemLanguages" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

