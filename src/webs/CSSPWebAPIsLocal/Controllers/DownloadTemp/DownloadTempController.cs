namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class DownloadTempController : ControllerBase, IDownloadTempController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPFileService FileService { get; }

    public DownloadTempController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, ICSSPFileService FileService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.FileService = FileService;

    }
}

