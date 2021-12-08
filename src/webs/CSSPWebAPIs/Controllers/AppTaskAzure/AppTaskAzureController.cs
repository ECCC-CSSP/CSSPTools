namespace CSSPWebAPIs.Controllers;

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public partial class AppTaskAzureController : ControllerBase, IAppTaskAzureController
{
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IAppTaskAzureService AppTaskAzureService { get; }
    private CSSPDBContext dbAzure { get; }

    public AppTaskAzureController(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, 
        ICSSPServerLoggedInService CSSPServerLoggedInService, IAppTaskAzureService AppTaskAzureService, CSSPDBContext dbAzure)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
        if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
        if (dbAzure == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbAzure") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBAzure"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBAzure", "AppTaskAzureService") }");

        this.CSSPCultureService = CSSPCultureService;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.AppTaskAzureService = AppTaskAzureService ?? throw new System.ArgumentNullException(nameof(AppTaskAzureService));
        this.dbAzure = dbAzure;
    }
}

