namespace CSSPDBLocalServices;

public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
{
    public async Task<ActionResult<AppTaskModel>> DeleteAppTaskLocalAsync(int AppTaskID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int AppTaskID) -- appTaskID: { AppTaskID }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (AppTaskID == 0)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

        #region Delete AppTaskLanguage (EN, FR)
        List<AppTaskLanguage> appTaskLanguageListToDelete = (from c in dbLocal.AppTaskLanguages
                                                             where c.AppTaskID == AppTaskID
                                                             select c).ToList();

        if (appTaskLanguageListToDelete == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLangage", "AppTaskID", AppTaskID.ToString()));
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
                                   where c.AppTaskID == AppTaskID
                                   select c).FirstOrDefault();

        if (appTaskToDelete == null)
        {
            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));
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

        AppTaskModel appTaskLocalModel = new AppTaskModel()
        {
             AppTask = appTaskToDelete,
             AppTaskLanguageList = appTaskLanguageListToDelete
        };

        return await Task.FromResult(Ok(appTaskLocalModel));
    }
}
