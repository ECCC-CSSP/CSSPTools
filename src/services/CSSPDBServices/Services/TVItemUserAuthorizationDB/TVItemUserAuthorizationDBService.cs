namespace CSSPDBServices;

public partial class TVItemUserAuthorizationDBService : ControllerBase, ITVItemUserAuthorizationDBService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext db { get; }
    private ErrRes errRes { get; set; } = new ErrRes();

    public TVItemUserAuthorizationDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.db = db;
    }
}

