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
        private async Task FillChildListTVItemMWQMRunModelList(List<MWQMRunModel> MWQMRunModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<MWQMRun> MWQMRunList = await GetMWQMRunListFromSubsector(TVItem);
            List<MWQMRunLanguage> MWQMRunLanguageList = await GetMWQMRunLanguageListFromSubsector(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MWQMRunModel mwqmRunModel = new MWQMRunModel();
                mwqmRunModel.TVItemModel.TVItem = tvItem;
                mwqmRunModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                mwqmRunModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        mwqmRunModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                mwqmRunModel.MWQMRun = MWQMRunList.Where(c => c.MWQMRunTVItemID == tvItem.TVItemID).FirstOrDefault();
                mwqmRunModel.MWQMRunLanguageList = MWQMRunLanguageList.Where(c => c.MWQMRunID == mwqmRunModel.MWQMRun.MWQMRunID).ToList();

                MWQMRunModelList.Add(mwqmRunModel);
            }
        }
    }
}