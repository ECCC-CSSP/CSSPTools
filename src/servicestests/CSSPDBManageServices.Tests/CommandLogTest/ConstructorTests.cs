namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Constructor_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));
    }
}

