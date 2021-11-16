/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPLocalLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CSSPHelperModels;
using CSSPLogServices;
using System.Reflection;
using System.Security.Cryptography;

namespace CSSPDBLocalServices
{
    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        public async Task<ActionResult<AppTaskLocalModel>> ModifyAppTaskLocalAsync(AppTaskLocalModel appTaskLocalModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostAppTaskModel appTaskModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check AppTaskLocalModel
            if (appTaskLocalModel.AppTask.AppTaskID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLocalModel.AppTask.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (appTaskLocalModel.AppTask.TVItemID == 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            //}

            //if (appTaskLocalModel.AppTask.TVItemID2 == 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
            //}

            string retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTaskLocalModel.AppTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTaskLocalModel.AppTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
            }

            //if (appTaskLocalModel.AppTask.PercentCompleted < 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
            //}

            //if (string.IsNullOrWhiteSpace(appTaskModel.AppTask.Parameters))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"));
            //}

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLocalModel.AppTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (appTaskLocalModel.AppTask.StartDateTime_UTC.Year < 1980)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
            }

            if (appTaskLocalModel.AppTask.EndDateTime_UTC != null)
            {
                if (((DateTime)appTaskLocalModel.AppTask.EndDateTime_UTC).Year < 1980)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
                }

                if (appTaskLocalModel.AppTask.StartDateTime_UTC > appTaskLocalModel.AppTask.EndDateTime_UTC)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "StartDateTime_UTC"));
                }
            }

            if (appTaskLocalModel.AppTaskLanguageList.Count != 2)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageList.Count", "2"));
            }

            //if (!appTaskLocalModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.en).Any())
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
            //}

            //if (!appTaskLocalModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.fr).Any())
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
            //}
            #endregion Check AppTaskLocalModel

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Modify AppTaskLanguage EN
            if (appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
            }

            if (appTaskLocalModel.AppTaskLanguageList[0].AppTaskID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
            }

            //retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLocalModel.AppTaskLanguageList[0].DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLocalModel.AppTaskLanguageList[0].Language);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            //}

            if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[0].StatusText))
            {
                if (appTaskLocalModel.AppTaskLanguageList[0].StatusText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                }
            }

            if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[0].ErrorText))
            {
                if (appTaskLocalModel.AppTaskLanguageList[0].ErrorText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                }
            }

            //retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLocalModel.AppTaskLanguageList[0].TranslationStatus);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
            //}
            #endregion Modify AppTaskLanguage EN

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Modify AppTaskLanguage FR
            if (appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskLanguageID"));
            }

            if (appTaskLocalModel.AppTaskLanguageList[1].AppTaskID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
            }

            //retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskLocalModel.AppTaskLanguageList[1].DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLocalModel.AppTaskLanguageList[1].Language);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            //}

            if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[1].StatusText))
            {
                if (appTaskLocalModel.AppTaskLanguageList[1].StatusText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                }
            }

            if (!string.IsNullOrWhiteSpace(appTaskLocalModel.AppTaskLanguageList[1].ErrorText))
            {
                if (appTaskLocalModel.AppTaskLanguageList[1].ErrorText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                }
            }

            //retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLocalModel.AppTaskLanguageList[1].TranslationStatus);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
            //}
            #endregion Modify AppTaskLanguage FR

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Modify AppTask
            AppTask appTask = (from c in dbLocal.AppTasks
                               where c.AppTaskID == appTaskLocalModel.AppTask.AppTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLocalModel.AppTask.AppTaskID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            try
            {
                appTask.DBCommand = DBCommandEnum.Modified;
                appTask.AppTaskCommand = appTaskLocalModel.AppTask.AppTaskCommand;
                appTask.AppTaskStatus = appTaskLocalModel.AppTask.AppTaskStatus;
                appTask.StartDateTime_UTC = appTaskLocalModel.AppTask.StartDateTime_UTC;
                appTask.EndDateTime_UTC = appTaskLocalModel.AppTask.EndDateTime_UTC;
                appTask.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                appTask.LastUpdateDate_UTC = DateTime.UtcNow;
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
            }
            #endregion Modify AppTask

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Modify AppTaskLanguage EN
            AppTaskLanguage appTaskLanguageEN = (from c in dbLocal.AppTaskLanguages
                                               where c.AppTaskLanguageID == appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID
                                               select c).FirstOrDefault();

            if (appTaskLanguageEN == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLocalModel.AppTaskLanguageList[0].AppTaskLanguageID.ToString()));            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            try
            {
                appTaskLanguageEN.DBCommand = DBCommandEnum.Modified;
                appTaskLanguageEN.StatusText = appTaskLocalModel.AppTaskLanguageList[0].StatusText;
                appTaskLanguageEN.ErrorText = appTaskLocalModel.AppTaskLanguageList[0].ErrorText;
                appTaskLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
                appTaskLanguageEN.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                appTaskLanguageEN.LastUpdateDate_UTC = DateTime.UtcNow;
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
            }
            #endregion Modify AppTaskLanguage EN

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Modify AppTaskLanguage FR
            AppTaskLanguage appTaskLanguageFR = (from c in dbLocal.AppTaskLanguages
                                               where c.AppTaskLanguageID == appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID
                                               select c).FirstOrDefault();

            if (appTaskLanguageFR == null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLocalModel.AppTaskLanguageList[1].AppTaskLanguageID.ToString()));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            try
            {
                appTaskLanguageFR.DBCommand = DBCommandEnum.Modified;
                appTaskLanguageFR.StatusText = appTaskLocalModel.AppTaskLanguageList[1].StatusText;
                appTaskLanguageFR.ErrorText = appTaskLocalModel.AppTaskLanguageList[1].ErrorText;
                appTaskLanguageFR.TranslationStatus = TranslationStatusEnum.Translated;
                appTaskLanguageFR.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID;
                appTaskLanguageFR.LastUpdateDate_UTC = DateTime.UtcNow;
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
            }
            #endregion Modify AppTaskLanguage FR


            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(appTaskLocalModel));
        }
    }
}