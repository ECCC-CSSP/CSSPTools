namespace CSSPWebAPIs.Controllers;

public partial class AuthController : ControllerBase, IAuthController
{
    [Route("AzureStoreHash")]
    [HttpGet]
    public async Task<ActionResult<string>> AzureStoreHashAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await ContactAzureService.GetAzureStoreHashAsync();
    }
}

