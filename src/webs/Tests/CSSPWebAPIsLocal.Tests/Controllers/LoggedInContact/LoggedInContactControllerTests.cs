namespace CSSPWebAPIsLocal.Tests;

public partial class LoggedInContactControllerTests : CSSPWebAPIsLocalTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Get_Good_Test(string culture)
    {
        Assert.True(await LoggedInContactControllerSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ Configuration["LocalUrl"] }api/{ culture }/LoggedInContact";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Contact contactRet = JsonSerializer.Deserialize<Contact>(responseContent);
            Assert.NotNull(contactRet);
            Assert.True(contactRet.ContactTVItemID > 0);
        }
    }
}

