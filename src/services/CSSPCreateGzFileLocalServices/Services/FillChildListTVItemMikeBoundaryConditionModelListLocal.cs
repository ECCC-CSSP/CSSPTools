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
        private async Task FillChildListTVItemMikeBoundaryConditionModelListLocal(List<MikeBoundaryConditionModel> MikeBoundaryConditionModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);
            List<MikeBoundaryCondition> MikeBoundaryConditionList = await GetMikeBoundaryConditionListUnderMikeScenario(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MikeBoundaryConditionModel MikeBoundaryConditionModel = new MikeBoundaryConditionModel();
                MikeBoundaryConditionModel.TVItemModel.TVItem = tvItem;
                MikeBoundaryConditionModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                MikeBoundaryConditionModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        MikeBoundaryConditionModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                MikeBoundaryConditionModel.MikeBoundaryConditionList = MikeBoundaryConditionList.Where(c => c.MikeBoundaryConditionTVItemID == tvItem.TVItemID && c.TVType == TVType).ToList();

                MikeBoundaryConditionModelList.Add(MikeBoundaryConditionModel);
            }
        }
    }
}