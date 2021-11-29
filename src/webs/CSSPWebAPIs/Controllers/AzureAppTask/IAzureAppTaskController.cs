namespace CSSPWebAPIs.Controllers;

public partial interface IAppTaskController
{
    Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTaskAsync();
    Task<ActionResult<AppTaskLocalModel>> AddAzureAppTaskAsync(AppTaskLocalModel appTaskModel);
    Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int AppTaskID);
    Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel appTaskModel);
}
