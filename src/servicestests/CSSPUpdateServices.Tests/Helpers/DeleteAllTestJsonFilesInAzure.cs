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

