namespace CSSPDBLocalServices;

public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
{
    private CSSPDBLocalContext dbLocal { get; }
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPLogService CSSPLogService { get; }

    public AppTaskLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
       ICSSPLogService CSSPLogService, CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
        if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
        if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "AppTaskLocalService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "AppTaskLocalService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CSSPLogService = CSSPLogService;
        this.dbLocal = dbLocal;
    }
}
