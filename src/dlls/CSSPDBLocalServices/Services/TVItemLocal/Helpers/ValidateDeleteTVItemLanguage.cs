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

namespace CSSPDBLocalServices
{

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private void ValidateDeleteTVItemLanguage(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)tvItemLanguage.DBCommand);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
                }

                if ((int)tvItemLanguage.TVItemLanguageID == 0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemLanguageID"));
                }

                if ((int)tvItemLanguage.TVItemID == 0)
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
                }

                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvItemLanguage.Language);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
                }

                if (string.IsNullOrWhiteSpace(tvItemLanguage.TVText))
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"));
                }

                retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvItemLanguage.TranslationStatus);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
                }

            }
        }
    }
}