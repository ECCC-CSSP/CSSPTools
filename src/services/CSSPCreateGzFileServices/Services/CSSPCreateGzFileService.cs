namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private CSSPDBContext db { get; }
    private CSSPDBLocalContext dbLocal { get; }
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLogService CSSPLogService { get; set; }
    private bool Local { get; set; } = false;

    public CSSPCreateGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
        ICSSPScrambleService CSSPScrambleService, ICSSPLogService CSSPLogService, CSSPDBManageContext dbManage, CSSPDBContext db, CSSPDBLocalContext dbLocal)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
        if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");
        if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
        if (db == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");
        if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CreateGzFileService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CSSPScrambleService = CSSPScrambleService;
        this.CSSPLogService = CSSPLogService;
        this.db = db;
        this.dbLocal = dbLocal;
    }
}

