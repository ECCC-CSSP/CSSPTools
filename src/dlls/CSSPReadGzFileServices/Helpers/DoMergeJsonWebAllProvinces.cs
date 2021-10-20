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
            List<TVModel> tvModelLocalList = (from c in webAllProvincesLocal.TVModelList
                                              where c.TVItem.DBCommand != DBCommandEnum.Original
                                              || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                              || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                              select c).ToList();

            foreach (TVModel tvModelLocal in tvModelLocalList)
            {
                TVModel tvModelOriginal = webAllProvinces.TVModelList.Where(c => c.TVItem.TVItemID == tvModelLocal.TVItem.TVItemID).FirstOrDefault();
                if (tvModelOriginal == null)
                {
                    webAllProvinces.TVModelList.Add(tvModelLocal);
                }
                else
                {
                    SyncTVModel(tvModelOriginal, tvModelLocal);
                }
            }
        }
    }
}
