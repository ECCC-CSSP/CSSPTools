namespace CSSPDBAzureServices;

public partial class TVItemUserAuthorizationAzureService : ControllerBase, ITVItemUserAuthorizationAzureService
{
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext dbAzure { get; }
    private ErrRes errRes { get; set; } = new ErrRes();

    public TVItemUserAuthorizationAzureService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext dbAzure)
    {
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.dbAzure = dbAzure;
    }
}

