namespace CSSPServerTaskRunnerServices;

public partial class ServerTaskRunnerService : ControllerBase, IServerTaskRunnerService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext dbAzure { get; }

    public ServerTaskRunnerService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
        ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext dbAzure)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.dbAzure = dbAzure;
    }
}
