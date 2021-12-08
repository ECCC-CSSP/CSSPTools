namespace CSSPDBAzureServices;

public partial class TVTypeUserAuthorizationAzureService : ControllerBase, ITVTypeUserAuthorizationAzureService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext dbAzure { get; }
    private ErrRes errRes { get; set; } = new ErrRes();

    public TVTypeUserAuthorizationAzureService(ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext dbAzure)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.dbAzure = dbAzure;
    }
}

