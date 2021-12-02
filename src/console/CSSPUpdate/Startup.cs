namespace CSSPUpdate;

public partial class Startup
{
    public ICSSPUpdateService CSSPUpdateService { get; set; }

    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private IEnums enums { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPCreateGzFileService CreateGzFileService { get; set; }
    private CSSPDBContext db { get; set; }
    private CSSPDBManageContext dbManage { get; set; }
    private CSSPDBLocalContext dbLocal { get; set; }
    private string AzureStoreHash { get; set; }

    public Startup()
    {
    }

    public async Task<bool> Setup()
    {
        Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings_csspupdate.json")
           .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);

        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["LocalAppDataPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LocalAppDataPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["NationalBackupAppDataPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "NationalBackupAppDataPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPUpdate") }");
        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPUpdate") }");

        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<IEnums, Enums>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
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

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */

        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fiCSSPDBManage.Exists)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.FileNotFound_, fiCSSPDBManage.FullName) }");
            return await Task.FromResult(false);
        }

        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
        });

        /* ---------------------------------------------------------------------------------
         * CSSPDBLocalContext
         * ---------------------------------------------------------------------------------      
         */

        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
        if (!fiCSSPDBLocal.Exists)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.FileNotFound_, fiCSSPDBManage.FullName) }");
            return await Task.FromResult(false);
        }

        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
        });

        Provider = Services.BuildServiceProvider();
        if (Provider == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Provider") }");
            return await Task.FromResult(false);
        }

        db = Provider.GetService<CSSPDBContext>();
        if (db == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");
            return await Task.FromResult(false);
        }

        dbManage = Provider.GetService<CSSPDBManageContext>();
        if (dbManage == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
            return await Task.FromResult(false);
        }

        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        if (CSSPCultureService == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            return await Task.FromResult(false);
        }

        enums = Provider.GetService<IEnums>();
        if (enums == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            return await Task.FromResult(false);
        }

        CSSPLogService = Provider.GetService<ICSSPLogService>();
        if (CSSPLogService == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService ") }");
            return await Task.FromResult(false);
        }

        CSSPLogService.CSSPAppName = "CSSPUpdate";
        CSSPLogService.CSSPCommandName = "Unknown";

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        if (CSSPLocalLoggedInService == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
            return await Task.FromResult(false);
        }

        await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
        if (CSSPLocalLoggedInService.LoggedInContactInfo == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService.LoggedInContactInfo") }");
            return await Task.FromResult(false);
        }

        AzureStoreHash = (from c in dbManage.Contacts
                          where c.ContactID == CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactID
                          select c.AzureStoreHash).FirstOrDefault();
        if (string.IsNullOrWhiteSpace(AzureStoreHash))
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "AzureStoreHash") }");
            return await Task.FromResult(false);
        }

        CreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
        if (CreateGzFileService == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CreateGzFileService") }");
            return await Task.FromResult(false);
        }

        CSSPUpdateService = Provider.GetService<ICSSPUpdateService>();
        if (CSSPUpdateService == null)
        {
            Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPUpdateService") }");
            return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }
}

