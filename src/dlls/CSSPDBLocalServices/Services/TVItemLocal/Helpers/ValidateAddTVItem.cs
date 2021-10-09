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

    public partial class TVItemLocalService : ControllerBase, ITVItemLocalService
    {
        private void ValidateAddTVItem(TVItem tvItem)
        {
            if (tvItem.TVItemID != 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemID", "0"));
            }

            string retStr = enums.EnumTypeOK(typeof(DBCommandEnum), (int?)tvItem.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
            }

            if (tvItem.TVType != TVTypeEnum.Root && tvItem.TVLevel == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"));
            }

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"));
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"));
            }

            if ((int)tvItem.ParentID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"));
            }

        }
    }
}