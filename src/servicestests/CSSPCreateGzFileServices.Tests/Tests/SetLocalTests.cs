namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task SetLocal_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);
        Assert.Empty(di.GetFiles());

        var actionRes = await CSSPCreateGzFileService.SetLocal(true);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllAddresses, 0);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);
        Assert.NotEmpty(di.GetFiles());

        actionRes = await CSSPCreateGzFileService.SetLocal(false);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);
        Assert.Empty(directory.GetFilesAndDirectories());

        actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllAddresses, 0);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);
        Assert.NotEmpty(directory.GetFilesAndDirectories());

        foreach (ShareFileItem shareFileItem in directory.GetFilesAndDirectories())
        {
            ShareFileClient file = directory.GetFileClient(shareFileItem.Name);
            Assert.NotNull(file);
        }
    }
}

