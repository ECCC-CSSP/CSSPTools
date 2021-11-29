namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class TVTypeUserAuthorizationController : ControllerBase, ITVTypeUserAuthorizationController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService { get; }

    public TVTypeUserAuthorizationController(ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, ITVTypeUserAuthorizationDBService TVTypeUserAuthorizationDBService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.TVTypeUserAuthorizationDBService = TVTypeUserAuthorizationDBService;
    }
}

