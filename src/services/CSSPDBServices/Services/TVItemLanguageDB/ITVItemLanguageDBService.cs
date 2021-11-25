namespace CSSPDBServices;

public partial interface ITVItemLanguageDBService
{
    Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageDBStartDateListAsync(int Year, int Month, int Day);
}
