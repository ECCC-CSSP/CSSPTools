namespace CSSPWebAPIs.Tests;

public partial class TVItemUserAuthorizationAzureControllerTests : BaseControllerTests
{
    private async Task<bool> TVItemUserAuthorizationAzureSetup(string culture)
    {
        await BaseControllerSetup(culture);

        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
            
            HttpResponseMessage response = await httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ 1 }");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonStr = await response.Content.ReadAsStringAsync();
            List<TVItemUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(jsonStr);
            Assert.NotNull(tvItemUserAuthorizationList);
            
            foreach (TVItemUserAuthorization TVItemUserAuthorization in tvItemUserAuthorizationList)
            {
                response = await httpClient.DeleteAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ TVItemUserAuthorization.TVItemUserAuthorizationID }");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                jsonStr = await response.Content.ReadAsStringAsync();
                TVItemUserAuthorization tvItemUserAuthorization = JsonSerializer.Deserialize<TVItemUserAuthorization>(jsonStr);
                Assert.NotNull(tvItemUserAuthorization);
            }
        }

        return await Task.FromResult(true);
    }
}

