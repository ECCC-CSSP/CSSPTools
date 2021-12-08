namespace CSSPWebAPIs.Controllers;

public partial class AppTaskAzureController : ControllerBase, IAppTaskAzureController
{
    [HttpGet]
    public async Task<ActionResult<List<AppTaskModel>>> GetAllAppTaskAzureAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AppTaskAzureService.GetAllAppTaskAzureAsync();
    }
}

