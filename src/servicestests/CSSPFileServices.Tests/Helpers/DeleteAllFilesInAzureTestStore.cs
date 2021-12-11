namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    private void DeleteAllFilesInAzureTestStore()
    {
        Assert.Contains("test", Configuration["AzureStoreCSSPFilesPath"]);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        foreach (ShareFileItem shareFileItem in directory.GetFilesAndDirectories())
        {
            if (shareFileItem.IsDirectory)
            {
                ShareDirectoryClient subDirectory = shareClient.GetDirectoryClient($"{ shareFileItem.Name }");
                Assert.NotNull(subDirectory);

                foreach (ShareFileItem shareFileItemSub in subDirectory.GetFilesAndDirectories())
                {
                    ShareFileClient file = subDirectory.GetFileClient(shareFileItemSub.Name);
                    Assert.NotNull(file);

                    Response<bool> responseFile = file.DeleteIfExists();
                    Assert.True(responseFile.Value);
                }

                subDirectory.DeleteIfExists();
            }
        }

        Assert.Empty(directory.GetFilesAndDirectories());
    }
}

