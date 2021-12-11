namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    protected void GetJsonGzFileFromAzure(string FileName)
    {
        ShareFileClient shareFileClient;
        ShareFileProperties shareFileProperties;

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"].Replace("test", ""));
        Assert.NotNull(shareClient);

        ShareDirectoryClient shareDirectoryClient = shareClient.GetRootDirectoryClient();
        Assert.NotNull(shareDirectoryClient);

        shareFileClient = shareDirectoryClient.GetFileClient(FileName);
        Assert.NotNull(shareFileClient);

        shareFileProperties = shareFileClient.GetProperties();
        Assert.NotNull(shareFileProperties);

        FileInfo fiDownload = new FileInfo($"{ Configuration["CSSPJSONPath"] }\\{FileName}");

        DirectoryInfo di = new DirectoryInfo(fiDownload.DirectoryName); 
        if (!di.Exists)
        {
            try
            {
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        ShareFileDownloadInfo download = shareFileClient.Download();
        using (FileStream stream = File.OpenWrite(fiDownload.FullName))
        {
            download.Content.CopyTo(stream);
        }
    }
}

