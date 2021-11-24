namespace CSSPAzureAppTaskServices;

public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
{
    public async Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int appTaskID)
    {
        if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
        {
            errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
            return await Task.FromResult(Unauthorized(errRes));
        }

        if (appTaskID == 0)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        List<AppTaskLanguage> appTaskLanguageList = (from c in dbAzure.AppTaskLanguages
                                                     where c.AppTaskID == appTaskID
                                                     select c).ToList();

        AppTask appTask = (from c in dbAzure.AppTasks
                           where c.AppTaskID == appTaskID
                           select c).FirstOrDefault();

        if (appTask == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskID.ToString()));
            return await Task.FromResult(BadRequest(errRes));
        }
        else
        {
            dbAzure.AppTasks.Remove(appTask);

            try
            {
                dbAzure.SaveChanges();
            }
            catch (Exception ex)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTask", ex.Message));
                return await Task.FromResult(BadRequest(errRes));
            }

        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        AppTaskLocalModel appTaskLocalModel = new AppTaskLocalModel()
        {
            AppTask = appTask,
            AppTaskLanguageList = appTaskLanguageList,
        };

        return await Task.FromResult(Ok(appTaskLocalModel));
    }
}
