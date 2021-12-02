namespace CSSPAzureAppTaskServices.Tests;

public partial class CSSPAzureAppTaskServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAzureAppTask_Good_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        List<AppTaskLocalModel> appTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(appTaskModelListRet);

        // ----------- 
        // TestAddOrModify
        AppTaskLocalModel appTaskLocalModelRet = await TestAddAsync(appTaskModel);
        Assert.NotNull(appTaskLocalModelRet);
        Assert.NotNull(appTaskLocalModelRet.AppTask);
        Assert.NotEmpty(appTaskLocalModelRet.AppTaskLanguageList);


        appTaskModelListRet = await TestGetAllAsync();
        Assert.NotEmpty(appTaskModelListRet);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAzureAppTask_Unauthorized_LoggedInContactInfo_null_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo = null;

        await TestGetAllUnauthorizedAsync(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAzureAppTask_Unauthorized_LoggedInContact_null_Error_Test(string culture)
    {
        Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

        AppTaskLocalModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestGetAllUnauthorizedAsync(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
}

