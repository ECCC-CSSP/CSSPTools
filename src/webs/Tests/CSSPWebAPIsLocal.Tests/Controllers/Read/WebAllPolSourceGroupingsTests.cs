namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllPolSourceGroupings_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebAllPolSourceGroupings webAllPolSourceGroupings = JsonSerializer.Deserialize<WebAllPolSourceGroupings>(responseContent);
            Assert.NotNull(webAllPolSourceGroupings);
            Assert.NotNull(webAllPolSourceGroupings.PolSourceGroupingModelList);
        }
    }
}
