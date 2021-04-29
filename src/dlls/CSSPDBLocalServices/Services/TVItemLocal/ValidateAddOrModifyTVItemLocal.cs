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
        private bool ValidatePostTVItemModel(PostTVItemModel postTVItemModel, bool forAdd)
        {
            ValidationResults = new List<ValidationResult>();

            if (ValidateTVType(postTVItemModel))
            {

                ValidateTVItem(postTVItemModel.TVItem, forAdd);
                ValidateTVItemLanguage(postTVItemModel.TVItemLanguageList, forAdd);
                ValidateTVItem(postTVItemModel.TVItemParent, false);
                //if (postTVItemModel.TVItemGrandParent != null)
                //{
                //    ValidateTVItem(postTVItemModel.TVItemGrandParent, false);
                //}
            }

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}