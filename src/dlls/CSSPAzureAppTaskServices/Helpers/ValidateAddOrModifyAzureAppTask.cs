﻿/*
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
        private async Task<bool> ValidateAzureAddOrModifyAppTaskModel(AppTaskLocalModel postAppTaskModel)
        {
            // validating AppTask
            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postAppTaskModel.AppTask.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            }

            if (postAppTaskModel.AppTask.TVItemID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
            }

            if (postAppTaskModel.AppTask.TVItemID2 == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)postAppTaskModel.AppTask.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)postAppTaskModel.AppTask.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
            }

            if (postAppTaskModel.AppTask.PercentCompleted < 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
            }

            //if (string.IsNullOrWhiteSpace(appTaskModel.AppTask.Parameters))
            //{
            //    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Parameters"), new[] { "Parameters" }));
            //}

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)postAppTaskModel.AppTask.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
            }

            if (postAppTaskModel.AppTask.StartDateTime_UTC.Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
            }

            if (postAppTaskModel.AppTask.EndDateTime_UTC != null)
            {
                if (((DateTime)postAppTaskModel.AppTask.EndDateTime_UTC).Year < 1980)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
                }
            }

            if (postAppTaskModel.AppTaskLanguageList.Count != 2)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
            }

            if (!postAppTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.en).Any())
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
            }

            if (!postAppTaskModel.AppTaskLanguageList.Where(c => c.Language == LanguageEnum.fr).Any())
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "fr"));
            }

            if (errRes.ErrList.Count == 0)
            {
                // validating AppTaskLanguage
                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    int langID = (int)lang - 1;

                    if (postAppTaskModel.AppTask.AppTaskID == 0)
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].AppTaskLanguageID != 0)
                        {
                            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
                        }
                    }

                    if (postAppTaskModel.AppTask.AppTaskID != 0)
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].AppTaskID == 0)
                        {
                            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
                        }
                    }

                    retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)postAppTaskModel.AppTaskLanguageList[langID].DBCommand);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
                    }

                    retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)postAppTaskModel.AppTaskLanguageList[langID].Language);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
                    }

                    if (!string.IsNullOrWhiteSpace(postAppTaskModel.AppTaskLanguageList[langID].StatusText))
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].StatusText.Length > 250)
                        {
                            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(postAppTaskModel.AppTaskLanguageList[langID].ErrorText))
                    {
                        if (postAppTaskModel.AppTaskLanguageList[langID].ErrorText.Length > 250)
                        {
                            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
                        }
                    }

                    retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)postAppTaskModel.AppTaskLanguageList[langID].TranslationStatus);
                    if (!string.IsNullOrWhiteSpace(retStr))
                    {
                        errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
                    }
                }
            }

            if (errRes.ErrList.Count > 0) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}