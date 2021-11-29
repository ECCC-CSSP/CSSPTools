namespace CSSPWebAPIsLocal.LocalizeAzureFileController.Tests;

public partial class CSSPWebAPIsLocalLocalizeAzureFileControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFileController_Constructor_Good_Test(string culture)
    {
        Assert.True(await LocalizeAzureFileSetupAsync(culture));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LocalizeAzureFileController_1_BarTopBottom_png_Good_Test(string culture)
    {
        Assert.True(await LocalizeAzureFileSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ LocalUrl }api/{ culture }/LocalizeAzureFile/1/BarTopBottom.png";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            bool retBool = JsonSerializer.Deserialize<bool>(responseContent);
            Assert.True(retBool);
        }
    }
}

