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
        private void ValidateTVItemLanguage(List<TVItemLanguage> tvItemLanguageList, bool forAdd)
        {
            foreach(TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)tvItemLanguage.DBCommand);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { "DBCommand" }));
                }

                if (!forAdd)
                {
                    if ((int)tvItemLanguage.TVItemLanguageID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemLanguageID"), new[] { "TVItemLanguageID" }));
                    }

                    if ((int)tvItemLanguage.TVItemID == 0)
                    {
                        ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { "TVItemID" }));
                    }
                }

                retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvItemLanguage.Language);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), new[] { "Language" }));
                }

                if (string.IsNullOrWhiteSpace(tvItemLanguage.TVText))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), new[] { "TVText" }));
                }

                retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvItemLanguage.TranslationStatus);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" }));
                }

            }
        }
    }
}