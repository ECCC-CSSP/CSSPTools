/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        private void SyncTVModel(TVItemModel tvItemModelOriginal, TVItemModel tvItemModelLocal)
        {
            if (tvItemModelLocal != null)
            {
                if (tvItemModelLocal.TVItem != null)
                {
                    tvItemModelOriginal.TVItem = tvItemModelLocal.TVItem;
                }
                if (tvItemModelLocal.TVItemLanguageList != null)
                {
                    tvItemModelOriginal.TVItemLanguageList = tvItemModelLocal.TVItemLanguageList;
                }
            }
        }
    }
}
