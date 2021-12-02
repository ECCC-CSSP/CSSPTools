namespace CSSPDBLocalServices;

public partial interface IAppTaskLocalService
{
    Task<ActionResult<AppTaskLocalModel>> AddAppTaskLocalAsync(AppTaskLocalModel appTaskModel);
    Task<ActionResult<AppTaskLocalModel>> DeleteAppTaskLocalAsync(int AppTaskID);
    Task<ActionResult<List<AppTaskLocalModel>>> GetAllAppTaskLocalAsync();
    Task<ActionResult<AppTaskLocalModel>> ModifyAppTaskLocalAsync(AppTaskLocalModel appTaskModel);
}
