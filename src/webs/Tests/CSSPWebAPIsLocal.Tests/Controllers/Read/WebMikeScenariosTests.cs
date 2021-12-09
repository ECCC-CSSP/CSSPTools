namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMikeScenarios_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
        int TVItemID = 27764;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMikeScenarios webMikeScenarios = JsonSerializer.Deserialize<WebMikeScenarios>(responseContent);
            Assert.NotNull(webMikeScenarios);
            Assert.NotNull(webMikeScenarios.MikeScenarioModelList);
        }
    }
}
