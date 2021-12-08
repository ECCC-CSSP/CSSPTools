namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Good_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        List<AppTaskModel> appTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(appTaskModelListRet);

        AppTaskModel appTaskLocalModelRet = await TestAddAsync(appTaskModel);
        Assert.NotNull(appTaskLocalModelRet);
        Assert.NotNull(appTaskLocalModelRet.AppTask);
        Assert.NotEmpty(appTaskLocalModelRet.AppTaskLanguageList);

        appTaskModelListRet = await TestGetAllAsync();
        Assert.NotEmpty(appTaskModelListRet);

        AppTaskModel deleteTaskLocalModelRet = await TestDeleteAsync(appTaskModel.AppTask.AppTaskID);
        Assert.NotNull(deleteTaskLocalModelRet);
        Assert.NotNull(deleteTaskLocalModelRet.AppTask);
        Assert.NotEmpty(deleteTaskLocalModelRet.AppTaskLanguageList);

        List<AppTaskModel> deleteTaskModelListRet = await TestGetAllAsync();
        Assert.Empty(deleteTaskModelListRet);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Unauthorized_LoggedInContactInfo_null_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        CSSPServerLoggedInService.LoggedInContactInfo = null;

        await TestDeleteUnauthorizedAsync(1, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Unauthorized_LoggedInContact_null_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        await TestDeleteUnauthorizedAsync(1, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        int AppTaskID = 0;

        await TestDeleteErrorAsync(AppTaskID, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_AppTask_NotFound_Error_Test(string culture)
    {
        Assert.True(await AppTaskAzureServiceSetup(culture));

        AppTaskModel appTaskModel = FillAppTaskModel();

        AppTaskModel appTaskModelRet = await TestAddAsync(appTaskModel);

        int AppTaskID = -1;

        await TestDeleteErrorAsync(AppTaskID, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));
    }
}

