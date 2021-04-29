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

namespace CSSPAzureAppTaskServices
{
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        private bool DoAddOrModifyAzureAppTask(PostAppTaskModel postAppTaskModel)
        {
            ValidationResults = new List<ValidationResult>();

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
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"), new[] { "" }));
                    return false;
                }

                appTask = postAppTaskModel.AppTask;

                appTask.LastUpdateDate_UTC = DateTime.UtcNow;
                appTask.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                db.AppTasks.Add(appTask);
            }
            else
            {
                appTask = (from c in db.AppTasks
                           where c.AppTaskID == postAppTaskModel.AppTask.AppTaskID
                           select c).FirstOrDefault();

                if (appTask == null)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", postAppTaskModel.AppTask.AppTaskID.ToString()), new[] { "" }));
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
                appTask.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (postAppTaskModel.AppTask.AppTaskID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message), new[] { "" }));
                }
                else
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "AppTask", ex.Message), new[] { "" }));
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
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", lang), new[] { "" }));
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
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", lang), new[] { "" }));
                        return false;
                    }

                    appTaskLanguage.DBCommand = appTaskLanguageOfModel.DBCommand;
                    appTaskLanguage.AppTaskID = appTaskLanguageOfModel.AppTaskID;
                    appTaskLanguage.Language = appTaskLanguageOfModel.Language;
                    appTaskLanguage.StatusText = appTaskLanguageOfModel.StatusText;
                    appTaskLanguage.ErrorText = appTaskLanguageOfModel.ErrorText;
                    appTaskLanguage.TranslationStatus = TranslationStatusEnum.Translated;
                    appTaskLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                    appTaskLanguage.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (postAppTaskModel.AppTask.AppTaskID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message), new[] { "" }));
                    }
                    else
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "AppTaskLanguage", ex.Message), new[] { "" }));
                    }

                    return false;
                }
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}