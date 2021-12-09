namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebProvince_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebProvince;
        int TVItemID = 7;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebProvince webProvince = JsonSerializer.Deserialize<WebProvince>(responseContent);
            Assert.NotNull(webProvince);
            Assert.NotNull(webProvince.TVItemModelAreaList);
            Assert.NotNull(webProvince.SamplingPlanModelList);
        }
    }
}
