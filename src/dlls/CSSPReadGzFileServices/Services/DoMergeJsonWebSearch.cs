/*
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
        private void DoMergeJsonWebAllSearch(WebAllSearch WebAllSearch, WebAllSearch WebAllSearchLocal)
        {
            List<TVItemModel> TVItemModelList = (from c in WebAllSearchLocal.TVItemModelList
                                                               where c.TVItem.DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                               || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                               select c).ToList();

            foreach (TVItemModel TVItemModel in TVItemModelList)
            {
                TVItemModel TVItemModelOriginal = WebAllSearch.TVItemModelList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
                if (TVItemModelOriginal == null)
                {
                    WebAllSearch.TVItemModelList.Add(TVItemModelOriginal);
                }
                else
                {
                    TVItemModelOriginal = TVItemModel;
                }
            }
        }
    }
}
