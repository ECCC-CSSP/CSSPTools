namespace CSSPDBLocalServices.Tests;

public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
{
    public AppTaskLocalServiceTest() : base()
    {


    }

    private async Task<bool> AppTaskLocalServiceSetupAsync(string culture)
    {
        List<string> TableList = new List<string>() { "AppTasks", "AppTaskLanguages" };

        Assert.True(await CSSPDBLocalServiceSetupAsync(culture));
        Assert.True(await ClearSomeTablesOfCSSPDBLocalAsync(TableList));

        return await Task.FromResult(true);
    }
}

