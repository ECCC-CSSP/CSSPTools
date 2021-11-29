namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class TVItemLocalController : ControllerBase, ITVItemLocalController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ITVItemLocalService TVItemService { get; }

    public TVItemLocalController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
        ITVItemLocalService PostTVItemModelService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.TVItemService = PostTVItemModelService;
    }
}

