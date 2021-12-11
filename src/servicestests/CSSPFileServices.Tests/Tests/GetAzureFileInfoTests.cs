namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        GetFileFromAzure(ParentTVItemID, FileName);

        SendFileToAzure(ParentTVItemID, FileName);

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        LocalFileInfo localFileInfoRet = ((LocalFileInfo)((OkObjectResult)actionRes.Result).Value);
        Assert.NotNull(localFileInfoRet);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_ParentTVItemIDNotFound_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 111111111;
        string FileName = "BarTopBottom.png";

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_FileDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "NotExist.png";

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory(Skip = "Will need to rewrite this one")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_AzureStore_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        //config.AzureStore = "notgood" + config.AzureStore;

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
    [Theory(Skip = "Will need to rewrite this one")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetAzureFileInfo_AzureStoreCSSPFilesPath_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        //config.AzureStoreCSSPFilesPath = "notgood" + config.AzureStoreCSSPFilesPath;

        var actionRes = await CSSPFileService.GetAzureFileInfoAsync(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);
    }
}

