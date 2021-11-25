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
    private CSSPDBManageContext dbManage { get; set; }
    private string appsettings { get; set; } = "appsettings_cssplogservicestests.json";

    private async Task<bool> CSSPLogServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_cssplogservicestests.json")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        /* ---------------------------------------------------------------------------------
         * Creating an empty CSSPDBManage SQLite test database
         * ---------------------------------------------------------------------------------      
         */
        Assert.NotNull(Configuration["CSSPDBManage"]);

        string CSSPDBManageTest = Configuration["CSSPDBManage"].Replace(".db", "_test.db");


        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        Assert.True(fiCSSPDBManage.Exists);

        FileInfo fiCSSPDBManageTest = new FileInfo(CSSPDBManageTest);
        try
        {
            File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName, true);
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not copy {fiCSSPDBManage.FullName} to {fiCSSPDBManageTest.FullName}. Ex: {ex.Message}");
        }

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManageTest.FullName }");
        });

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPLogService = Provider.GetService<ICSSPLogService>();
        Assert.NotNull(CSSPLogService);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);

        CSSPLogService.CSSPAppName = "CSSPLogService_AppName";
        CSSPLogService.CSSPCommandName = "CSSPLogService_CommandName";

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                   select c).ToList();

        try
        {
            dbManage.RemoveRange(commandLogToDeleteList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all CommandLogs from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
        }

        return await Task.FromResult(true);
    }
}

