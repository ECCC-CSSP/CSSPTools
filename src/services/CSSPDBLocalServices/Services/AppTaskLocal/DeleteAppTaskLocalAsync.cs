namespace CSSPDBLocalServices;

public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
{
    public async Task<ActionResult<AppTaskLocalModel>> DeleteAppTaskLocalAsync(AppTaskLocalModel appTaskLocalModel)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int appTaskID) -- appTaskID: {appTaskLocalModel.AppTask.AppTaskID}";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        #region Check AppTaskModel
        if (appTaskLocalModel.AppTask.AppTaskID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }
        #endregion Check AppTaskModel

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Delete AppTaskLanguage (EN, FR)
        List<AppTaskLanguage> appTaskLanguageListToDelete = (from c in dbLocal.AppTaskLanguages
                                                             where c.AppTaskID == appTaskLocalModel.AppTask.AppTaskID
                                                             select c).ToList();

        if (appTaskLanguageListToDelete == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLangage", "AppTaskID", appTaskLocalModel.AppTask.AppTaskID.ToString()));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        try
        {
            dbLocal.AppTaskLanguages.RemoveRange(appTaskLanguageListToDelete);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTaskLanguageList", ex.Message));
        }
        #endregion Delete AppTaskLanguage (EN, FR)

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Delete AppTask
        AppTask appTaskToDelete = (from c in dbLocal.AppTasks
                                   where c.AppTaskID == appTaskLocalModel.AppTask.AppTaskID
                                   select c).FirstOrDefault();

        if (appTaskToDelete == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLocalModel.AppTask.AppTaskID.ToString()));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        try
        {
            dbLocal.AppTasks.Remove(appTaskToDelete);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTask", ex.Message));
        }
        #endregion Delete AppTask

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(appTaskLocalModel));
    }
}
