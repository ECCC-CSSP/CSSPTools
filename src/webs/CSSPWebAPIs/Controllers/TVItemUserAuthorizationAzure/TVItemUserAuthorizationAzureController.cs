namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class TVItemUserAuthorizationAzureController : ControllerBase, ITVItemUserAuthorizationAzureController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ITVItemUserAuthorizationAzureService TVItemUserAuthorizationAzureService { get; }

    public TVItemUserAuthorizationAzureController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, ITVItemUserAuthorizationAzureService TVItemUserAuthorizationAzureService)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
        if (TVItemUserAuthorizationAzureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "TVItemUserAuthorizationAzureService") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBAzure"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBAzure", "AppTaskAzureService") }");

        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.TVItemUserAuthorizationAzureService = TVItemUserAuthorizationAzureService;
    }
}

