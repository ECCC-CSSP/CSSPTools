namespace CSSPDBAzureServices;

public partial class TVItemAzureService : ControllerBase, ITVItemAzureService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext db { get; }

    private ErrRes errRes { get; set; } = new ErrRes();

    public TVItemAzureService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
    {
        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.enums = enums;
        this.db = db;
    }
}

