namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    public ErrRes errRes { get; set; }
    private CSSPDBLocalContext dbLocal { get; }
    private CSSPDBManageContext dbManage { get; }
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private IEnumerable<ValidationResult> ValidationResults { get; set; }

    public CSSPSQLiteService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CreateGzFileService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CreateGzFileService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.dbLocal = dbLocal;
        this.dbManage = dbManage;
    }
}

