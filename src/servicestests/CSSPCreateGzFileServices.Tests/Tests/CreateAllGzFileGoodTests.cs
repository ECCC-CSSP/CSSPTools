namespace CSSPCreateGzFileServices.Tests;

public partial class CSSPCreateGzFileServiceTests
{
    [Theory(Skip = "Skip as it takes a long time. Still wants a marker however")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateAllGzFile_Good_Test(string culture)
    {
        Assert.True(await CSSPCreateGzFileServiceSetup(culture));

        // the next command takes a long long time
        //var actionRes = await CreateGzFileService.CreateAllGzFilesAsync();
        //Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //Assert.True((bool)((OkObjectResult)actionRes.Result).Value);
        //Assert.Empty(CSSPLogService.ErrRes.ErrList);
    }
}

