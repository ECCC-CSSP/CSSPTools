namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class LoggedInContactController : ControllerBase, ILoggedInContactController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPScrambleService CSSPScrambleService { get; }
    private ICSSPLogService CSSPLogService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }

    public LoggedInContactController(ICSSPCultureService CSSPCultureService, ICSSPScrambleService CSSPScrambleService,
        ICSSPLogService CSSPLogService, ICSSPLocalLoggedInService CSSPLocalLoggedInService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPScrambleService = CSSPScrambleService;
        this.CSSPLogService = CSSPLogService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
    }
}

