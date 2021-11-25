using CSSPLogServices;
using ManageServices;

namespace CSSPLocalTaskRunnerServices;

public partial class LocalTaskRunnerService : ControllerBase, ICSSPLocalTaskRunnerService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPLogService CSSPLogService { get; }
    private IEnums enums { get; }
    private List<ValidationResult> ValidationResults { get; set; }
    private CSSPDBContext db { get; }
    private CSSPDBManageContext dbManage { get; }

    public LocalTaskRunnerService(ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService, 
        ICSSPLogService CSSPLogService, CSSPDBContext db, CSSPDBManageContext dbManage)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CSSPLogService = CSSPLogService;
        this.enums = enums;
        this.db = db;
        this.dbManage = dbManage;
    }
}
