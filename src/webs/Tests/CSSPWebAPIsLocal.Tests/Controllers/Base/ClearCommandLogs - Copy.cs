namespace CSSPWebAPIsLocal.Tests;

public partial class CSSPWebAPIsLocalTests
{
    protected async Task DoCreateGzFile(WebTypeEnum webType, int TVItemID)
    {
        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        ShareFileClient shareFileClient = directory.GetFileClient(fileName);
        Response<bool> response = await shareFileClient.ExistsAsync();
        Assert.True(response.Value);
    }
}

