namespace CSSPDesktopInstallPostBuildServices.Tests;

public partial class CSSPDesktopInstallPostBuildServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CSSPOtherFilesCompressAndSendToAzure_Good_Test(string culture)
    {
        Assert.True(await CSSPDesktopInstallPostBuildServiceSetup(culture));

        string fileName = Configuration["CSSPOtherFilesZipFile"];

        FileInfo fi = new FileInfo(fileName);
        if (fi.Exists)
        {
            try
            {
                fi.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        fi = new FileInfo(fileName);
        Assert.False(fi.Exists);

        Contact contact = await CSSPDesktopInstallPostBuildService.LoginAsync();
        Assert.NotNull(contact);

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(contact.AzureStoreHash), Configuration["AzureStoreCSSPWebAPIsLocalPath"]);
        Assert.NotNull(shareClient);

        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
        Assert.NotNull(directory);

        ShareFileClient shareFileClient = directory.GetFileClient(fi.Name);
        Assert.NotNull(shareFileClient);

        if (await shareFileClient.ExistsAsync())
        {
            try
            {
                await shareFileClient.DeleteAsync();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        Assert.False(await shareFileClient.ExistsAsync());

        bool retBool = await CSSPDesktopInstallPostBuildService.CSSPOtherFilesCompressAndSendToAzureAsync();
        Assert.True(retBool);

        Assert.True(await shareFileClient.ExistsAsync());

        fi = new FileInfo(fileName);
        Assert.True(fi.Exists);
    }
}

