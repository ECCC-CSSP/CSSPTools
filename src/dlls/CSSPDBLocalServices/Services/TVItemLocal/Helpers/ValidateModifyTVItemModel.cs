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
        private async Task<bool> ValidateModifyTVItemModel(TVItemLocalModel tvItemLocalModel)
        {
            ValidateTVType(tvItemLocalModel);
            ValidateModifyTVItem(tvItemLocalModel.TVItem);
            ValidateModifyTVItemLanguage(tvItemLocalModel.TVItemLanguageList);
            ValidateModifyTVItem(tvItemLocalModel.TVItemParent);

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);
        }
    }
}