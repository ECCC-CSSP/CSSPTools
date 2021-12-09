namespace CSSPWebAPIs.Tests;

[Collection("Sequential")]
public partial class BaseControllerTests
{
    protected IConfiguration Configuration { get; set; }
    protected IServiceProvider Provider { get; set; }
    protected IServiceCollection Services { get; set; }
    protected Contact contact { get; set; }

    protected async Task<bool> BaseControllerSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapistests.json")
           .AddUserSecrets("CSSPWebAPIs_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["APISecret"]);
        Assert.NotNull(Configuration["CSSPDBAzure"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);
        Assert.NotNull(Configuration["AzureStoreHash"]);
        Assert.NotNull(Configuration["GoogleMapKeyHash"]);

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        LoginModel loginModel = new LoginModel()
        {
            LoginEmail = Configuration["LoginEmail"],
            Password = Configuration["Password"],
        };

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonSerializer.Serialize(loginModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/auth/token", contentData).Result;
            Assert.True((int)response.StatusCode == 200);

            contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            Assert.NotNull(contact);
        }

        return await Task.FromResult(true);
    }
}

