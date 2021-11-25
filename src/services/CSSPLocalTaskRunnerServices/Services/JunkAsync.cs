using System.IO;

namespace CSSPLocalTaskRunnerServices;

public partial class LocalTaskRunnerService : ControllerBase, ICSSPLocalTaskRunnerService
{
    /*
     * This local task runner should hold all the functions to run the local task that can be run locally
     * creation of reports, html, csv, Excel, kml, etc... almost everything other than running MIKE scenarios
     */
    public async Task<ActionResult<bool>> JunkAsync()
    {
        if (CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
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
