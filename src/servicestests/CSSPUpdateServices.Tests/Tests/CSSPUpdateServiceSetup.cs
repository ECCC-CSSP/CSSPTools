namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private IEnums enums { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPCreateGzFileService CreateGzFileService { get; set; }
    public ICSSPUpdateService CSSPUpdateService { get; set; }
    private CSSPDBContext db { get; set; }
    private CSSPDBManageContext dbManage { get; set; }

    private async Task<bool> CSSPUpdateServiceSetup(string culture)
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspupdateservicestests.json")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        Assert.NotNull(Configuration["azure_csspjson_backup"]);
        Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
        Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPAzureUrl"]);
        Assert.Contains("csspwebapis.", Configuration["CSSPAzureUrl"]);
        Assert.NotNull(Configuration["CSSPLocalUrl"]);
        Assert.NotNull(Configuration["CSSPDatabasesPath"]);
        Assert.NotNull(Configuration["CSSPDesktopPath"]);
        Assert.Contains("localhost:", Configuration["CSSPLocalUrl"]);
        Assert.NotNull(Configuration["CSSPDB"]);
        Assert.NotNull(Configuration["CSSPDBManage"]);
        Assert.Contains("_test", Configuration["CSSPDBManage"]);
        Assert.NotNull(Configuration["CSSPFilesPath"]);
        Assert.NotNull(Configuration["CSSPJSONPath"]);
        Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
        Assert.NotNull(Configuration["CSSPTempFilesPath"]);
        Assert.NotNull(Configuration["LocalAppDataPath"]);
        Assert.NotNull(Configuration["NationalBackupAppDataPath"]);

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPLogService, CSSPLogService>();
        Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
        Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
        Services.AddSingleton<ICSSPUpdateService, CSSPUpdateService>();

        /* ---------------------------------------------------------------------------------
         * CSSPDBContext
         * ---------------------------------------------------------------------------------      
         */
        Services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDB"]);
        });

        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"].Replace("_test", ""));
        Assert.True(fiCSSPDBManage.Exists);

        FileInfo fiCSSPDBManageTest = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fiCSSPDBManageTest.Exists)
        {
            try
            {
                File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not copy {fiCSSPDBManage.FullName} to {fiCSSPDBManageTest.FullName}. Ex: {ex.Message}");
            }
        }

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */
        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManageTest.FullName }");
        });

        Provider = Services.BuildServiceProvider();
        Assert.NotNull(Provider);

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        enums = Provider.GetService<IEnums>();
        Assert.NotNull(enums);

        CSSPLogService = Provider.GetService<ICSSPLogService>();
        Assert.NotNull(CSSPLogService);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
        Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);

        CreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
        Assert.NotNull(CreateGzFileService);

        CSSPUpdateService = Provider.GetService<ICSSPUpdateService>();
        Assert.NotNull(CSSPUpdateService);

        db = Provider.GetService<CSSPDBContext>();
        Assert.NotNull(db);

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                   select c).ToList();

        try
        {
            dbManage.CommandLogs.RemoveRange(commandLogToDeleteList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all CommandLogs from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
        }

        List<ManageFile> manageFileToDeleteList = (from c in dbManage.ManageFiles
                                                   select c).ToList();

        try
        {
            dbManage.ManageFiles.RemoveRange(manageFileToDeleteList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all ManageFiles from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
        }


        return await Task.FromResult(true);
    }
}

