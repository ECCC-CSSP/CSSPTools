namespace CSSPSyncDBsServices;

public partial class CSSPSyncDBsService : ControllerBase, ICSSPSyncDBsService
{
    public async Task<ActionResult<bool>> SyncDBsAsync()
    {
        if (CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }

        FileInfo fi = new FileInfo(@"C:\TheFile.db");
        if (!fi.Exists)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.FileNotFound_, fi.FullName));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        fi = new FileInfo(@"C:\TheFile.db");
        if (!fi.Exists)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.FileNotFound_, fi.FullName));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        return await Task.FromResult(Ok(true));
    }
}
