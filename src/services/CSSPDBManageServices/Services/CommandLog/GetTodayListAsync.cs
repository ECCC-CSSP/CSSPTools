namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{
    public async Task<ActionResult<List<CommandLog>>> GetTodayListAsync()
    {
        DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        DateTime StartDate = EndDate.AddDays(-1);

        return await GetBetweenDatesListAsync(StartDate, EndDate);
    }
}

