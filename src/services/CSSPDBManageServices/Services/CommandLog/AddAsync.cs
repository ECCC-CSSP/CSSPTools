namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{
    public async Task<ActionResult<CommandLog>> AddAsync(CommandLog commandLog)
    {
        if (commandLog == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "commandLog"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        // doing CommandLogID
        if (commandLog.CommandLogID != 0)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "CommandLogID", "0"));
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

        CommandLog commandLogAdd = new CommandLog();

        commandLogAdd = commandLog;
        int? LastIndex = (from c in dbManage.CommandLogs
                          orderby c.CommandLogID descending
                          select c.CommandLogID).FirstOrDefault() + 1;

        commandLogAdd.CommandLogID = (int)LastIndex;
        commandLogAdd.DateTimeUTC = DateTime.UtcNow;
        dbManage.CommandLogs.Add(commandLogAdd);

        try
        {
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        return await Task.FromResult(Ok(commandLogAdd));
    }
}

