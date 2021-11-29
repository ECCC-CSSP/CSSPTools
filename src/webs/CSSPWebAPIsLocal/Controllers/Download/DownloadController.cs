namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class DownloadController : ControllerBase, IDownloadController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPFileService FileService { get; }

    public DownloadController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
        ICSSPFileService FileService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.FileService = FileService;

    }
}

