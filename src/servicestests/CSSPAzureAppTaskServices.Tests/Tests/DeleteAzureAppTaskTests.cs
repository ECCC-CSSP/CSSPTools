namespace CSSPAzureAppTaskServices.Tests;

public partial class CSSPAzureAppTaskServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_AppTask_NotFound_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        AppTaskLocalModel appTaskModelRet = await TestAddAsync(appTaskModel);

        int AppTaskID = -1;

        await TestDeleteErrorAsync(AppTaskID, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        int AppTaskID = 0;

        await TestDeleteErrorAsync(AppTaskID, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        int AppTaskID = 1000;

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestDeleteUnauthorizedAsync(AppTaskID, string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
    }
}

