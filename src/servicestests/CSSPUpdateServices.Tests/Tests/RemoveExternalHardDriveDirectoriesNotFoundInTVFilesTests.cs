namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RemoveExternalHardDriveDirectoriesNotFoundInTVFiles_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        string FullAppDataPath = Configuration["ExternalHardDriveBackkupAppDataPath"];
        List<string> dirNameList = new List<string>() { "test", "test2" };
        string testFileName = "testUnique287436.txt";
        string testFileNameExist = "";

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";
 
        DirectoryInfo diExistTest = new DirectoryInfo(Configuration["ExternalHardDriveBackkupAppDataPath"].Replace("_Test", ""));
        if (diExistTest.Exists)
        {
            foreach (string dirName in dirNameList)
            {
                DirectoryInfo di = new DirectoryInfo(FullAppDataPath + dirName + "\\");
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

                di = new DirectoryInfo(FullAppDataPath + dirName + "\\");
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
            }

            var a = (from c in db.TVItems
                     from f in db.TVFiles
                     where c.TVItemID == f.TVFileTVItemID
                     && c.ParentID == 1
                     orderby f.FileSize_kb
                     select new { c, f }).FirstOrDefault();

            Assert.NotNull(a);

            testFileNameExist = a.f.ServerFileName;

            DirectoryInfo di2 = new DirectoryInfo(FullAppDataPath + "1\\");

            if (!di2.Exists)
            {
                try
                {
                    di2.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(!false, ex.Message);
                }
            }

            di2 = new DirectoryInfo(FullAppDataPath + "1\\");
            Assert.True(di2.Exists);

            FileInfo fiDest = new FileInfo(FullAppDataPath + "1\\" + testFileNameExist);

            FileInfo fiOrigin = new FileInfo(FullAppDataPath.Replace("_Test", "") + "1\\" + testFileNameExist);
            Assert.True(fiOrigin.Exists);

            try
            {
                File.Copy(fiOrigin.FullName, fiDest.FullName, true);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            var actionRes = await CSSPUpdateService.RemoveExternalHardDriveDirectoriesNotFoundInTVFilesAsync();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);

            foreach (string dirName in dirNameList)
            {
                DirectoryInfo di = new DirectoryInfo(FullAppDataPath + dirName + "\\");
                Assert.False(di.Exists);
            }

            DirectoryInfo diDest = new DirectoryInfo(FullAppDataPath + "1\\");
            Assert.True(diDest.Exists);

            FileInfo fiDest2 = new FileInfo(FullAppDataPath + "1\\" + testFileNameExist);
            Assert.True(fiDest2.Exists);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}

