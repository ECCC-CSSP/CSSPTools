namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public async Task<ActionResult> Save()
    {
        int nextCommandLogID = (from c in dbManage.CommandLogs
                                orderby c.CommandLogID descending
                                select c.CommandLogID).FirstOrDefault() + 1;

        if (string.IsNullOrWhiteSpace(CSSPAppName))
        {
            Console.WriteLine($"\r{String.Format(CSSPCultureServicesRes._IsRequired, "CSSPAppName")}");

            FunctionCount = 0;

            return await Task.FromResult(Ok(false));
        }

        if (string.IsNullOrWhiteSpace(CSSPCommandName))
        {
            Console.WriteLine($"\r{String.Format(CSSPCultureServicesRes._IsRequired, "CSSPCommandName")}");

            FunctionCount = 0;

            return await Task.FromResult(Ok(false));

        }

        CommandLog commandLog = new CommandLog()
        {
            CommandLogID = nextCommandLogID,
            AppName = CSSPAppName.ToString(),
            CommandName = CSSPCommandName.ToString(),
            Error = sbError.ToString(),
            Log = sbLog.ToString(),
            DateTimeUTC = DateTime.UtcNow,
        };

        try
        {
            commandLog.Error = sbError.ToString();
            commandLog.Log = sbLog.ToString();
            dbManage.CommandLogs.Add(commandLog);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            string AppAndCommandName = $"AppName: {CSSPAppName } - CommandName: {CSSPCommandName}";
            Console.WriteLine($"\r{String.Format(CSSPCultureServicesRes.CouldNotAddCommandLog_Error_, AppAndCommandName, ex.Message)}");

            FunctionCount = 0;

            return await Task.FromResult(Ok(false));
        }

        FunctionCount = 0;

        return await Task.FromResult(Ok(true));
    }
}

