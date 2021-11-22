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
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private async Task<bool> MergeJsonWebAllSearch(WebAllSearch webAllSearch, WebAllSearch webAllSearchLocal)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllSearch WebAllSearch, WebAllSearch WebAllSearchLocal)";
            CSSPLogService.FunctionLog(FunctionName);

            MergeJsonWebAllSearchTVItemModelList(webAllSearch, webAllSearchLocal);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
        private void MergeJsonWebAllSearchTVItemModelList(WebAllSearch webAllSearch, WebAllSearch webAllSearchLocal)
        {
            List<TVItemModel> TVItemModelList = (from c in webAllSearchLocal.TVItemModelList
                                                 where c.TVItem.TVItemID != 0
                                                 && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                 || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                 select c).ToList();

            foreach (TVItemModel tvItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = webAllSearch.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    webAllSearch.TVItemModelList.Add(tvItemModel);
                }
                else
                {
                    SyncTVModel(TVItemModelOriginal, tvItemModel);
                }
            }
        }
    }
}
