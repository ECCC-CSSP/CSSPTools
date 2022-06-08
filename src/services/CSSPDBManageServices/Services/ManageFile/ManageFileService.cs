namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    private CSSPDBManageContext DbManage { get; set; }
    private ErrRes ErrResult { get; set; } = new ErrRes();

    public ManageFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBManageContext dbManage)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService ") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");

        DbManage = dbManage ?? null;
    }
}

