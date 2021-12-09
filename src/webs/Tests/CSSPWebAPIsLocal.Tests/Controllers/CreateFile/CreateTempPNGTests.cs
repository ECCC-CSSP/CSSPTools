namespace CSSPWebAPIsLocal.Tests;

public partial class CreateFileControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateTempPNG_Good_Test(string culture)
    {
        Assert.True(await CreateFileControllerSetupAsync(culture));

        Assert.True(true);
    }
}

