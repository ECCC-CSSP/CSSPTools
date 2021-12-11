namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    private void SendFileToAzure(int ParentTVItemID, string FileName)
    {
        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetDirectoryClient($"{ParentTVItemID}");
        Assert.NotNull(directory);

        if (!directory.Exists())
        {
            try
            {
                directory.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        FileInfo fiToUpload = new FileInfo($"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\{FileName}");
        Assert.True(fiToUpload.Exists);

        ShareFileClient file = directory.GetFileClient($"{FileName}");

        using (FileStream stream = fiToUpload.OpenRead())
        {
            if (fiToUpload.Length != 0)
            {
                try
                {
                    file.Create(stream.Length);
                    file.Upload(stream);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);                }
            }
        }
    }
}

