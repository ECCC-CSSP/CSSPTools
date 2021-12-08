namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private async Task<AppTaskModel> TestModifyAsync(AppTaskModel appTaskModel)
    {
        var actionPostTVItemModelRes = await AppTaskAzureService.ModifyAppTaskAzureAsync(appTaskModel);
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        AppTaskModel appTaskModelRet = (AppTaskModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskModelRet);

        return await Task.FromResult(appTaskModelRet);
    }
}

