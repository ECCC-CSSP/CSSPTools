namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    private async Task DoFullTest(WebTypeEnum webType, int TVItemID)
    {
        WriteTimeSpan(webType);

        DirectoryInfo diBackup = new DirectoryInfo(Configuration["azure_csspjson_backup"]);
        Assert.True(diBackup.Exists);
        Assert.Empty(diBackup.GetDirectories());

        DirectoryInfo diBackupUncompress = new DirectoryInfo(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.True(diBackupUncompress.Exists);
        Assert.Empty(diBackupUncompress.GetDirectories());

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        FileInfo fiBackup = new FileInfo($"{ Configuration["azure_csspjson_backup"] }{ fileName }");
        Assert.True(fiBackup.Exists);

        FileInfo fiBackupUncompress = new FileInfo($"{ Configuration["azure_csspjson_backup_uncompress"] }{ fileName.Replace(".gz", ".json") }");
        Assert.True(fiBackupUncompress.Exists);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        ShareFileClient shareFileClient = directory.GetFileClient(fileName);
        Response<bool> response = await shareFileClient.ExistsAsync();
        Assert.True(response.Value);

        WriteTimeSpan(webType);

        actionRes = await CSSPCreateGzFileService.DeleteGzFileAsync(webType, TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        Assert.Empty(diBackup.GetDirectories());
        Assert.Empty(diBackupUncompress.GetDirectories());

        shareFileClient = directory.GetFileClient(fileName);
        response = await shareFileClient.ExistsAsync();
        Assert.False(response.Value);

        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        fiBackup = new FileInfo($"{ Configuration["azure_csspjson_backup"] }{ fileName }");
        Assert.True(fiBackup.Exists);

        fiBackupUncompress = new FileInfo($"{ Configuration["azure_csspjson_backup_uncompress"] }{ fileName.Replace(".gz", ".json") }");
        Assert.True(fiBackupUncompress.Exists);

        WriteTimeSpan(webType);

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);

        CSSPLogService.ErrRes = new ErrRes();

        actionRes = await CSSPCreateGzFileService.DeleteGzFileAsync(webType, TVItemID);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);

        WriteTimeSpan(webType);
    }
}

