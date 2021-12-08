namespace CSSPDBAzureServices;

public partial class AppTaskAzureService : ControllerBase, IAppTaskAzureService
{
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ErrRes errRes { get; set; } = new ErrRes();
    private CSSPDBContext dbAzure { get; }

    public AppTaskAzureService(IConfiguration Configuration, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext dbAzure)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
        if (dbAzure == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbAzure") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBAzure"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBAzure", "AppTaskAzureService") }");

        this.enums = enums;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.dbAzure = dbAzure;
    }
}
