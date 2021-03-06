﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private void DoMergeJsonWebAllProvinces(WebAllProvinces WebAllProvinces, WebAllProvinces WebAllProvincesLocal)
        {
            List<TVItemModel> tvItemModelLocalList = (from c in WebAllProvincesLocal.TVItemModelList
                                                    where c.TVItem.DBCommand != DBCommandEnum.Original
                                                    || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                    || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

            foreach (TVItemModel tvItemModelLocal in tvItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = WebAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvItemModelOriginal == null)
                {
                    WebAllProvinces.TVItemModelList.Add(tvItemModelLocal);
                }
                else
                {
                    tvItemModelOriginal = tvItemModelLocal;
                }
            }
        }
    }
}
