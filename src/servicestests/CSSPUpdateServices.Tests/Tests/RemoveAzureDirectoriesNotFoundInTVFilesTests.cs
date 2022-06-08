namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RemoveAzureDirectoriesNotFoundInTVFiles_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> dirNameList = new List<string>() { "test", "test2" };
        string testFileName = "testUnique8273746.txt";

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);

        foreach (string dirName in dirNameList)
        {

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPFilesPath"] + dirName + "\\");
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

            di = new DirectoryInfo(Configuration["CSSPFilesPath"] + dirName + "\\");
            Assert.True(di.Exists);

            FileInfo fi = new FileInfo(di + testFileName);

            if (!fi.Exists)
            {
                StreamWriter sw = fi.CreateText();
                sw.WriteLine("This is the test line");
                sw.Close();
            }

            fi = new FileInfo(di + testFileName);
            Assert.True(fi.Exists);

            ShareDirectoryClient directory = shareClient.GetDirectoryClient(dirName);

            if (!directory.Exists())
            {
                try
                {
                    directory.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(!false, ex.Message);
                }
            }

            directory = shareClient.GetDirectoryClient(dirName);

            Assert.True(directory.Exists());

            ShareFileClient file = directory.GetFileClient(fi.Name);
            using (FileStream stream = File.OpenRead(fi.FullName))
            {
                try
                {
                    file.Create(stream.Length);
                    file.Upload(stream);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
        }

        var actionRes = await CSSPUpdateService.RemoveAzureDirectoriesNotFoundInTVFilesAsync();
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);

        foreach (string dirName in dirNameList)
        {

            ShareDirectoryClient directory = shareClient.GetDirectoryClient(dirName);

            directory = shareClient.GetDirectoryClient(dirName);

            Assert.True(!directory.Exists());
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

