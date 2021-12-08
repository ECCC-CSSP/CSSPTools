namespace CSSPSyncDBsServices;

public partial class CSSPSyncDBsService : ControllerBase, ICSSPSyncDBsService
{
    public async Task<ActionResult<bool>> SyncDBsAsync()
    {
        if (CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }

        return await Task.FromResult(Ok(true));
    }
}
