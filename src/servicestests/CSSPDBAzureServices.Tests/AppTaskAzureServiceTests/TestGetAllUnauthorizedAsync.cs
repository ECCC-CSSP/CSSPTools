namespace CSSPDBAzureServices.Tests;

public partial class AppTaskAzureServiceTest
{
    private async Task TestGetAllUnauthorizedAsync(string errorMessage)
    {
        var actionPostTVItemModelRes = await AppTaskAzureService.GetAllAppTaskAzureAsync();
        Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
        Assert.True(errRes.ErrList.Where(c => c.Contains(errorMessage)).Any());
    }
}

