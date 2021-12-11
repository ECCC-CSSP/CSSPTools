namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebMWQMSamples2021_2060_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        int TVItemID = 635;
        WebTypeEnum webType = WebTypeEnum.WebMWQMSamples2021_2060;

        string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);
        GetJsonGzFileFromAzure(FileName);
        SendJsonGzFileToAzure(FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/Read/{ webType }/{ TVItemID }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebMWQMSamples2021_2060 webMWQMSamples2021_2060 = JsonSerializer.Deserialize<WebMWQMSamples2021_2060>(responseContent);
            Assert.NotNull(webMWQMSamples2021_2060);
            Assert.NotNull(webMWQMSamples2021_2060.MWQMSampleModelList);
        }
    }
}
