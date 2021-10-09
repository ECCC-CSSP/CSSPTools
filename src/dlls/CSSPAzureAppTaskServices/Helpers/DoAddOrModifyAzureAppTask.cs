/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices
{
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        private async Task<bool> DoAddOrModifyAzureAppTask(AppTaskLocalModel postAppTaskModel)
        {
            AppTask appTask = new AppTask();

            if (postAppTaskModel.AppTask.AppTaskID == 0)
            {
                appTask = (from c in db.AppTasks
                           where c.TVItemID == postAppTaskModel.AppTask.TVItemID
                           && c.TVItemID2 == postAppTaskModel.AppTask.TVItemID2
                           && c.AppTaskCommand == postAppTaskModel.AppTask.AppTaskCommand
                           select c).FirstOrDefault();

                if (appTask != null)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
                    return false;
                }

                appTask = postAppTaskModel.AppTask;

                appTask.LastUpdateDate_UTC = DateTime.UtcNow;
                appTask.LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                db.AppTasks.Add(appTask);
            }
            else
            {
                appTask = (from c in db.AppTasks
                           where c.AppTaskID == postAppTaskModel.AppTask.AppTaskID
                           select c).FirstOrDefault();

                if (appTask == null)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", postAppTaskModel.AppTask.AppTaskID.ToString()));
                    return false;
                }

                appTask.DBCommand = postAppTaskModel.AppTask.DBCommand;
                appTask.TVItemID = postAppTaskModel.AppTask.TVItemID;
                appTask.TVItemID2 = postAppTaskModel.AppTask.TVItemID2;
                appTask.AppTaskCommand = postAppTaskModel.AppTask.AppTaskCommand;
                appTask.AppTaskStatus = postAppTaskModel.AppTask.AppTaskStatus;
                appTask.PercentCompleted = postAppTaskModel.AppTask.PercentCompleted;
                appTask.Parameters = postAppTaskModel.AppTask.Parameters;
                appTask.Language = postAppTaskModel.AppTask.Language;
                appTask.StartDateTime_UTC = postAppTaskModel.AppTask.StartDateTime_UTC;
                appTask.EndDateTime_UTC = postAppTaskModel.AppTask.EndDateTime_UTC;
                appTask.EstimatedLength_second = postAppTaskModel.AppTask.EstimatedLength_second;
                appTask.RemainingTime_second = postAppTaskModel.AppTask.RemainingTime_second;
                appTask.LastUpdateDate_UTC = DateTime.UtcNow;
                appTask.LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (postAppTaskModel.AppTask.AppTaskID == 0)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
                }
                else
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "AppTask", ex.Message));
                }

                return false;
            }

            // doing AppTaskLanguage
            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                AppTaskLanguage appTaskLanguage = (from c in db.AppTaskLanguages
                                                   where c.AppTaskID == postAppTaskModel.AppTask.AppTaskID
                                                   && c.Language == lang
                                                   select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                    appTaskLanguage = postAppTaskModel.AppTaskLanguageList.Where(c => c.Language == lang).FirstOrDefault();

                    if (appTaskLanguage == null)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", lang));
                        return false;
                    }

                    appTaskLanguage.AppTaskID = appTask.AppTaskID;

                    db.AppTaskLanguages.Add(appTaskLanguage);
                }
                else
                {
                    AppTaskLanguage appTaskLanguageOfModel = postAppTaskModel.AppTaskLanguageList.Where(c => c.Language == lang).FirstOrDefault();

                    if (appTaskLanguageOfModel == null)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", lang));
                        return false;
                    }

                    appTaskLanguage.DBCommand = appTaskLanguageOfModel.DBCommand;
                    appTaskLanguage.AppTaskID = appTaskLanguageOfModel.AppTaskID;
                    appTaskLanguage.Language = appTaskLanguageOfModel.Language;
                    appTaskLanguage.StatusText = appTaskLanguageOfModel.StatusText;
                    appTaskLanguage.ErrorText = appTaskLanguageOfModel.ErrorText;
                    appTaskLanguage.TranslationStatus = TranslationStatusEnum.Translated;
                    appTaskLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                    appTaskLanguage.LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (postAppTaskModel.AppTask.AppTaskID == 0)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
                    }
                    else
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "AppTaskLanguage", ex.Message));
                    }

                    return false;
                }
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}