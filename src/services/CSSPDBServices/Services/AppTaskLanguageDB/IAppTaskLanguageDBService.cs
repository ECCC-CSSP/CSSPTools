namespace CSSPDBServices;

public partial interface IAppTaskLanguageDBService
{
    Task<ActionResult<bool>> DeleteAppTaskLanguageDBAsync(int AppTaskLanguageID);
    Task<ActionResult<List<AppTaskLanguage>>> GetAppTaskLanguageDBListAsync(int skip = 0, int take = 100);
    Task<ActionResult<AppTaskLanguage>> GetAppTaskLanguageDBWithAppTaskLanguageIDAsync(int AppTaskLanguageID);
    Task<ActionResult<AppTaskLanguage>> AddAppTaskLanguageDBAsync(AppTaskLanguage apptasklanguage);
    Task<ActionResult<AppTaskLanguage>> ModifyAppTaskLanguageDBAsync(AppTaskLanguage apptasklanguage);
}
