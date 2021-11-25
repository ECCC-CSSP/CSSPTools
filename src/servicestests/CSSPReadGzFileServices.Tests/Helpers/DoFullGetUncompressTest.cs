namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    private async Task DoFullGetUncompressTest(WebTypeEnum webType, int TVItemID)
    {
        WriteTimeSpan(webType);

        DirectoryInfo diBackup = new DirectoryInfo(Configuration["azure_csspjson_backup"]);
        Assert.True(diBackup.Exists);
        Assert.Empty(diBackup.GetDirectories());

        DirectoryInfo diBackupUncompress = new DirectoryInfo(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.True(diBackupUncompress.Exists);
        Assert.Empty(diBackupUncompress.GetDirectories());

        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        ShareFileClient shareFileClient = directory.GetFileClient(fileName);
        Response<bool> response = await shareFileClient.ExistsAsync();
        Assert.False(response.Value);

        var actionRes = await CSSPCreateGzFileService.CreateGzFileAsync(webType, TVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        Assert.Empty(CSSPLogService.ErrRes.ErrList);

        FileInfo fiBackup = new FileInfo($"{ Configuration["azure_csspjson_backup"] }{ fileName }");
        Assert.True(fiBackup.Exists);

        FileInfo fiBackupUncompress = new FileInfo($"{ Configuration["azure_csspjson_backup_uncompress"] }{ fileName.Replace(".gz", ".json") }");
        Assert.True(fiBackupUncompress.Exists);

        shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
        directory = shareClient.GetRootDirectoryClient();
        shareFileClient = directory.GetFileClient(fileName);
        response = await shareFileClient.ExistsAsync();
        Assert.True(response.Value);

        await TestGetUncompressJSON(webType, TVItemID);

        FileInfo fiJSON = new FileInfo($"{ Configuration["CSSPJSONPath"] }{ fileName }");
        Assert.True(fiJSON.Exists);

        ManageFile manageFile = (from c in dbManage.ManageFiles
                                 select c).FirstOrDefault();

        Assert.NotNull(manageFile);
        Assert.Equal(Configuration["AzureStoreCSSPJsonPath"], manageFile.AzureStorage);
        Assert.Equal(fileName, manageFile.AzureFileName);

        // testing ReadJSON when local file already exist
        await TestGetUncompressJSON(webType, TVItemID);

        fiJSON = new FileInfo($"{ Configuration["CSSPJSONPath"] }{ fileName }");
        Assert.True(fiJSON.Exists);

        manageFile = (from c in dbManage.ManageFiles
                      select c).FirstOrDefault();

        Assert.NotNull(manageFile);
        Assert.Equal(Configuration["AzureStoreCSSPJsonPath"], manageFile.AzureStorage);
        Assert.Equal(fileName, manageFile.AzureFileName);

        WriteTimeSpan(webType);
    }
}

