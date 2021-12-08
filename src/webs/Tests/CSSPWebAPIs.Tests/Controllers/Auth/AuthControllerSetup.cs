namespace CSSPWebAPIs.Tests;


public partial class AuthControllerTests : BaseControllerTests
{
    public AuthControllerTests() : base()
    {

    }

    private async Task<bool> AuthControllerSetup(string culture)
    {
        await BaseControllerSetup(culture);

        return await Task.FromResult(true);
    }
}

