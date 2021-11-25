namespace CSSPDBServices;

public partial class ContactDBService : ControllerBase, IContactDBService
{
    private IConfiguration Configuration { get; }
    private ICSSPScrambleService CSSPScrambleService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext db { get; }
    private ErrRes errRes { get; set; } = new ErrRes();

    public ContactDBService(IConfiguration Configuration, ICSSPScrambleService CSSPScrambleService,
       ICSSPCultureService CSSPCultureService, IEnums enums,
       ICSSPServerLoggedInService CSSPServerLoggedInService,
       CSSPDBContext db)
    {
        this.Configuration = Configuration;
        this.CSSPScrambleService = CSSPScrambleService;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.db = db;
    }
}

