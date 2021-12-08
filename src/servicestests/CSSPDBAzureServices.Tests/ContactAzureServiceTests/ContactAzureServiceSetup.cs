namespace CSSPDBAzureServices.Tests;

[Collection("Sequential")]
public partial class ContactAzureServiceTest : CSSPDBAzureBaseServiceTest
{
    public ContactAzureServiceTest() : base()
    {

    }

    private async Task<bool> ContactAzureServiceSetup(string culture)
    {
        await CSSPDBAzureBaseServiceSetup(culture);

        return await Task.FromResult(true);
    }
}

