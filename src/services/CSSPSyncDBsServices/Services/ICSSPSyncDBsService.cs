namespace CSSPSyncDBsServices;

public partial interface ICSSPSyncDBsService
{
    Task<ActionResult<bool>> SyncDBsAsync();
}
