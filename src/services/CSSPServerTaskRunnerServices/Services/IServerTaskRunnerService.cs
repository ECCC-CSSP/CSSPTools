namespace CSSPServerTaskRunnerServices;

public partial interface IServerTaskRunnerService
{
    Task<ActionResult<bool>> JunkAsync();
}
