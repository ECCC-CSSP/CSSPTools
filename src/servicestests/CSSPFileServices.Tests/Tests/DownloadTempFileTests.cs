namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadTempFile_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\ThisFileShoulBeUnique743Testing.txt");

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

        File.WriteAllText(fi.FullName, "bonjour");

        var actionRes = await CSSPFileService.DownloadTempFileAsync(fi.Name);
        Assert.NotNull(((PhysicalFileResult)actionRes).FileName);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadTempFile_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPTempFilesPath"] }\\ThisFileShoulBeUnique743Testing.txt");

        File.WriteAllText(fi.FullName, "bonjour");

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.DownloadTempFileAsync(fi.Name);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadTempFile_FileDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        string FileName = "doesnotexist.css";

        var actionRes = await CSSPFileService.DownloadTempFileAsync(FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

