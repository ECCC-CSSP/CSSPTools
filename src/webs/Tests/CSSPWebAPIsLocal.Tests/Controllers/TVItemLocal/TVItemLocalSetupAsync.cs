namespace CSSPWebAPIsLocal.Tests;

public partial class TVItemLocalControllerTests : CSSPWebAPIsLocalTests
{
    //private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    //private CSSPDBLocalContext dbLocal { get; set; }
    private string CSSPJSONPath { get; set; }
    private string CSSPJSONPathLocal { get; set; }
    private string LocalUrl { get; set; }
    private Contact contact { get; set; }

    public TVItemLocalControllerTests() : base()
    {
    }

    private async Task<bool> TVItemLocalSetupAsync(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspwebapislocaltests.json")
           .AddUserSecrets("CSSPWebAPIsLocal_Tests")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        LocalUrl = Configuration.GetValue<string>("LocalUrl");
        Assert.NotNull(LocalUrl);

        CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
        Assert.NotNull(CSSPJSONPath);

        CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
        Assert.NotNull(CSSPJSONPathLocal);

        DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
        Assert.True(di.Exists);

        try
        {
            di.Delete(true);
            di.Create();
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
        Assert.NotNull(CSSPDBLocal);

        FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

        /* ---------------------------------------------------------------------------------
         * CSSPDBLocalContext
         * ---------------------------------------------------------------------------------      
         */

        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
        });

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------
         */
        string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
        Assert.NotNull(CSSPDBManage);

        FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
        });

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);

        contact = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact;

        dbLocal = Provider.GetService<CSSPDBLocalContext>();
        Assert.NotNull(dbLocal);

        List<string> ExistingTableList = new List<string>();

        using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
            dbLocal.Database.OpenConnection();
            using (var result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    ExistingTableList.Add(result.GetString(0));
                }
            }
        }

        foreach (string tableName in ExistingTableList)
        {
            string TableIDName = "";

            if (tableName.StartsWith("AspNet") || tableName.StartsWith("DeviceCode") || tableName.StartsWith("Persisted")) continue;

            if (tableName == "Addresses")
            {
                TableIDName = tableName.Substring(0, tableName.Length - 2) + "ID";
            }
            else
            {
                TableIDName = tableName.Substring(0, tableName.Length - 1) + "ID";
            }

            dbLocal.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
        }

        return await Task.FromResult(true);
    }
}

