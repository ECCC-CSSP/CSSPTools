namespace CSSPAzureAppTaskServices;

public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
{
    private CSSPDBContext dbAzure { get; }
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ErrRes errRes { get; set; } = new ErrRes();

    public AzureAppTaskService(IConfiguration Configuration, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext dbAzure)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
        if (dbAzure == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbAzure") }");

        if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "AzureAppTaskService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "AzureAppTaskService") }");

        this.enums = enums;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.dbAzure = dbAzure;
    }
}
