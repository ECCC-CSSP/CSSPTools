namespace CSSPWebAPIs.Controllers;

public partial class AzureAppTaskController : ControllerBase, IAppTaskController
{
    [HttpGet]
    public async Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTaskAsync()
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AzureAppTaskService.GetAllAzureAppTaskAsync();
    }
}

