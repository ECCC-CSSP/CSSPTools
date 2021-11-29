namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class AzureAppTaskController : ControllerBase, IAppTaskController
{
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IAzureAppTaskService AzureAppTaskService { get; }

    public AzureAppTaskController(ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, IAzureAppTaskService AzureAppTaskService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.AzureAppTaskService = AzureAppTaskService;
    }
}

