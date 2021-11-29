namespace CSSPWebAPIsLocal.LoggedInContactController.Tests;

public partial class CSSPWebAPIsLocalLoggedInContactControllerTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LoggedInContactController_Constructor_Good_Test(string culture)
    {
        Assert.True(await LoggedInContactSetupAsync(culture));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task LoggedInContactController_Get_Good_Test(string culture)
    {
        Assert.True(await LoggedInContactSetupAsync(culture));

        using (HttpClient httpClient = new HttpClient())
        {
            string url = $"{ LocalUrl }api/{ culture }/LoggedInContact";
            var response = await httpClient.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string responseContent = await response.Content.ReadAsStringAsync();
            Contact contactRet = JsonSerializer.Deserialize<Contact>(responseContent);
            Assert.NotNull(contactRet);
            Assert.True(contactRet.ContactTVItemID > 0);
        }
    }
}

