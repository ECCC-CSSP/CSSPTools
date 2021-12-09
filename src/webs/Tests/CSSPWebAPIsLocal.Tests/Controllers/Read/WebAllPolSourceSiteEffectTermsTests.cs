namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = JsonSerializer.Deserialize<WebAllPolSourceSiteEffectTerms>(responseContent);
            Assert.NotNull(webAllPolSourceSiteEffectTerms);
            Assert.NotNull(webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList);
        }
    }
}
