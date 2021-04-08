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

namespace CSSPAzureAppTaskModelServices
{
    public partial class AzureAppTaskModelService : ControllerBase, IAzureAppTaskModelService
    {
        private bool DoAddOrModifyAzureAppTaskModel(AppTaskModel appTaskModel)
        {
            ValidationResults = new List<ValidationResult>();

            AppTask appTask = new AppTask();

            if (appTaskModel.AppTask.AppTaskID == 0)
            {
                appTask = (from c in db.AppTasks
                                   where c.TVItemID == appTaskModel.AppTask.TVItemID
                                   && c.TVItemID2 == appTaskModel.AppTask.TVItemID2
                                   && c.AppTaskCommand == appTaskModel.AppTask.AppTaskCommand
                                   select c).FirstOrDefault();

                if (appTask != null)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"), new[] { "" }));
                    return false;
                }

                appTask = appTaskModel.AppTask;

                appTask.LastUpdateDate_UTC = DateTime.UtcNow;
                appTask.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

                db.AppTasks.Add(appTask);
            }
            else
            {
                appTask = (from c in db.AppTasks
                           where c.AppTaskID == appTaskModel.AppTask.AppTaskID
                           select c).FirstOrDefault();

                if (appTask == null)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskModel.AppTask.AppTaskID.ToString()), new[] { "" }));
                    return false;
                }

                appTask.DBCommand = appTaskModel.AppTask.DBCommand;
                appTask.TVItemID = appTaskModel.AppTask.TVItemID;
                appTask.TVItemID2 = appTaskModel.AppTask.TVItemID2;
                appTask.AppTaskCommand = appTaskModel.AppTask.AppTaskCommand;
                appTask.AppTaskStatus = appTaskModel.AppTask.AppTaskStatus;
                appTask.PercentCompleted = appTaskModel.AppTask.PercentCompleted;
                appTask.Parameters = appTaskModel.AppTask.Parameters;
                appTask.Language = appTaskModel.AppTask.Language;
                appTask.StartDateTime_UTC = appTaskModel.AppTask.StartDateTime_UTC;
                appTask.EndDateTime_UTC = appTaskModel.AppTask.EndDateTime_UTC;
                appTask.EstimatedLength_second = appTaskModel.AppTask.EstimatedLength_second;
                appTask.RemainingTime_second = appTaskModel.AppTask.RemainingTime_second;
                appTask.LastUpdateDate_UTC = DateTime.UtcNow;
                appTask.LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if (appTaskModel.AppTask.AppTaskID == 0)
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
                                                   where c.AppTaskID == appTaskModel.AppTask.AppTaskID
                                                   && c.Language == lang
                                                   select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                    appTaskLanguage = appTaskModel.AppTaskLanguageList.Where(c => c.Language == lang).FirstOrDefault();

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
                    AppTaskLanguage appTaskLanguageOfModel = appTaskModel.AppTaskLanguageList.Where(c => c.Language == lang).FirstOrDefault();

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
                    if (appTaskModel.AppTask.AppTaskID == 0)
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