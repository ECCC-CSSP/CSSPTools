namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class AuthController : ControllerBase, IAuthController
{
    private IConfiguration Configuration { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IContactAzureService ContactAzureService { get; }
    private CSSPDBContext dbAzure { get; }

    public AuthController(IConfiguration Configuration, ICSSPServerLoggedInService CSSPServerLoggedInService, ICSSPCultureService CSSPCultureService,
        IContactAzureService ContactAzureService, CSSPDBContext dbAzure)
    {
        this.Configuration = Configuration;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.CSSPCultureService = CSSPCultureService;
        this.ContactAzureService = ContactAzureService;
        this.dbAzure = dbAzure; 
    }
}

