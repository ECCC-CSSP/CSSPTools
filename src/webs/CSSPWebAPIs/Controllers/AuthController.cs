namespace CSSPWebAPIs.Controllers;

public partial interface IAuthController
{
    Task<ActionResult<Contact>> Token(LoginModel loginModel);
    Task<ActionResult<string>> AzureStoreHash();
    Task<ActionResult<string>> GoogleMapKeyHash();
}

[Route("api/{culture}/[controller]")]
[ApiController]
//[Authorize]
public class AuthController : ControllerBase, IAuthController
{
    #region Variables
    #endregion Variables

    #region Properties
    private IConfiguration Configuration { get; }
    private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private IContactDBService ContactDBService { get; }
    #endregion Properties

    #region Constructors
    public AuthController(IConfiguration Configuration, ICSSPServerLoggedInService CSSPServerLoggedInService, ICSSPCultureService CSSPCultureService,
        IContactDBService ContactDBService)
    {
        this.Configuration = Configuration;
        this.CSSPServerLoggedInService = CSSPServerLoggedInService;
        this.CSSPCultureService = CSSPCultureService;
        this.ContactDBService = ContactDBService;
    }
    #endregion Constructors

    #region Functions public
    [Route("Token")]
    [HttpPost]
    //[AllowAnonymous]
    public async Task<ActionResult<Contact>> Token(LoginModel loginModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

        return await ContactDBService.LoginDBAsync(loginModel);
    }
    [Route("GoogleMapKeyHash")]
    [HttpGet]
    public async Task<ActionResult<string>> GoogleMapKeyHash()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

        return await ContactDBService.GetGoogleMapKeyHashAsync();
    }
    [Route("AzureStoreHash")]
    [HttpGet]
    public async Task<ActionResult<string>> AzureStoreHash()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfo(User.Identity.Name);

        return await ContactDBService.GetAzureStoreHashAsync();
    }
    #endregion Functions public

    #region Functions private
    #endregion Functions private
}

