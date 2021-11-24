namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{
    public async Task<ActionResult<CommandLog>> GetWithCommandLogIDAsync(int CommandLogID)
    {
        if (CommandLogID == 0)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "CommandLogID"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        CommandLog commandLog = (from c in dbManage.CommandLogs.AsNoTracking()
                                 where c.CommandLogID == CommandLogID
                                 select c).FirstOrDefault();

        if (commandLog == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString()));
            return await Task.FromResult(BadRequest(errRes));
        }

        return await Task.FromResult(Ok(commandLog));
    }
}

