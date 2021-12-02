namespace CSSPDBLocalServices;

public partial class HelperLocalService : ControllerBase, IHelperLocalService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPLogService CSSPLogService { get; }
    private CSSPDBLocalContext dbLocal { get; }
    private ICSSPReadGzFileService CSSPReadGzFileService { get; }
    private ICSSPCreateGzFileService CSSPCreateGzFileService { get; }
    private List<ToRecreate> ToRecreateList { get; set; }

    public HelperLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
       ICSSPLogService CSSPLogService, CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage,
       ICSSPReadGzFileService CSSPReadGzFileService, ICSSPCreateGzFileService CSSPCreateGzFileService)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
        if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
        if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
        if (CSSPReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "ReadGzFileService") }");
        if (CSSPCreateGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CreateGzFileService") }");

        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "HelperLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "HelperLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "HelperLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "HelperLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "HelperLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "HelperLocalService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CSSPLogService = CSSPLogService;
        this.dbLocal = dbLocal;
        this.CSSPReadGzFileService = CSSPReadGzFileService;
        this.CSSPCreateGzFileService = CSSPCreateGzFileService;

        ToRecreateList = new List<ToRecreate>();
    }
}
