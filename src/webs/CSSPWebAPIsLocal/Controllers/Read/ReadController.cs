namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class ReadController : ControllerBase, IReadController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPReadGzFileService ReadGzFileService { get; }

    public ReadController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
        ICSSPReadGzFileService ReadGzFileService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.ReadGzFileService = ReadGzFileService;

    }
}

