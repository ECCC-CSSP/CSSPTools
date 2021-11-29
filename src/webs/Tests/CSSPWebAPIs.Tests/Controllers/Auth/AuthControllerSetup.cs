namespace CSSPWebAPIs.AuthController.Tests;

[Collection("Sequential")]
public partial class CSSPWebAPIsAuthControllerTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private CSSPDBContext db { get; set; }
    private IContactDBService ContactDBService { get; set; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ITVItemDBService TVItemDBService { get; set; }
    private Contact contact { get; set; }
    private string LoginEmail { get; set; }
    private string Password { get; set; }
    private LoginModel loginModel { get; set; }
    private string CSSPAzureUrl { get; set; }

    private async Task<bool> AuthControllerSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapistests.json")
           .AddUserSecrets("e43608c0-3ec4-4b6c-b995-a4be7848ec8b")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        LoginEmail = Configuration.GetValue<string>("LoginEmail");
        Assert.NotNull(LoginEmail);

        Password = Configuration.GetValue<string>("Password");
        Assert.NotNull(Password);

        loginModel = new LoginModel()
        {
            LoginEmail = LoginEmail,
            Password = Password
        };

        CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
        Assert.NotNull(CSSPAzureUrl);

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonSerializer.Serialize(loginModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
            Assert.True((int)response.StatusCode == 200);

            contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);
        }

        return await Task.FromResult(true);
    }
}

