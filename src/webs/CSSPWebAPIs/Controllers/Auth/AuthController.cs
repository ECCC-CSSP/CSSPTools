namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class AuthController : ControllerBase, IAuthController
{
    private IConfiguration Configuration { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IContactDBService ContactDBService { get; }

    public AuthController(IConfiguration Configuration, ICSSPServerLoggedInService CSSPServerLoggedInService, ICSSPCultureService CSSPCultureService,
        IContactDBService ContactDBService)
    {
        this.Configuration = Configuration;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.CSSPCultureService = CSSPCultureService;
        this.ContactDBService = ContactDBService;
    }
}

