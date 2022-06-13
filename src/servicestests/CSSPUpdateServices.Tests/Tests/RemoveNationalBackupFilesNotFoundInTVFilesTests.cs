namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RemoveNationalBackupFilesNotFoundInTVFiles_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        string FullAppDataPath = Configuration["NationalBackupAppDataPath"];
        List<string> dirNameList = new List<string>() { "1", "2" };
        string testFileName = "testUnique29347.txt";
        string testFileNameExist = "";

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
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

            FileInfo fiDest = new FileInfo(FullAppDataPath + "1\\" + a.f.ServerFileName);

            FileInfo fiOrigin = new FileInfo(FullAppDataPath.Replace("_Test", "") + "1\\" + a.f.ServerFileName);
            Assert.True(fiOrigin.Exists);

            try
            {
                File.Copy(fiOrigin.FullName, fiDest.FullName, true);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            var actionRes = await CSSPUpdateService.RemoveNationalBackupFilesNotFoundInTVFilesAsync();
            Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);


            // one file should be deleted in directory 1
            DirectoryInfo di3 = new DirectoryInfo(FullAppDataPath + "1" + "\\");
            Assert.True(di3.Exists);

            FileInfo fi3 = new FileInfo(di3.FullName + testFileName);
            Assert.False(fi3.Exists);

            fi3 = new FileInfo(di3.FullName + testFileNameExist);
            Assert.True(fi3.Exists);

            // No file should be deleted in directory 2
            DirectoryInfo di4 = new DirectoryInfo(FullAppDataPath + "2" + "\\");
            Assert.True(di4.Exists);

            FileInfo fi4 = new FileInfo(di4.FullName + testFileName);
            Assert.True(fi4.Exists);

            await CSSPLogService.Save();

            Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
        }
    }
}

