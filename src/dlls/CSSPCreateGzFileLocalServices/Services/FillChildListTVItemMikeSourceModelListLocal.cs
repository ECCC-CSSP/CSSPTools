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
        private async Task FillChildListTVItemMikeSourceModelListLocal(List<MikeSourceModel> MikeSourceModelList, TVItem TVItem, TVTypeEnum TVType)
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
                MikeSourceModel MikeSourceModel = new MikeSourceModel();
                MikeSourceModel.TVItemModel.TVItem = tvItem;
                MikeSourceModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                MikeSourceModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        MikeSourceModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                MikeSourceModel.MikeSource = MikeSourceList.Where(c => c.MikeSourceTVItemID == tvItem.TVItemID).FirstOrDefault();

                MikeSourceModel.MikeSourceStartEndList = MikeSourceStartEndList.Where(c => c.MikeSourceID == MikeSourceModel.MikeSource.MikeSourceID).ToList();

                MikeSourceModelList.Add(MikeSourceModel);
            }
        }
    }
}