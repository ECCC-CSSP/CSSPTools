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
            List<TVItemModel> TVItemModelList = (from c in webAllSearchLocal.TVItemModelList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVItemModel TVItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = webAllSearch.TVItemModelList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    webAllSearch.TVItemModelList.Add(TVItemModel);
                }
                else
                {
                    SyncTVItemModel(TVItemModelOriginal, TVItemModel);
                }
            }
        }
    }
}
