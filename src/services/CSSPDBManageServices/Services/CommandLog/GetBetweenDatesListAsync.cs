namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{

    public async Task<ActionResult<List<CommandLog>>> GetBetweenDatesListAsync(DateTime StartDate, DateTime EndDate)
    {
        if (StartDate.Year < 1980)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate", "1980"));
        }

        if (EndDate.Year < 1980)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDate", "1980"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        if (StartDate >= EndDate)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate", "EndDate"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        List<CommandLog> CommandLogList = (from c in dbManage.CommandLogs.AsNoTracking()
                                           where c.DateTimeUTC >= StartDate
                                           && c.DateTimeUTC <= EndDate
                                           orderby c.CommandLogID
                                           select c).ToList();

        return await Task.FromResult(Ok(CommandLogList));
    }
}

