namespace CSSPWebAPIsLocal.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
public partial class CountryLocalController : ControllerBase, ICountryLocalController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private ICountryLocalService CountryLocalService { get; }

    public CountryLocalController(ICSSPCultureService CSSPCultureService, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
        ICountryLocalService CountryLocalService)
    {
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.CountryLocalService = CountryLocalService;
    }
}

