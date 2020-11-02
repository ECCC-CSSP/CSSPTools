/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillChildListTVItemMikeBoundaryConditionModelList(List<MikeBoundaryConditionModel> MikeBoundaryConditionModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);
            List<MikeBoundaryCondition> MikeBoundaryConditionList = await GetMikeBoundaryConditionListUnderMikeScenario(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MikeBoundaryConditionModel mikeBoundaryConditionModel = new MikeBoundaryConditionModel();
                mikeBoundaryConditionModel.TVItemModel.TVItem = tvItem;
                mikeBoundaryConditionModel.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                mikeBoundaryConditionModel.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();

                mikeBoundaryConditionModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        mikeBoundaryConditionModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                mikeBoundaryConditionModel.MikeBoundaryConditionList = MikeBoundaryConditionList.Where(c => c.MikeBoundaryConditionTVItemID == tvItem.TVItemID && c.TVType == TVType).ToList();

                MikeBoundaryConditionModelList.Add(mikeBoundaryConditionModel);
            }
        }
    }
}