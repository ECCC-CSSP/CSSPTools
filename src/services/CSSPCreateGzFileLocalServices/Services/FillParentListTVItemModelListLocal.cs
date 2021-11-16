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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillParentListTVItemModelListLocal(List<TVItemModel> TVItemParentList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemParentListWithTVItemID(TVItem);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageParentListWithTVItemID(TVItem);
            List<TVItemStat> TVItemStatList = await GetTVItemStatParentListWithTVItemID(TVItem);
            List<MapInfo> MapInfoList = await GetMapInfoParentListWithTVItemID(TVItem);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointParentListWithTVItemID(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                TVItemModel webBase = new TVItemModel();
                webBase.TVItemModel.TVItem = tvItem;
                webBase.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                webBase.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        webBase.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                TVItemParentList.Add(webBase);
            }
        }
    }
}