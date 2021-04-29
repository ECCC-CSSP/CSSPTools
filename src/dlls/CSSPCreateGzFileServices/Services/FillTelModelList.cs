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
        private async Task FillTelModelList(List<TelModel> TelModelList, TVItem TVItem)
        {
            List<Tel> TelList = await GetAllTel();
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Tel);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Tel);

            foreach (TVItem tvItem in TVItemList)
            {
                TelModelList.Add(new TelModel()
                {
                    TVItem = tvItem,
                    TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList(),
                    Tel = TelList.Where(c => c.TelTVItemID == tvItem.TVItemID).FirstOrDefault(),
                });
            }
        }
    }
}