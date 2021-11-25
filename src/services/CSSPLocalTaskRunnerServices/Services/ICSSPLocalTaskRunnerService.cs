namespace CSSPLocalTaskRunnerServices;
public partial interface ICSSPLocalTaskRunnerService
{
    Task<ActionResult<bool>> JunkAsync();
}
