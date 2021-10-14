﻿/*
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
        private async Task<bool> DoMergeJsonWebAllProvinces(WebAllProvinces webAllProvinces, WebAllProvinces webAllProvincesLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllProvinces WebAllProvinces, WebAllProvinces WebAllProvincesLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllProvincesTVItemModelList(webAllProvinces, webAllProvincesLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }

        private void DoMergeJsonWebAllProvincesTVItemModelList(WebAllProvinces webAllProvinces, WebAllProvinces webAllProvincesLocal)
        {
            List<TVItemModel> tvItemModelLocalList = (from c in webAllProvincesLocal.TVItemModelList
                                                      where c.TVItem.DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                      || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                      select c).ToList();

            foreach (TVItemModel tvItemModelLocal in tvItemModelLocalList)
            {
                TVItemModel tvItemModelOriginal = webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvItemModelOriginal == null)
                {
                    webAllProvinces.TVItemModelList.Add(tvItemModelLocal);
                }
                else
                {
                    SyncTVItemModel(tvItemModelOriginal, tvItemModelLocal);
                }
            }
        }
    }
}
