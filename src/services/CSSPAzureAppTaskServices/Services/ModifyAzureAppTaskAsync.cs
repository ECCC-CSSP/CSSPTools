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
using System.Linq;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices
{
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        public async Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel appTaskLocalModel)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (appTaskLocalModel.AppTask.AppTaskID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            }

            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLocalModel.AppTask.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            }

            if (appTaskLocalModel.AppTask.TVItemID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            }

            if (appTaskLocalModel.AppTask.TVItemID2 == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTaskLocalModel.AppTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTaskLocalModel.AppTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
            }

            if (appTaskLocalModel.AppTask.PercentCompleted < 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
            }

            //if (string.IsNullOrWhiteSpace(appTaskModel.AppTask.Parameters))
            //{
            //    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"), new[] { "Parameters" }));
            //}

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLocalModel.AppTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (appTaskLocalModel.AppTask.StartDateTime_UTC.Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
            }

            if (appTaskLocalModel.AppTask.EndDateTime_UTC != null)
            {
                if (((DateTime)appTaskLocalModel.AppTask.EndDateTime_UTC).Year < 1980)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
                }
            }

            if (appTaskLocalModel.AppTaskLanguageList.Count != 2)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
            }

            if (!appTaskLocalModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.en).Any())
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
            }

            if (!appTaskLocalModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.fr).Any())
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            // validating AppTaskLanguage
            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                int langID = (int)lang - 1;

                if (appTaskLocalModel.AppTaskLanguageList[langID].AppTaskLanguageID == 0)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
                }

                if (appTaskLocalModel.AppTaskLanguageList[langID].AppTaskID == 0)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
                }

                retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLocalModel.AppTaskLanguageList[langID].DBCommand);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
                }

                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLocalModel.AppTaskLanguageList[langID].Language);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
                }

                if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[langID].StatusText))
                {
                    if (appTaskLocalModel.AppTaskLanguageList[langID].StatusText.Length > 250)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                    }
                }

                if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[langID].ErrorText))
                {
                    if (appTaskLocalModel.AppTaskLanguageList[langID].ErrorText.Length > 250)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                    }
                }

                retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLocalModel.AppTaskLanguageList[langID].TranslationStatus);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
                }
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            AppTask appTask = (from c in dbAzure.AppTasks
                               where c.AppTaskID == appTaskLocalModel.AppTask.AppTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLocalModel.AppTask.AppTaskID.ToString()));
                return await Task.FromResult(BadRequest(errRes));
            }

            appTask.DBCommand = appTaskLocalModel.AppTask.DBCommand;
            appTask.TVItemID = appTaskLocalModel.AppTask.TVItemID;
            appTask.TVItemID2 = appTaskLocalModel.AppTask.TVItemID2;
            appTask.AppTaskCommand = appTaskLocalModel.AppTask.AppTaskCommand;
            appTask.AppTaskStatus = appTaskLocalModel.AppTask.AppTaskStatus;
            appTask.PercentCompleted = appTaskLocalModel.AppTask.PercentCompleted;
            appTask.Parameters = appTaskLocalModel.AppTask.Parameters;
            appTask.Language = appTaskLocalModel.AppTask.Language;
            appTask.StartDateTime_UTC = appTaskLocalModel.AppTask.StartDateTime_UTC;
            appTask.EndDateTime_UTC = appTaskLocalModel.AppTask.EndDateTime_UTC;
            appTask.EstimatedLength_second = appTaskLocalModel.AppTask.EstimatedLength_second;
            appTask.RemainingTime_second = appTaskLocalModel.AppTask.RemainingTime_second;
            appTask.LastUpdateDate_UTC = DateTime.UtcNow;
            appTask.LastUpdateContactTVItemID = CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;

            try
            {
                dbAzure.SaveChanges();
            }
            catch (Exception ex)
            {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "AppTask", ex.Message));
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            // doing AppTaskLanguage
            foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
            {
                AppTaskLanguage appTaskLanguage = (from c in dbAzure.AppTaskLanguages
                                                   where c.AppTaskID == appTaskLocalModel.AppTask.AppTaskID
                                                   && c.Language == lang
                                                   select c).FirstOrDefault();

                if (appTaskLanguage == null)
                {
                    appTaskLanguage = appTaskLocalModel.AppTaskLanguageList.Where(c => c.Language == lang).FirstOrDefault();

                    if (appTaskLanguage == null)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", lang));
                        return await Task.FromResult(BadRequest(errRes));
                    }

                    appTaskLanguage.AppTaskID = appTask.AppTaskID;

                    dbAzure.AppTaskLanguages.Add(appTaskLanguage);
                }
                else
                {
                    AppTaskLanguage appTaskLanguageOfModel = appTaskLocalModel.AppTaskLanguageList.Where(c => c.Language == lang).FirstOrDefault();

                    if (appTaskLanguageOfModel == null)
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", lang));
                        return await Task.FromResult(BadRequest(errRes));
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
                    dbAzure.SaveChanges();
                }
                catch (Exception ex)
                {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotModify_Error_, "AppTaskLanguage", ex.Message));
                }

                if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

            return await Task.FromResult(Ok(appTaskLocalModel));
        }
    }
}