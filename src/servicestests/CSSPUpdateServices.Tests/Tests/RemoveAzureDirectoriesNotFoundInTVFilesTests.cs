namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RemoveAzureDirectoriesNotFoundInTVFiles_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        string LocalAppDataPath = Configuration["LocalAppDataPath"];
        string FullCSSPFilesPath = Configuration["CSSPFilesPath"];
        string FullAzureFilesPath = Configuration["AzureStoreCSSPFilesPath"];

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> dirNameList = new List<string>() { "test", "test2" };
        string testFileName = "testUnique8273746.txt";
        string testFileNameExist = "";

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), FullAzureFilesPath);

        foreach (string dirName in dirNameList)
        {

            DirectoryInfo di = new DirectoryInfo(FullCSSPFilesPath + dirName + "\\");
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

            di = new DirectoryInfo(FullCSSPFilesPath + dirName + "\\");
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

        var a = (from c in db.TVItems
                 from f in db.TVFiles
                 where c.TVItemID == f.TVFileTVItemID
                 && c.ParentID == 1
                 orderby f.FileSize_kb
                 select new { c, f }).FirstOrDefault();

        Assert.NotNull(a);

        testFileNameExist = a.f.ServerFileName;

        ShareDirectoryClient directory2 = shareClient.GetDirectoryClient("1");

        if (!directory2.Exists())
        {
            try
            {
                directory2.Create();
            }
            catch (Exception ex)
            {
                Assert.True(!false, ex.Message);
            }
        }

        directory2 = shareClient.GetDirectoryClient("1");

        Assert.True(directory2.Exists());

        FileInfo fi2 = new FileInfo(LocalAppDataPath.Replace("_Test", "") + "1\\" + testFileNameExist);
        Assert.True(fi2.Exists);

        ShareFileClient file2 = directory2.GetFileClient(testFileNameExist);
        using (FileStream stream = File.OpenRead(fi2.FullName))
        {
            try
            {
                file2.Create(stream.Length);
                file2.Upload(stream);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        var actionRes = await CSSPUpdateService.RemoveAzureDirectoriesNotFoundInTVFilesAsync();
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);

        foreach (string dirName in dirNameList)
        {
            ShareDirectoryClient directory = shareClient.GetDirectoryClient(dirName);
            Assert.False(directory.Exists());
        }

        directory2 = shareClient.GetDirectoryClient("1");
        Assert.True(directory2.Exists());

        file2 = directory2.GetFileClient(testFileNameExist);
        Assert.True(file2.Exists());

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

