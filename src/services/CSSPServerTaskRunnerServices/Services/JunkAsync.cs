namespace CSSPServerTaskRunnerServices;

public partial class ServerTaskRunnerService : ControllerBase, IServerTaskRunnerService
{
    /*
     * this server task runner should run all the functions to run server task which are all the task that need to be
     * running on the server. like MIKE scenarios, Import of users local db to Azure db, recreating gz files, 
     * recalculating TVItemStats, potentially importing precip data, hydrometric data and a few other things
     */
    public async Task<ActionResult<bool>> JunkAsync()
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }

        FileInfo fi = new FileInfo(@"C:\junk.txt");

        if (!fi.Exists)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.FileNotFound_, fi.FullName));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        fi = new FileInfo(@"C:\junk.txt");

        if (!fi.Exists)
        {
            CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.FileNotFound_, fi.FullName));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        return await Task.FromResult(Ok(true));
    }
}
