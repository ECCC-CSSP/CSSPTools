namespace CSSPDBLocalServices;

public partial class AddressLocalService : ControllerBase, IAddressLocalService
{
    private CSSPDBLocalContext dbLocal { get; }
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPLogService CSSPLogService { get; }
    private ICSSPCreateGzFileService CSSPCreateGzFileService { get; }
    private ICSSPReadGzFileService CSSPReadGzFileService { get; }
    private IHelperLocalService HelperLocalService { get; }
    private ITVItemLocalService TVItemLocalService { get; }

    public AddressLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
       ICSSPLogService CSSPLogService, ICSSPCreateGzFileService CSSPCreateGzFileService, ICSSPReadGzFileService CSSPReadGzFileService,
       CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage, IHelperLocalService HelperLocalService, ITVItemLocalService TVItemLocalService)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
        if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
        if (CSSPCreateGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCreateGzFileService") }");
        if (CSSPReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPReadGzFileService") }");
        if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
        if (HelperLocalService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "HelperLocalService ") }");
        if (TVItemLocalService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "TVItemLocalService") }");

        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "AddressLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "AddressLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "AddressLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "AddressLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "AddressLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "AddressLocalService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CSSPLogService = CSSPLogService;
        this.CSSPCreateGzFileService = CSSPCreateGzFileService;
        this.CSSPReadGzFileService = CSSPReadGzFileService;
        this.dbLocal = dbLocal;
        this.HelperLocalService = HelperLocalService;
        this.TVItemLocalService = TVItemLocalService;
    }
}
