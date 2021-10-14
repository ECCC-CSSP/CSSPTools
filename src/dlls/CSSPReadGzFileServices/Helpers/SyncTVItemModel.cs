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

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void SyncTVItemModel(TVItemModel tvItemModelOriginal, TVItemModel tvItemModelLocal)
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
                if (tvItemModelLocal.MapInfoModelList != null)
                {
                    tvItemModelOriginal.MapInfoModelList = tvItemModelLocal.MapInfoModelList;
                }
                if (tvItemModelLocal.TVItemStatList != null)
                {
                    tvItemModelOriginal.TVItemStatList = tvItemModelLocal.TVItemStatList;
                }
            }
        }
    }
}
