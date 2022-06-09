namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestFilesInAzure()
    {
        Assert.True(Configuration["AzureStoreCSSPFilesPath"].Contains("test"), "AzureStoreCSSPFilesPath config parameter must contain 'test");

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        foreach (ShareFileItem shareFileItem in directory.GetFilesAndDirectories())
        {
            ShareDirectoryClient directorySub = shareClient.GetDirectoryClient(shareFileItem.Name);

            if (directorySub.Exists())
            {
                foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                {
                    ShareFileClient file = directorySub.GetFileClient(shareFileItemSub.Name);

                    Response<bool> responseFile = file.DeleteIfExists();

                    Assert.True(responseFile.Value);
                }
            }

            Response<bool> responseDir = directorySub.DeleteIfExists();
        }

        Assert.Empty(directory.GetFilesAndDirectories());
    }
}

