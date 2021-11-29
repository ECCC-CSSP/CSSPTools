namespace CSSPWebAPIs.Controllers;

public partial class AzureAppTaskController : ControllerBase, IAppTaskController
{
    [Route("{AppTaskID:int}")]
    [HttpDelete]
    public async Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int AppTaskID)
    {
        CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
        await CSSPServerLoggedInService.SetLoggedInContactInfoAsync(User.Identity.Name);

        return await AzureAppTaskService.DeleteAzureAppTaskAsync(AppTaskID);
    }
}

