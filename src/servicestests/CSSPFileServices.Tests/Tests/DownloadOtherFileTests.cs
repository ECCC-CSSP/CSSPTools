namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadOtherFile_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        FileInfo fi = new FileInfo($"{ Configuration["CSSPOtherFilesPath"]}testing.txt");

        StreamWriter sw = fi.CreateText();
        sw.WriteLine("bonjour");
        sw.Close();

        fi = new FileInfo($"{ Configuration["CSSPOtherFilesPath"]}testing.txt");
        Assert.True(fi.Exists);

        var actionRes = await CSSPFileService.DownloadOtherFileAsync("testing.txt");
        Assert.NotNull(((PhysicalFileResult)actionRes).FileName);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadOtherFile_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.DownloadOtherFileAsync("testing.txt");
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadOtherFile_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CSSPFileService.DownloadOtherFileAsync("testing.txt");
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadOtherFile_FileDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        string FileName = "NotExist.css";

        var actionRes = await CSSPFileService.DownloadOtherFileAsync(FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

