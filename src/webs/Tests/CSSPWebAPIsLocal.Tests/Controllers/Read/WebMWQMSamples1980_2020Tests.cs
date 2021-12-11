namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMSamples1980_2020_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples1980_2020;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);
        GetJsonGzFileFromAzure(FileName);
        SendJsonGzFileToAzure(FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMWQMSamples1980_2020 webMWQMSamples1980_2020 = JsonSerializer.Deserialize<WebMWQMSamples1980_2020>(responseContent);
            Assert.NotNull(webMWQMSamples1980_2020);
            Assert.NotNull(webMWQMSamples1980_2020.MWQMSampleModelList);
        }
    }
}
