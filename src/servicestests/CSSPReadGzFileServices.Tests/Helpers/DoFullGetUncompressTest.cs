namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    protected async Task DoFullGetUncompressJSONTest(WebTypeEnum webType, int TVItemID)
    {
        string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        ShareFileClient shareFileClient = directory.GetFileClient(fileName);
        Assert.NotNull(shareFileClient);

        Response<bool> response = await shareFileClient.ExistsAsync();
        Assert.False(response.Value);

        GetJsonGzFileFromAzure(fileName);
        SendJsonGzFileToAzure(fileName);

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

