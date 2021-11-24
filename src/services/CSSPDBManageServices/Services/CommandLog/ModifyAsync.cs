namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{
    public async Task<ActionResult<CommandLog>> ModifyAsync(CommandLog commandLog)
    {
        if (commandLog == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "commandLog"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        if (commandLog.CommandLogID == 0)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "CommandLogID"));
        }

        // doing AppName
        if (string.IsNullOrWhiteSpace(commandLog.AppName))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppName"));
        }
        else
        {
            if (commandLog.AppName.Length > 200)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200"));
            }
        }

        // doing CommandName
        if (string.IsNullOrWhiteSpace(commandLog.CommandName))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "CommandName"));
        }
        else
        {
            if (commandLog.CommandName.Length > 200)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200"));
            }
        }

        // doing Error
        if (!string.IsNullOrWhiteSpace(commandLog.Error))
        {
            if (commandLog.Error.Length > 10000000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Error", "10000000"));
            }
        }

        // doing Log
        if (!string.IsNullOrWhiteSpace(commandLog.Log))
        {
            if (commandLog.Log.Length > 10000000)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Log", "10000000"));
            }
        }

        if (commandLog.DateTimeUTC.Year < 1980)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        CommandLog commandLogModify = new CommandLog();

        commandLogModify = (from c in dbManage.CommandLogs
                            where c.CommandLogID == commandLog.CommandLogID
                            select c).FirstOrDefault();

        if (commandLogModify == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", commandLog.CommandLogID.ToString()));
            return await Task.FromResult(BadRequest(errRes));
        }

        commandLogModify.AppName = commandLog.AppName;
        commandLogModify.CommandName = commandLog.CommandName;
        commandLogModify.DateTimeUTC = DateTime.UtcNow;
        commandLogModify.Error = commandLog.Error;
        commandLogModify.Log = commandLog.Log;

        try
        {
            dbManage.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        return await Task.FromResult(Ok(commandLogModify));
    }
}

