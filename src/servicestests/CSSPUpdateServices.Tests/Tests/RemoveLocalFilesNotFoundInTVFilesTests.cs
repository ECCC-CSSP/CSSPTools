namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RemoveLocalFilesNotFoundInTVFiles_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> dirNameList = new List<string>() { "1", "2" };
        string testFileName = "testUnique29347.txt";

        foreach (string dirName in dirNameList)
        {
            DirectoryInfo di = new DirectoryInfo(Configuration["LocalAppDataPath"] + dirName + "\\");
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

            di = new DirectoryInfo(Configuration["LocalAppDataPath"] + dirName + "\\");
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

        var actionRes = await CSSPUpdateService.RemoveLocalFilesNotFoundInTVFilesAsync();
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);

        foreach (string dirName in dirNameList)
        {
            DirectoryInfo di = new DirectoryInfo(Configuration["LocalAppDataPath"] + dirName + "\\");
            FileInfo fi = new FileInfo(di + testFileName);
            Assert.False(fi.Exists);
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

