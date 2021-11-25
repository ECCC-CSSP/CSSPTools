namespace CSSPServerTaskRunnerServices;

public partial class ServerTaskRunnerService : ControllerBase, IServerTaskRunnerService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ICSSPLogService CSSPLogService { get; }
    private IEnums enums { get; }
    private CSSPDBContext db { get; }
    private CSSPDBManageContext dbManage { get; }

    public ServerTaskRunnerService(ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, 
        ICSSPLogService CSSPLogService, CSSPDBContext db, CSSPDBManageContext dbManage)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.CSSPLogService = CSSPLogService;
        this.enums = enums;
        this.db = db;
        this.dbManage = dbManage;
    }
}
