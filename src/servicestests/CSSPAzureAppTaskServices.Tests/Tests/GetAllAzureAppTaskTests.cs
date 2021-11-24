namespace CSSPAzureAppTaskServices.Tests;

public partial class CSSPAzureAppTaskServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAzureAppTask_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestGetAllUnauthorizedAsync(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
    }
}

