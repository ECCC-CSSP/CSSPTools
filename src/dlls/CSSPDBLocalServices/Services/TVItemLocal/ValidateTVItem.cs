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
        private void ValidateTVItem(TVItem tvItem, bool forAdd)
        {
            if (!forAdd)
            {
                if (tvItem.TVItemID == 0)
                {
                    ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), new[] { "TVItemID" }));
                }
            }

            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)tvItem.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), new[] { "DBCommand" }));
            }

            if (tvItem.TVType != TVTypeEnum.Root && tvItem.TVLevel == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"), new[] { "TVLevel" }));
            }

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"), new[] { "TVPath" }));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"), new[] { "TVType" }));
            }

            if ((int)tvItem.ParentID == 0)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"), new[] { "ParentID" }));
            }

        }
    }
}