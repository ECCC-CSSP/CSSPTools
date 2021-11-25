namespace CSSPDBServices;

public partial interface ITVItemDBService
{
    Task<ActionResult<List<TVItem>>> GetTVItemDBStartDateListAsync(int Year, int Month, int Day);
    Task<ActionResult<TVItem>> GetTVItemDBRootAsync();
}
