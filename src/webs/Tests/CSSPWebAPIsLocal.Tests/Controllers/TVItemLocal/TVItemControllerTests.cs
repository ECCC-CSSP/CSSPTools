namespace CSSPWebAPIsLocal.Tests;

public partial class TVItemLocalControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Other_Good_Test(string culture)
    {
        Assert.True(await TVItemLocalControllerSetupAsync(culture));

        Assert.True(true);
    }
}

