/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using CSSPLogServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace CSSPDBLocalServices
{

    public partial class HelperLocalService : ControllerBase, IHelperLocalService
    {
        public void CheckTVTypeParentAndTVType(TVTypeEnum tvTypeParent, TVTypeEnum tvType)
        {
            TVTypeParentTVTypeRelation tvTypeParentTVTypeRelation = (from c in GetTVTypeParentTVTypeRelationList()
                                                                     where c.TVTypeParent == tvTypeParent
                                                                     select c).FirstOrDefault();

            if (tvTypeParentTVTypeRelation == null)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvTypeParent.ToString()) + " --- HelperLocalService.CheckTVTypeParentAndTVType");
            }
            else
            {
                if (!(from c in tvTypeParentTVTypeRelation.TVTypeChildList
                     where c == tvType
                     select c).Any())
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvTypeParent.ToString(), tvType.ToString()));
                }
            }

        }
    }
}