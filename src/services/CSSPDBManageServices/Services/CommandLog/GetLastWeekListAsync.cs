namespace ManageServices;

public partial class CommandLogService : ControllerBase, ICommandLogService
{
    public async Task<ActionResult<List<CommandLog>>> GetLastWeekListAsync()
    {
        DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        DateTime StartDate = EndDate.AddDays(-7);

        return await GetBetweenDatesListAsync(StartDate, EndDate);
    }
}

