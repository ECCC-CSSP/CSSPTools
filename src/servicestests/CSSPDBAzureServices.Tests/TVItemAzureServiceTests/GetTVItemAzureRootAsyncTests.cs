namespace CSSPDBAzureServices.Tests;

public partial class TVItemAzureServiceTest
{
    [Theory(Skip = "Skipping this test for now")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemAzureRootAsyncTests_Good_Test(string culture)
    {
        Assert.True(await TVItemAzureServiceSetup(culture));

        var actionRes = await TVItemAzureService.GetTVItemAzureRootAsync();
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        TVItem tvItem = (TVItem)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItem);
    }
}

