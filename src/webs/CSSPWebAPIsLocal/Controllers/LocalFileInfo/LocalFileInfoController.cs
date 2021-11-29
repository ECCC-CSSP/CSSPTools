namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class LocalFileInfoController : ControllerBase, ILocalFileInfoController
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICSSPFileService FileService { get; }

    public LocalFileInfoController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService,
        ICSSPLocalLoggedInService CSSPLocalLoggedInService, ICSSPFileService FileService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.Configuration = Configuration;
        this.FileService = FileService;
    }
}

