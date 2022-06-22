namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestJsonFilesInAzure()
    {
        Assert.True(Configuration["AzureStoreCSSPJSONPath"].Contains("test"), "AzureStoreCSSPJSONPath config parameter must contain 'test");

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        foreach (ShareFileItem shareFileItem in directory.GetFilesAndDirectories())
        {
            ShareFileClient sharedFileClient = directory.GetFileClient(shareFileItem.Name);
            Response<bool> responseFile = sharedFileClient.DeleteIfExists();
            Assert.True(responseFile.Value);
        }

        Assert.Empty(directory.GetFilesAndDirectories());
    }
}

