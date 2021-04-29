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
        private async Task FillTVItemModelAndParentTVItemModelList(TVItemStatMapModel TVItemStatMapModel, List<TVItemStatModel> TVItemParentList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemParentListWithTVItem(TVItem);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageParentListWithTVItem(TVItem);
            List<TVItemStat> TVItemStatList = await GetTVItemStatParentListWithTVItem(TVItem);
            List<MapInfo> MapInfoList = await GetMapInfoParentListWithTVItem(TVItem);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointParentListWithTVItem(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                TVItemStatModel tvItemStatModel = new TVItemStatModel();
                tvItemStatModel.TVItem = tvItem;
                tvItemStatModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                tvItemStatModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                TVItemParentList.Add(tvItemStatModel);
            }

            TVItemStatMapModel tvItemStatMapModel = new TVItemStatMapModel();

            TVItemStatMapModel.TVItem = TVItemParentList[TVItemParentList.Count - 1].TVItem;
            TVItemStatMapModel.TVItemLanguageList = TVItemParentList[TVItemParentList.Count - 1].TVItemLanguageList;
            TVItemStatMapModel.TVItemStatList = TVItemParentList[TVItemParentList.Count - 1].TVItemStatList;

            foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == TVItem.TVItemID))
            {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                TVItemStatMapModel.MapInfoModelList.Add(MapInfoModel);
            }
        }
    }
}