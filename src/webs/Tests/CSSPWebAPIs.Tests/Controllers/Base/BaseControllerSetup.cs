namespace CSSPWebAPIs.Tests;

[Collection("Sequential")]
public partial class BaseControllerTests
{
    protected IConfiguration Configuration { get; set; }
    protected IServiceProvider Provider { get; set; }
    protected IServiceCollection Services { get; set; }
    protected Contact ContactTest { get; set; }

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

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }version").Result;
                Assert.True((int)response.StatusCode == 200);
            }
            catch (Exception)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Http server is probably not running. Please run server { Configuration["CSSPAzureUrl"] }");
                sb.AppendLine($"You will need to open another solution with CSSPWebAPIs set CSSPWebAPIs as Default startup and press F5");
                Assert.True(false, sb.ToString());
            }
        }

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
            HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/auth/token", contentData).Result;
            Assert.True((int)response.StatusCode == 200);

            ContactTest = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
            Assert.NotNull(ContactTest);
        }

        return await Task.FromResult(true);
    }
}

