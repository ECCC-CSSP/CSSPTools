namespace CSSPDBAzureServices.Tests;

[Collection("Sequential")]
public partial class TVItemAzureServiceTest : CSSPDBAzureBaseServiceTest
{
    public TVItemAzureServiceTest() : base()
    {

    }

    private async Task<bool> TVItemAzureServiceSetup(string culture)
    {
        await CSSPDBAzureBaseServiceSetup(culture);

        return await Task.FromResult(true);
    }
}

