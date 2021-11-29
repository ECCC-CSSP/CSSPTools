namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLocalFileInfoList_Good_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;

        var actionRes = await CSSPFileService.GetLocalFileInfoListAsync(ParentTVItemID);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        List<LocalFileInfo> localFileInfoList = ((List<LocalFileInfo>)((OkObjectResult)actionRes.Result).Value);
        Assert.NotNull(localFileInfoList);
        Assert.True(localFileInfoList.Count > 0);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLocalFileInfoList_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 1;

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionRes = await CSSPFileService.GetLocalFileInfoListAsync(ParentTVItemID);
        Assert.Equal(401, ((UnauthorizedObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLocalFileInfoList_ParentTVItemIDDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPFileServiceSetup(culture));

        Assert.Equal(0, (from c in dbManage.CommandLogs select c).Count());

        int ParentTVItemID = 111111111;

        var actionRes = await CSSPFileService.GetLocalFileInfoListAsync(ParentTVItemID);
        Assert.Equal(400, ((BadRequestObjectResult)actionRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionRes.Result).Value;
        Assert.NotEmpty(errRes.ErrList);

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

