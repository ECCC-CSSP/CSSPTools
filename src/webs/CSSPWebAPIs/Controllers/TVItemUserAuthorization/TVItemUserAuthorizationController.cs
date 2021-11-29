namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class TVItemUserAuthorizationController : ControllerBase, ITVItemUserAuthorizationController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService { get; }

    public TVItemUserAuthorizationController(ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, ITVItemUserAuthorizationDBService TVItemUserAuthorizationDBService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.TVItemUserAuthorizationDBService = TVItemUserAuthorizationDBService;
    }
}

