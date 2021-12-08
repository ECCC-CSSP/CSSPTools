namespace CSSPDBAzureServices.Tests;

public partial class TVItemAzureServiceTest
{
    [Theory(Skip = "Skipping this test for now")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTVItemAzureStartDateListAsync_Good_Test(string culture)
    {
        Assert.True(await TVItemAzureServiceSetup(culture));

        var actionRes = await TVItemAzureService.GetTVItemAzureStartDateListAsync(2021, 1, 1);
        Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionRes.Result).Value;
        Assert.NotNull(tvItemList);
    }
}

