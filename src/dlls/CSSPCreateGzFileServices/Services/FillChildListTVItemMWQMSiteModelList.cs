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
        private async Task FillChildListTVItemMWQMSiteModelList(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<MWQMSite> MWQMSiteList = await GetMWQMSiteListFromSubsector(TVItem);
            List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList = await GetMWQMSiteStartEndDateListFromSubsector(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                MWQMSiteModel mwqmSiteModel = new MWQMSiteModel();
                mwqmSiteModel.TVItemModel.TVItem = tvItem;
                mwqmSiteModel.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                mwqmSiteModel.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();

                mwqmSiteModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        mwqmSiteModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                mwqmSiteModel.MWQMSite = MWQMSiteList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).FirstOrDefault();
                mwqmSiteModel.MWQMSiteStartEndDateList = MWQMSiteStartEndDateList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).ToList();

                MWQMSiteModelList.Add(mwqmSiteModel);
            }
        }
    }
}