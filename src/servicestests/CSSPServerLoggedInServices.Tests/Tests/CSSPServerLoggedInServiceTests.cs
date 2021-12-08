namespace CSSPServerLoggedInServices.Tests;

public partial class CSSPServerLoggedInServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task SetLoggedInContactInfo_Good_Test(string culture)
    {
        Assert.True(await CSSPServerLoggedInServiceSetup(culture));

        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(Configuration["LoginEmail"]);
        Assert.Equal(Configuration["LoginEmail"], CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.LoginEmail);

        Contact contact = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact;
        Assert.NotNull(contact.FirstName);
        Assert.NotNull(contact.Initial);
        Assert.NotNull(contact.LastName);

        List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = CSSPServerLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList;
        Assert.True(TVTypeUserAuthorizationList.Count > 0);

        List<TVItemUserAuthorization> TVItemUserAuthorizationList = CSSPServerLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList;
        Assert.True(TVItemUserAuthorizationList.Count == 0);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task SetLoggedInContactInfo_Error_Test(string culture)
    {
        Assert.True(await CSSPServerLoggedInServiceSetup(culture));

        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync("notGood" + Configuration["LoginEmail"]);
        Assert.Null(CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.True(CSSPServerLoggedInService.LoggedInContactInfo.TVTypeUserAuthorizationList.Count == 0);
        Assert.True(CSSPServerLoggedInService.LoggedInContactInfo.TVItemUserAuthorizationList.Count == 0);
    }
}

