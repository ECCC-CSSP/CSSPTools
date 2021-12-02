namespace CSSPAzureLoginServices.Services;

public partial class CSSPAzureLoginService : ICSSPAzureLoginService
{
    private IConfiguration Configuration { get; }
    private ICSSPLogService CSSPLogService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private CSSPDBManageContext dbManage { get; }
    private LoginModel loginModel { get; set; }
    private string culture { get; set; }

    public CSSPAzureLoginService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService,
        ICSSPLogService CSSPLogService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, CSSPDBManageContext dbManage)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPAzureLoginService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPAzureLoginService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPAzureLoginService") }");

        this.Configuration = Configuration;
        this.CSSPLogService = CSSPLogService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.dbManage = dbManage;
    }
}

