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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillAllSearchTVItemModelList(List<TVItemModel> TVItemSearchList)
        {
            List<TVItem> TVItemList = await GetSearchableTVItem();
            List<TVItemLanguage> TVItemLanguageList = await GetSearchableTVItemLanguage();

            foreach (TVItem tvItem in TVItemList)
            {
                TVItemModel tvItemModel = new TVItemModel();
                tvItemModel.TVItem = tvItem;
                tvItemModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                TVItemSearchList.Add(tvItemModel);
            }

            TVItemSearchList = (from c in TVItemSearchList
                                orderby c.TVItem.TVLevel
                                select c).ToList();
        }
    }
}