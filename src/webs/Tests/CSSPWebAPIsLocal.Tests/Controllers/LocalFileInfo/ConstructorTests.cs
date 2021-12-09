namespace CSSPWebAPIsLocal.Tests;

public partial class LocalFileInfoControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await LocalFileInfoControllerSetupAsync(culture));
    }
}

