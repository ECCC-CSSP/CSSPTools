namespace CSSPWebAPIsLocal.Tests;

public partial class LocalizeAzureFileControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task BarTopBottom_png_Good_Test(string culture)
    {
        Assert.True(await LocalizeAzureFileControllerSetupAsync(culture));

        int ParentTVItemID = 1;
        string FileName = "BarTopBottom.png";

        GetFileFromAzure(ParentTVItemID, FileName);
        SendFileToAzure(ParentTVItemID, FileName);

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["CSSPLocalUrl"] }api/{ culture }/LocalizeAzureFile/1/BarTopBottom.png";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            bool retBool = JsonSerializer.Deserialize<bool>(responseContent);
            Assert.True(retBool);
        }
    }
}

