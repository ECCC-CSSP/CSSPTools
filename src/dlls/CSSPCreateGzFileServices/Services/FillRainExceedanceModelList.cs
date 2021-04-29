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
        private async Task FillRainExceedanceModelList(List<RainExceedanceModel> RainExceedanceModelList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.RainExceedance);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.RainExceedance);

            List<RainExceedance> RainExceedanceList = await GetRainExceedanceUnderCountry(TVItem);
            List<RainExceedanceClimateSite> RainExceedanceClimateSiteList = await GetRainExceedanceClimateSiteUnderCountry(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                RainExceedanceModelList.Add(new RainExceedanceModel()
                {
                    TVItem = tvItem,
                    TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList(),
                    RainExceedance = RainExceedanceList.Where(c => c.RainExceedanceTVItemID == tvItem.TVItemID).FirstOrDefault(),
                    RainExceedanceClimateSiteList = RainExceedanceClimateSiteList.Where(c => c.RainExceedanceTVItemID == tvItem.TVItemID).ToList(),
                });
            }
        }
    }
}