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
        public async Task<ActionResult<AppTaskLocalModel>> AddAppTaskLocal(AppTaskLocalModel appTaskModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostAppTaskModel appTaskModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            #region Check AppTaskModel.AppTask
            if (appTaskModel.AppTask.AppTaskID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
            }

            //string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskModel.AppTask.DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            if (appTaskModel.AppTask.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            }

            if (appTaskModel.AppTask.TVItemID2 == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
            }

            string retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTaskModel.AppTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTaskModel.AppTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
            }

            //if (appTaskModel.AppTask.PercentCompleted < 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
            //}

            //if (string.IsNullOrWhiteSpace(appTaskModel.AppTask.Parameters))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"));
            //}

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskModel.AppTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (appTaskModel.AppTask.StartDateTime_UTC.Year < 1980)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
            }

            if (appTaskModel.AppTask.EndDateTime_UTC != null)
            {
                if (((DateTime)appTaskModel.AppTask.EndDateTime_UTC).Year < 1980)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
                }

                if (appTaskModel.AppTask.StartDateTime_UTC > appTaskModel.AppTask.EndDateTime_UTC)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, "EndDateTime_UTC", "StartDateTime_UTC"));
                }
            }

            if (appTaskModel.AppTaskLanguageList.Count != 2)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageList.Count", "2"));
            }

            //if (!appTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.en).Any())
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
            //}

            //if (!appTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.fr).Any())
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
            //}
            #endregion Check AppTaskModel.AppTask

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Check AppTaskModel.AppTaskLanguage EN
            if (appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
            }

            //retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskModel.AppTaskLanguageList[0].DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (appTaskModel.AppTaskLanguageList[0].AppTaskID != 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
            //}

            //retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskModel.AppTaskLanguageList[0].Language);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            //}

            if (!string.IsNullOrWhiteSpace(appTaskModel.AppTaskLanguageList[0].StatusText))
            {
                if (appTaskModel.AppTaskLanguageList[0].StatusText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                }
            }

            if (!string.IsNullOrWhiteSpace(appTaskModel.AppTaskLanguageList[0].ErrorText))
            {
                if (appTaskModel.AppTaskLanguageList[0].ErrorText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                }
            }

            //retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskModel.AppTaskLanguageList[0].TranslationStatus);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
            //}
            #endregion Check AppTaskModel.AppTaskLanguage EN

            #region Check AppTaskModel.AppTaskLanguage FR
            if (appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
            }

            //retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskModel.AppTaskLanguageList[1].DBCommand);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            //}

            //if (appTaskModel.AppTaskLanguageList[1].AppTaskID != 0)
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
            //}

            //retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskModel.AppTaskLanguageList[1].Language);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            //}

            if (!string.IsNullOrWhiteSpace(appTaskModel.AppTaskLanguageList[1].StatusText))
            {
                if (appTaskModel.AppTaskLanguageList[1].StatusText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                }
            }

            if (!string.IsNullOrWhiteSpace(appTaskModel.AppTaskLanguageList[1].ErrorText))
            {
                if (appTaskModel.AppTaskLanguageList[1].ErrorText.Length > 250)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                }
            }

            //retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskModel.AppTaskLanguageList[1].TranslationStatus);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
            //}
            #endregion Check AppTaskModel.AppTaskLanguage FR

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Adding AppTask
            AppTask appTask = (from c in dbLocal.AppTasks
                               where c.TVItemID == appTaskModel.AppTask.TVItemID
                               && c.TVItemID2 == appTaskModel.AppTask.TVItemID2
                               && c.AppTaskCommand == appTaskModel.AppTask.AppTaskCommand
                               select c).FirstOrDefault();

            if (appTask != null)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            int AppTaskIDNew = (from c in dbLocal.AppTasks
                                where c.AppTaskID < 0
                                orderby c.AppTaskID ascending
                                select c.AppTaskID).FirstOrDefault() - 1;

            appTaskModel.AppTask.AppTaskID = AppTaskIDNew;
            appTaskModel.AppTask.DBCommand = DBCommandEnum.Created;
            appTaskModel.AppTask.StartDateTime_UTC = DateTime.UtcNow;
            appTaskModel.AppTask.LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            appTaskModel.AppTask.LastUpdateDate_UTC = DateTime.UtcNow;

            try
            {
                dbLocal.AppTasks.Add(appTaskModel.AppTask);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTask", ex.Message));
            }
            #endregion Adding AppTask

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Adding AppTaskLanguage EN
            int AppTaskLanguageIDNewEN = (from c in dbLocal.AppTaskLanguages
                                          where c.AppTaskLanguageID < 0
                                          orderby c.AppTaskLanguageID ascending
                                          select c.AppTaskLanguageID).FirstOrDefault() - 1;

            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = AppTaskLanguageIDNewEN;
            appTaskModel.AppTaskLanguageList[0].DBCommand = DBCommandEnum.Created;
            appTaskModel.AppTaskLanguageList[0].AppTaskID = appTaskModel.AppTask.AppTaskID;
            appTaskModel.AppTaskLanguageList[0].Language = LanguageEnum.en;
            appTaskModel.AppTaskLanguageList[0].TranslationStatus = TranslationStatusEnum.Translated;
            appTaskModel.AppTaskLanguageList[0].LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            appTaskModel.AppTaskLanguageList[0].LastUpdateDate_UTC = DateTime.UtcNow;

            try
            {
                dbLocal.AppTaskLanguages.Add(appTaskModel.AppTaskLanguageList[0]);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
            }
            #endregion Adding AppTaskLanguage EN

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            #region Adding AppTaskLanguage FR
            int AppTaskLanguageIDNewFR = (from c in dbLocal.AppTaskLanguages
                                          where c.AppTaskLanguageID < 0
                                          orderby c.AppTaskLanguageID ascending
                                          select c.AppTaskLanguageID).FirstOrDefault() - 1;

            appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = AppTaskLanguageIDNewFR;
            appTaskModel.AppTaskLanguageList[1].DBCommand = DBCommandEnum.Created;
            appTaskModel.AppTaskLanguageList[1].AppTaskID = appTaskModel.AppTask.AppTaskID;
            appTaskModel.AppTaskLanguageList[1].Language = LanguageEnum.fr;
            appTaskModel.AppTaskLanguageList[1].TranslationStatus = TranslationStatusEnum.Translated;
            appTaskModel.AppTaskLanguageList[1].LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.LastUpdateContactTVItemID;
            appTaskModel.AppTaskLanguageList[1].LastUpdateDate_UTC = DateTime.UtcNow;

            try
            {
                dbLocal.AppTaskLanguages.Add(appTaskModel.AppTaskLanguageList[1]);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AppTaskLanguage", ex.Message));
            }
            #endregion Adding AppTaskLanguage FR

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(appTaskModel));
        }
    }
}