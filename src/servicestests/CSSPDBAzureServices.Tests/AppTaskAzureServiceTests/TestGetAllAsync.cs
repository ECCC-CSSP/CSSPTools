namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private async Task<List<AppTaskModel>> TestGetAllAsync()
    {
        var actionPostTVItemModelRes = await AppTaskAzureService.GetAllAppTaskAzureAsync();
        Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        List<AppTaskModel> appTaskModelListRet = (List<AppTaskModel>)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.NotNull(appTaskModelListRet);

        return await Task.FromResult(appTaskModelListRet);
    }
}

