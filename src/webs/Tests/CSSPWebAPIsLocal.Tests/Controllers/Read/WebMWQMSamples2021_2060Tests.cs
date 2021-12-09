namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMSamples2021_2060_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;
        int TVItemID = 635;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMWQMSamples webMWQMSample = JsonSerializer.Deserialize<WebMWQMSamples>(responseContent);
            Assert.NotNull(webMWQMSample);
            Assert.NotNull(webMWQMSample.MWQMSampleModelList);
        }
    }
}
