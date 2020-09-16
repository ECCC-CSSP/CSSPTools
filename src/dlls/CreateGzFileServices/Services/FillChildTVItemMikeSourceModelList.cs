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
        private async Task FillChildTVItemMikeSourceModel(List<MikeSourceModel> MikeSourceModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);
            List<MikeSource> MikeSourceList = await GetMikeSourceListUnderMikeScenario(TVItem);
            List<MikeSourceStartEnd> MikeSourceStartEndList = await GetMikeSourceStartEndListUnderMikeScenario(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MikeSourceModel mikeSourceModel = new MikeSourceModel();
                mikeSourceModel.TVItemModel.TVItem = tvItem;
                mikeSourceModel.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                mikeSourceModel.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();

                mikeSourceModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        mikeSourceModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                mikeSourceModel.MikeSource = MikeSourceList.Where(c => c.MikeSourceTVItemID == tvItem.TVItemID).FirstOrDefault();

                mikeSourceModel.MikeSourceStartEndList = MikeSourceStartEndList.Where(c => c.MikeSourceID == mikeSourceModel.MikeSource.MikeSourceID).ToList();

                MikeSourceModelList.Add(mikeSourceModel);
            }
        }
    }
}