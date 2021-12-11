namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadFile_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        GetFileFromAzure(ParentTVItemID, FileName);

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\{FileName}");
        Assert.True(fi.Exists);

        var actionRes2 = await CSSPFileService.DownloadFileAsync(ParentTVItemID, FileName);
        Assert.NotNull(((PhysicalFileResult)actionRes2).FileName);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadFile_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.DownloadFileAsync(ParentTVItemID, FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadFile_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CSSPFileService.DownloadFileAsync(ParentTVItemID, FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadFile_FileNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        CSSPLogService.CSSPAppName = "FileServiceTests";
        CSSPLogService.CSSPCommandName = "Testing_DownloadFileTests_FileNotExist";

        int ParentTVItemID = 1;
        string FileName = "NotExist.png";

        FileInfo fi = new FileInfo($"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\{FileName}");
        Assert.False(fi.Exists);

        var actionRes = await CSSPFileService.DownloadFileAsync(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

