namespace CSSPAAA.Tests;

public partial class CreateAAATests
{
    [Theory]
    [InlineData("en-CA")]
    [InlineData("fr-CA")]
    public async Task CSSPAAA_Good_Test(string culture)
    {
        string cult = culture;
        Assert.True(await Task.FromResult(true));
    }
}

