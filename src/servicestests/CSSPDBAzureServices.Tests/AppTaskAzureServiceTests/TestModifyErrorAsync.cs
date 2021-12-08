namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private async Task TestModifyErrorAsync(AppTaskModel appTaskModel, string errorMessage)
    {
        var actionPostTVItemModelRes = await AppTaskAzureService.ModifyAppTaskAzureAsync(appTaskModel);
        Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
}

