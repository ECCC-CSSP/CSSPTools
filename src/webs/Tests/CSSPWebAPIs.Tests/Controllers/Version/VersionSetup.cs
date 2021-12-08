namespace CSSPWebAPIs.Tests;

public partial class VersionControllerTests : BaseControllerTests
{
    private async Task<bool> VersionControllerSetup(string culture)
    {
        await BaseControllerSetup(culture);

        return await Task.FromResult(true);
    }
}

