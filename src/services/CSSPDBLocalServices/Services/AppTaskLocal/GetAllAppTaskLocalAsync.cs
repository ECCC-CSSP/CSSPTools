namespace CSSPDBLocalServices;

public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
{
    public async Task<ActionResult<List<AppTaskLocalModel>>> GetAllAppTaskLocalAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        List<AppTaskLocalModel> appTaskModelList = new List<AppTaskLocalModel>();

        List<AppTask> appTaskList = (from c in dbLocal.AppTasks select c).ToList();
        List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocal.AppTaskLanguages select c).ToList();

        foreach (AppTask appTask in appTaskList)
        {
            appTaskModelList.Add(new AppTaskLocalModel()
            {
                AppTask = appTask,
                AppTaskLanguageList = (from c in appTaskLanguageList
                                       where c.AppTaskID == appTask.AppTaskID
                                       select c).ToList()
            });
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(appTaskModelList));
    }
}
