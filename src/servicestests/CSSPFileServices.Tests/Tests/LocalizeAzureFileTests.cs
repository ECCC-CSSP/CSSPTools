namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFile_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        var actionRes = await CSSPFileService.LocalizeAzureFile(ParentTVItemID, FileName);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFile_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.LocalizeAzureFile(ParentTVItemID, FileName);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory(Skip = "Will need to rewrite this one")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFile_AzureStore_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        //config.AzureStore = "notexist" + config.AzureStore;

        var actionRes = await CSSPFileService.LocalizeAzureFile(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory(Skip = "Will need to rewrite this one")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFile_AzureStoreCSSPFilesPath_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        //config.AzureStoreCSSPFilesPath = "notexist" + config.AzureStoreCSSPFilesPath;

        var actionRes = await CSSPFileService.LocalizeAzureFile(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFile_ParentTVItemIDDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 111111111;
        string FileName = "BarTopBottom.png";

        var actionRes = await CSSPFileService.LocalizeAzureFile(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFile_FileNameDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;
        string FileName = "NotExist.png";

        var actionRes = await CSSPFileService.LocalizeAzureFile(ParentTVItemID, FileName);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

