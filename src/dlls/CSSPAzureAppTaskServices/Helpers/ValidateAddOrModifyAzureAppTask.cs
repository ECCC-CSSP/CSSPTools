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
        private async Task<bool> ValidateAzureAddOrModifyAppTaskModel(PostAppTaskModel postAppTaskModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostAppTaskModel postAppTaskModel)";
            CSSPLogService.FunctionLog(FunctionName);
            CSSPLogService.AppendLog($"AppTaskID: { postAppTaskModel.AppTask.AppTaskID} -- AppTaskCommand: { postAppTaskModel.AppTask.AppTaskCommand } -- TVItemID: { postAppTaskModel.AppTask.TVItemID }");

            // validating AppTask
            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postAppTaskModel.AppTask.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { "DBCommand" }));
            }

            if (postAppTaskModel.AppTask.TVItemID == 0)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { "TVItemID" }));
            }

            if (postAppTaskModel.AppTask.TVItemID2 == 0)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"), new[] { "TVItemID2" }));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)postAppTaskModel.AppTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"), new[] { "AppTaskCommand" }));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)postAppTaskModel.AppTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"), new[] { "AppTaskStatus" }));
            }

            if (postAppTaskModel.AppTask.PercentCompleted < 0)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"), new[] { "PercentCompleted" }));
            }

            //if (string.IsNullOrWhiteSpace(appTaskModel.AppTask.Parameters))
            //{
            //    CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"), new[] { "Parameters" }));
            //}

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)postAppTaskModel.AppTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { "Language" }));
            }

            if (postAppTaskModel.AppTask.StartDateTime_UTC.Year < 1980)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"), new[] { "StartDateTime_UTC" }));
            }

            if (postAppTaskModel.AppTask.EndDateTime_UTC != null)
            {
                if (((DateTime)postAppTaskModel.AppTask.EndDateTime_UTC).Year < 1980)
                {
                    CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"), new[] { "EndDateTime_UTC" }));
                }
            }

            if (postAppTaskModel.AppTaskLanguageList.Count != 2)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"), new[] { "" }));
            }

            if (!postAppTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.en).Any())
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"), new[] { "" }));
            }

            if (!postAppTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.fr).Any())
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"), new[] { "" }));
            }

            if (CSSPLogService.ValidationResultList.Count == 0)
            {
                // validating AppTaskLanguage
                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    int langID = (int)lang - 1;

                    if (postAppTaskModel.AppTask.AppTaskID == 0)
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID != 0)
                        {
                            CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"), new[] { "AppTaskLanguageID" }));
                        }
                    }

                    if (postAppTaskModel.AppTask.AppTaskID != 0)
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].AppTaskID == 0)
                        {
                            CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), new[] { "AppTaskID" }));
                        }
                    }

                    retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postAppTaskModel.AppTaskLanguageList[langID].DBCommand);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { "DBCommand" }));
                    }

                    retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)postAppTaskModel.AppTaskLanguageList[langID].Language);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { "Language" }));
                    }

                    if (!string.IsNullOrWhiteSpace(postAppTaskModel.AppTaskLanguageList[langID].StatusText))
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].StatusText.Length > 250)
                        {
                            CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250), new[] { "StatusText" }));
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(postAppTaskModel.AppTaskLanguageList[langID].ErrorText))
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].ErrorText.Length > 250)
                        {
                            CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250), new[] { "ErrorText" }));
                        }
                    }

                    retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)postAppTaskModel.AppTaskLanguageList[langID].TranslationStatus);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" }));
                    }
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            if (CSSPLogService.ValidationResultList.Count > 0) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}