namespace CSSPWebAPIs.Controllers;

public partial class AuthController : ControllerBase, IAuthController
{
    [Route("GoogleMapKeyHash")]
    [HttpGet]
    public async Task<ActionResult<string>> GoogleMapKeyHashAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await ContactAzureService.GetGoogleMapKeyHashAsync();
    }
}

