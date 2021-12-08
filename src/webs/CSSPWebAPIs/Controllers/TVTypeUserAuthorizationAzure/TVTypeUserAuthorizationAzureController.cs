namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class TVTypeUserAuthorizationAzureController : ControllerBase, ITVTypeUserAuthorizationAzureController
{
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ITVTypeUserAuthorizationAzureService TVTypeUserAuthorizationAzureService { get; }

    public TVTypeUserAuthorizationAzureController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ICSSPServerLoggedInService CSSPServerLoggedInService, ITVTypeUserAuthorizationAzureService TVTypeUserAuthorizationAzureService)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
        if (TVTypeUserAuthorizationAzureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "TVTypeUserAuthorizationAzureService") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBAzure"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBAzure", "AppTaskAzureService") }");

        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.TVTypeUserAuthorizationAzureService = TVTypeUserAuthorizationAzureService;
    }
}

