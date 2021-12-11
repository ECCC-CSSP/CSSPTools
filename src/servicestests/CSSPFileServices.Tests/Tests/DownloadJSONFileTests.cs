namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadJSONFile_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        GetJsonGzFileFromAzure(FileName);

        FileInfo fi = new FileInfo($@"{ Configuration["CSSPJSONPath"] }{FileName}");
        Assert.True(fi.Exists);

        var actionRes2 = await CSSPFileService.DownloadJSONFileAsync(FileName);
        Assert.NotNull(((PhysicalFileResult)actionRes2).FileName);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadJSONFile_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.DownloadJSONFileAsync(FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadJSONFile_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CSSPFileService.DownloadJSONFileAsync(FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DownloadJSONFile_FileNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int TVItemID = 0;
        WebTypeEnum webType = WebTypeEnum.WebAllAddresses;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPath"] }{FileName}");
        Assert.False(fi.Exists);

        var actionRes = await CSSPFileService.DownloadJSONFileAsync(FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

