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
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        private async Task<bool> ValidateAddAppTaskLocal(AppTaskLocalModel appTaskModel)
        {
            // validating AppTask
            if (appTaskModel.AppTask.AppTaskID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
            }

            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskModel.AppTask.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            }

            if (appTaskModel.AppTask.TVItemID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            }

            if (appTaskModel.AppTask.TVItemID2 == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTaskModel.AppTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTaskModel.AppTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
            }

            if (appTaskModel.AppTask.PercentCompleted < 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
            }

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
            }

            if (appTaskModel.AppTaskLanguageList.Count != 2)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
            }

            if (!appTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.en).Any())
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
            }

            if (!appTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.fr).Any())
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
            }

            if (CSSPLogService.ErrRes.ErrList.Count == 0)
            {
                // validating AppTaskLanguage
                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    int langID = (int)lang - 1;

                    if (appTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID != 0)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
                    }

                    retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)appTaskModel.AppTaskLanguageList[langID].DBCommand);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
                    }

                    if (appTaskModel.AppTaskLanguageList[langID].AppTaskID != 0)
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
                    }

                    retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskModel.AppTaskLanguageList[langID].Language);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
                    }

                    if (!string.IsNullOrWhiteSpace(appTaskModel.AppTaskLanguageList[langID].StatusText))
                    {
                        if (appTaskModel.AppTaskLanguageList[langID].StatusText.Length > 250)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(appTaskModel.AppTaskLanguageList[langID].ErrorText))
                    {
                        if (appTaskModel.AppTaskLanguageList[langID].ErrorText.Length > 250)
                        {
                            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                        }
                    }

                    retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskModel.AppTaskLanguageList[langID].TranslationStatus);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
                    }
                }
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}