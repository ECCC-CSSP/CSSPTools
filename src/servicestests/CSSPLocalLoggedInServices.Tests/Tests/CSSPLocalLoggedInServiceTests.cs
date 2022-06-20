namespace CSSPLocalLoggedInServices.Tests;

public partial class CSSPLocalLoggedInServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task SetLoggedInLocalContactInf_Good_Test(string culture)
    {
        Assert.True(await CSSPLocalLoggedInServiceSetup(culture));

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.True(CSSPLocalLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count > 0);
        Assert.False(CSSPLocalLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count > 0);
    }
}

