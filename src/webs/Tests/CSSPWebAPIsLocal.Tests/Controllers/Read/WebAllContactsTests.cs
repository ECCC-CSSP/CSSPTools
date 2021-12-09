namespace CSSPWebAPIsLocal.Tests;

public partial class ReadControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task WebAllContacts_Good_Test(string culture)
    {
        Assert.True(await ReadControllerSetupAsync(culture));

        WebTypeEnum webType = WebTypeEnum.WebAllContacts;

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/Read/{ webType }";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            WebAllContacts webAllContacts = JsonSerializer.Deserialize<WebAllContacts>(responseContent);
            Assert.NotNull(webAllContacts);
            Assert.NotNull(webAllContacts.ContactModelList);
        }
    }
}

