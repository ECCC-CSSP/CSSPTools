namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    private void DeleteAllJsonFilesInAzureTestStore()
    {
        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        foreach (ShareFileItem shareFileItem in directory.GetFilesAndDirectories())
        {
            ShareFileClient file = directory.GetFileClient(shareFileItem.Name);
            Assert.NotNull(file);

            Response<bool> responseFile = file.DeleteIfExists();
            Assert.True(responseFile.Value);
        }

        Assert.Empty(directory.GetFilesAndDirectories());
    }
}

