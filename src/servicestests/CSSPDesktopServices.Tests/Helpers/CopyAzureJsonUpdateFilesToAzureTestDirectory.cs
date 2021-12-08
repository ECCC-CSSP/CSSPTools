namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private async Task CopyAzureJsonUpdateFilesToAzureTestDirectory()
    {
        foreach (string jsonFileName in await CSSPDesktopService.GetJsonFileNameListAsync())
        {
            bool fileExistInTestDirectory = false;
            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPath"]}{jsonFileName}");

            ShareClient shareClientTest = new ShareClient(CSSPScrambleService.Descramble(CSSPDesktopService.contact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
            ShareDirectoryClient directoryTest = shareClientTest.GetRootDirectoryClient();
            ShareFileClient shareFileClientTest = directoryTest.GetFileClient(jsonFileName);
            ShareFileProperties shareFilePropertiesTest = null;

            try
            {
                shareFilePropertiesTest = shareFileClientTest.GetProperties();
                fileExistInTestDirectory = true;
            }
            catch (Exception)
            {
                //nothing fileExistInTestDirectory stays false
            }

            if (!fileExistInTestDirectory)
            {
                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPDesktopService.contact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"].Replace("test", ""));
                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
                ShareFileClient shareFileClient = directory.GetFileClient(fi.Name);
                ShareFileProperties shareFileProperties = null;

                try
                {
                    shareFileProperties = shareFileClient.GetProperties();
                }
                catch (RequestFailedException ex)
                {
                    Assert.True(false, ex.Message);
                }

                try
                {
                    ShareFileDownloadInfo download = shareFileClient.Download();
                    using (FileStream stream = File.OpenWrite(fi.FullName))
                    {
                        download.Content.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }

                try
                {
                    fi = new FileInfo(fi.FullName);

                    using (FileStream stream = File.OpenRead(fi.FullName))
                    {
                        if (fi.Length != 0)
                        {
                            await shareFileClientTest.CreateAsync(stream.Length);
                            await shareFileClientTest.UploadAsync(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
        }
    }
}

