namespace ManageServices;

public partial interface ICommandLogService
{
    Task<ActionResult<CommandLog>> AddAsync(CommandLog CommandLog);
    Task<ActionResult<CommandLog>> DeleteAsync(int CommandLogID);
    Task<ActionResult<List<CommandLog>>> GetTodayListAsync();
    Task<ActionResult<List<CommandLog>>> GetLastWeekListAsync();
    Task<ActionResult<List<CommandLog>>> GetLastMonthListAsync();
    Task<ActionResult<List<CommandLog>>> GetBetweenDatesListAsync(DateTime StartDate, DateTime EndDate);
    Task<ActionResult<CommandLog>> GetWithCommandLogIDAsync(int CommandLogID);
    Task<ActionResult<CommandLog>> ModifyAsync(CommandLog CommandLog);
}
