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
        private async Task<bool> DoMergeJsonWebAllSearch(WebAllSearch webAllSearch, WebAllSearch webAllSearchLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllSearch WebAllSearch, WebAllSearch WebAllSearchLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            DoMergeJsonWebAllSearchTVItemModelList(webAllSearch, webAllSearchLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void DoMergeJsonWebAllSearchTVItemModelList(WebAllSearch webAllSearch, WebAllSearch webAllSearchLocal)
        {
            List<TVModel> TVModelList = (from c in webAllSearchLocal.TVModelList
                                         where c.TVItem.TVItemID != 0
                                         && (c.TVItem.DBCommand != DBCommandEnum.Original
                                         || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                         || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                         select c).ToList();

            foreach (TVModel tvModel in TVModelList)
            {
                TVModel TVModelOriginal = webAllSearch.TVModelList.Where(c => c.TVItem.TVItemID == tvModel.TVItem.TVItemID).FirstOrDefault();
                if (TVModelOriginal == null)
                {
                    webAllSearch.TVModelList.Add(tvModel);
                }
                else
                {
                    SyncTVModel(TVModelOriginal, tvModel);
                }
            }
        }
    }
}
