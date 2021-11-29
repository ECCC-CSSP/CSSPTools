namespace CSSPWebAPIs.Controllers;

public partial class AzureAppTaskController : ControllerBase, IAppTaskController
{
    [HttpPut]
    public async Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel appTaskModel)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AzureAppTaskService.AddAzureAppTaskAsync(appTaskModel);
    }
}

