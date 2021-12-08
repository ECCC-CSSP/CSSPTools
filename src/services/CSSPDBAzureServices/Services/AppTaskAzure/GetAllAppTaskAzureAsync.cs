namespace CSSPDBAzureServices;
public partial class AppTaskAzureService : ControllerBase, IAppTaskAzureService
{
    public async Task<ActionResult<List<AppTaskModel>>> GetAllAppTaskAzureAsync()
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        List<AppTaskModel> appTaskModelList = new List<AppTaskModel>();

        List<AppTask> appTaskList = (from c in dbAzure.AppTasks select c).ToList();
        List<AppTaskLanguage> appTaskLanguageList = (from c in dbAzure.AppTaskLanguages select c).ToList();

        foreach (AppTask appTask in appTaskList)
        {
            appTaskModelList.Add(new AppTaskModel()
            {
                AppTask = appTask,
                AppTaskLanguageList = (from c in appTaskLanguageList
                                       where c.AppTaskID == appTask.AppTaskID
                                       select c).ToList()
            });
        }

        return await Task.FromResult(Ok(appTaskModelList));
    }
}
