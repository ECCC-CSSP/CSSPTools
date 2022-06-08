namespace CSSPLogServices.Tests;

[Collection("Sequential")]
public partial class CSSPLogServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> CSSPLogServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_cssplogservicestests.json")
           .AddUserSecrets("CSSPLogServices_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["CSSPDBLocal"]);
        Assert.Contains("Test", Configuration["CSSPDBLocal"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.Contains("Test", Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["LoginEmail"]);
        Assert.NotNull(Configuration["Password"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
        Services.AddSingleton<ICSSPAzureLoginService, CSSPAzureLoginService>();

        CheckRequiredDirectories();

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBManage"] }");
        });

        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBLocal"] }");
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        await GetProviderServices(culture);
     
        List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                   select c).ToList();

        try
        {
            dbManage.RemoveRange(commandLogToDeleteList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all CommandLogs from { Configuration["CSSPDBManage"] }. Ex: { ex.Message }");
        }

        return await Task.FromResult(true);
    }
}

