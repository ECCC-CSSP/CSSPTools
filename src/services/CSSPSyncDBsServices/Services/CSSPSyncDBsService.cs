namespace CSSPSyncDBsServices;

public partial class CSSPSyncDBsService : ControllerBase, ICSSPSyncDBsService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private CSSPDBContext dbAzure { get; }

    public CSSPSyncDBsService(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, 
        CSSPDBContext dbAzure)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.dbAzure = dbAzure;
    }
}
