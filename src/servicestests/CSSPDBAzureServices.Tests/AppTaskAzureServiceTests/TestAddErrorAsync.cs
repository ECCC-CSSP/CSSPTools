namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private async Task TestAddErrorAsync(AppTaskModel appTaskModel, string errorMessage)
    {
        var actionPostTVItemModelRes = await AppTaskAzureService.AddAppTaskAzureAsync(appTaskModel);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
}

