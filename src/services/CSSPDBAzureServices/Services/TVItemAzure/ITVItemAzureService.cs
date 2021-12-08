namespace CSSPDBAzureServices;

public partial interface ITVItemAzureService
{
    Task<ActionResult<List<TVItem>>> GetTVItemAzureStartDateListAsync(int Year, int Month, int Day);
    Task<ActionResult<TVItem>> GetTVItemAzureRootAsync();
}
