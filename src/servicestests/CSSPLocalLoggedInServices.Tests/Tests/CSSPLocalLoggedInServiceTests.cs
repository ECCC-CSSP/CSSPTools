namespace CSSPLocalLoggedInServices.Tests;

[Collection("Sequential")]
public partial class CSSPLocalLoggedInServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LoggedInService_Constructor_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalLoggedInServiceSetup(culture));

        Assert.NotNull(CSSPCultureService);
        Assert.NotNull(CSSPLocalLoggedInService);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LoggedInService_SetLoggedInLocalContactInf_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalLoggedInServiceSetup(culture));

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0);
        Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0);
    }
}

