namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private async Task<AppTaskModel> TestDeleteAsync(int appTaskID)
    {
        var actionPostTVItemModelRes = await AppTaskAzureService.DeleteAppTaskAzureAsync(appTaskID);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        AppTaskModel appTaskLocalModel = (AppTaskModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskLocalModel);

        return appTaskLocalModel;
    }
}

