using CSSPScrambleServices;

namespace CSSPDBAzureServices.Tests;

[Collection("Sequential")]
public partial class CSSPDBAzureBaseServiceTest
{
    protected IConfiguration Configuration { get; set; }
    protected IServiceProvider Provider { get; set; }
    protected IServiceCollection Services { get; set; }
    protected ICSSPCultureService CSSPCultureService { get; set; }
    protected ICSSPScrambleService CSSPScrambleService { get; set; }
    protected ICSSPServerLoggedInService CSSPServerLoggedInService { get; set; }
    protected IAppTaskAzureService AppTaskAzureService { get; set; }
    protected IContactAzureService ContactAzureService { get; set; }
    protected ITVItemAzureService TVItemAzureService { get; set; }
    protected ITVItemUserAuthorizationAzureService TVItemUserAuthorizationAzureService { get; set; }
    protected ITVTypeUserAuthorizationAzureService TVTypeUserAuthorizationAzureService { get; set; }
    protected IContactAzureService AzureService { get; set; }
    protected CSSPDBContext dbTempAzureTest { get; set; }
    protected LoginModel loginModel { get; set; }
    protected Contact contact { get; set; }

    protected async Task<bool> CSSPDBAzureBaseServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspdbazureservicestests.json")
           .AddUserSecrets("CSSPDBAzureServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDBAzure"]);
        Assert.Contains("CSSPTemporaryDB", Configuration["CSSPDBAzure"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);
        Assert.NotNull(Configuration["APISecret"]);
        Assert.NotNull(Configuration["AzureStoreHash"]);
        Assert.NotNull(Configuration["GoogleMapKeyHash"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPServerLoggedInService, CSSPServerLoggedInService>();
        Services.AddSingleton<IEnums, Enums>();

        Services.AddSingleton<IAppTaskAzureService, AppTaskAzureService>();
        Services.AddSingleton<IContactAzureService, ContactAzureService>();
        Services.AddSingleton<ITVItemAzureService, TVItemAzureService>();
        Services.AddSingleton<ITVItemUserAuthorizationAzureService, TVItemUserAuthorizationAzureService>();
        Services.AddSingleton<ITVTypeUserAuthorizationAzureService, TVTypeUserAuthorizationAzureService>();

        /* ---------------------------------------------------------------------------------
         * using CSSPDBAzure
         * ---------------------------------------------------------------------------------      
         */

        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDBAzure"]);
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        Assert.NotNull(CSSPScrambleService);

        CSSPServerLoggedInService = Provider.GetService<ICSSPServerLoggedInService>();
        Assert.NotNull(CSSPServerLoggedInService);

        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(Configuration["LoginEmail"]);
        Assert.NotNull(CSSPServerLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact);
        Assert.True(CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.ContactID > 0);

        dbTempAzureTest = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(dbTempAzureTest);

        AppTaskAzureService = Provider.GetService<IAppTaskAzureService>();
        Assert.NotNull(AppTaskAzureService);

        ContactAzureService = Provider.GetService<IContactAzureService>();
        Assert.NotNull(ContactAzureService);

        TVItemAzureService = Provider.GetService<ITVItemAzureService>();
        Assert.NotNull(TVItemAzureService);

        TVItemUserAuthorizationAzureService = Provider.GetService<ITVItemUserAuthorizationAzureService>();
        Assert.NotNull(TVItemUserAuthorizationAzureService);

        TVTypeUserAuthorizationAzureService = Provider.GetService<ITVTypeUserAuthorizationAzureService>();
        Assert.NotNull(TVTypeUserAuthorizationAzureService);

        return await Task.FromResult(true);
    }
}

