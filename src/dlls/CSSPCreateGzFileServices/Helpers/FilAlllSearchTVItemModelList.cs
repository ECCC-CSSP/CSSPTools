/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> FillAllSearchTVItemModelList(List<TVModel> TVSearchList)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TVItemModel> TVItemSearchList)";
            CSSPLogService.FunctionLog(FunctionName);

            List<TVItem> TVItemList = await GetSearchableTVItem();
            List<TVItemLanguage> TVItemLanguageList = await GetSearchableTVItemLanguage();

            foreach (TVItem tvItem in TVItemList)
            {
                TVModel tvModel = new TVModel();
                tvModel.TVItem = tvItem;
                tvModel.TVItemLanguageList = (from c in TVItemLanguageList
                                                  where c.TVItemID == tvItem.TVItemID
                                                  orderby c.Language
                                                  select c).ToList();

                TVSearchList.Add(tvModel);
            }

            TVSearchList = (from c in TVSearchList
                                orderby c.TVItem.TVLevel
                                select c).ToList();

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}