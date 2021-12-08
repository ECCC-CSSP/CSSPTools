namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAppTaskAzure_Good_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        List<AppTaskModel> appTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(appTaskModelListRet);

        // ----------- 
        // TestAddOrModify
        AppTaskModel appTaskLocalModelRet = await TestAddAsync(appTaskModel);
        Assert.NotNull(appTaskLocalModelRet);
        Assert.NotNull(appTaskLocalModelRet.AppTask);
        Assert.NotEmpty(appTaskLocalModelRet.AppTaskLanguageList);


        appTaskModelListRet = await TestGetAllAsync();
        Assert.NotEmpty(appTaskModelListRet);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAppTaskAzure_Unauthorized_LoggedInContactInfo_null_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo = null;

        await TestGetAllUnauthorizedAsync(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAllAppTaskAzure_Unauthorized_LoggedInContact_null_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestGetAllUnauthorizedAsync(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
}

