namespace CSSPWebAPIs.Tests;

public partial class TVTypeUserAuthorizationAzureControllerTests : BaseControllerTests
{
    private async Task<bool> TVTypeUserAuthorizationAzureSetup(string culture)
    {
        await BaseControllerSetup(culture);

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);

            HttpResponseMessage response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(jsonStr);
            Assert.NotNull(tvTypeUserAuthorizationList);

            foreach (TVTypeUserAuthorization TVTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                response = await httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorizationAzure/{ TVTypeUserAuthorization.TVTypeUserAuthorizationID }");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                TVTypeUserAuthorization tvTypeUserAuthorization = JsonSerializer.Deserialize<TVTypeUserAuthorization>(jsonStr);
                Assert.NotNull(tvTypeUserAuthorization);
            }
        }

        return await Task.FromResult(true);
    }
}