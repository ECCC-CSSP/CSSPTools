namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    protected void SendJsonGzFileToAzure(string FileName)
    {
        Assert.Contains("test", Configuration["AzureStoreCSSPJSONPath"]);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        FileInfo fiToUpload = new FileInfo($"{ Configuration["CSSPJSONPath"] }\\{FileName}");
        Assert.True(fiToUpload.Exists); 


        ShareFileClient file = directory.GetFileClient(fiToUpload.Name);

        using (FileStream stream = fiToUpload.OpenRead())
        {
            if (fiToUpload.Length != 0)
            {
                file.Create(stream.Length);
                file.Upload(stream);
            }
        }
    }
}

