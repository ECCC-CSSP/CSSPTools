namespace CSSPDBAzureServices;

public partial class ContactAzureService : ControllerBase, IContactAzureService
{
    private IConfiguration Configuration { get; }
    private ICSSPScrambleService CSSPScrambleService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IEnums enums { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private CSSPDBContext dbAzure { get; }
    private ErrRes errRes { get; set; } = new ErrRes();

    public ContactAzureService(IConfiguration Configuration, ICSSPScrambleService CSSPScrambleService,
       ICSSPCultureService CSSPCultureService, IEnums enums,
       ICSSPServerLoggedInService CSSPServerLoggedInService,
       CSSPDBContext dbAzure)
    {
        this.Configuration = Configuration;
        this.CSSPScrambleService = CSSPScrambleService;
        this.CSSPCultureService = CSSPCultureService;
        this.enums = enums;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.dbAzure = dbAzure;
    }
}

