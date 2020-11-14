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
        private async Task FillParentListTVItemModelList(List<WebBase> TVItemParentList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemParentListWithTVItemID(TVItem);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageParentListWithTVItemID(TVItem);
            List<TVItemStat> TVItemStatList = await GetTVItemStatParentListWithTVItemID(TVItem);
            List<MapInfo> MapInfoList = await GetMapInfoParentListWithTVItemID(TVItem);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointParentListWithTVItemID(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                WebBase webBase = new WebBase();
                webBase.TVItemModel.TVItem = tvItem;
                webBase.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                webBase.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        webBase.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                TVItemParentList.Add(webBase);
            }
        }
    }
}