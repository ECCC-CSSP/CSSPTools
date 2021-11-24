namespace CSSPAzureAppTaskServices;
public partial interface IAzureAppTaskService
{
    Task<ActionResult<AppTaskLocalModel>> AddAzureAppTaskAsync(AppTaskLocalModel postAppTaskModel);
    Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int appTaskID);
    Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTaskAsync();
    Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel postAppTaskModel);
}
