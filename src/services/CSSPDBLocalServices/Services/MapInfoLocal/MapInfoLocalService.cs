namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPLogService CSSPLogService { get; }
    private CSSPDBLocalContext dbLocal { get; }
    private ICSSPReadGzFileService CSSPReadGzFileService { get; }
    private ICSSPCreateGzFileService CSSPCreateGzFileService { get; }
    private IHelperLocalService HelperLocalService { get; }
    private List<ToRecreate> ToRecreateList { get; set; }
    private double R = 6378137.0;
    private double d2r = Math.PI / 180;
    private double r2d = 180 / Math.PI;

    public MapInfoLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
       ICSSPLogService CSSPLogService, CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage, ICSSPReadGzFileService CSSPReadGzFileService,
       ICSSPCreateGzFileService CSSPCreateGzFileService, IHelperLocalService HelperLocalService)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
        if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
        if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
        if (CSSPReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPReadGzFileService") }");
        if (CSSPCreateGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCreateGzFileService") }");
        if (HelperLocalService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "HelperLocalService") }");

        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "MapInfoLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "MapInfoLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "MapInfoLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "MapInfoLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "MapInfoLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "MapInfoLocalService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CSSPLogService = CSSPLogService;
        this.dbLocal = dbLocal;
        this.CSSPReadGzFileService = CSSPReadGzFileService;
        this.CSSPCreateGzFileService = CSSPCreateGzFileService;
        this.HelperLocalService = HelperLocalService;

        ToRecreateList = new List<ToRecreate>();

        if (r2d == 0.0D)
        {
            // nothing 
            // this if is just to remove the warning that the r2d is not use
            // it will be use in the future and this if should be removed.
        }
    }
}

