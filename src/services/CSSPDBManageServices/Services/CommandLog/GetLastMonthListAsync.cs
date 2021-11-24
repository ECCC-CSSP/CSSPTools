namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{
    public async Task<ActionResult<List<CommandLog>>> GetLastMonthListAsync()
    {
        DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day - 7, 0, 0, 0);
        DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        return await GetBetweenDatesListAsync(StartDate, EndDate);
    }
}

