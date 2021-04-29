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
        private async Task FillChildListTVItemMWQMSiteModelListLocal(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType)
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
                MWQMSiteModel MWQMSiteModel = new MWQMSiteModel();
                MWQMSiteModel.TVItemModel.TVItem = tvItem;
                MWQMSiteModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                MWQMSiteModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        MWQMSiteModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                MWQMSiteModel.MWQMSite = MWQMSiteList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).FirstOrDefault();
                MWQMSiteModel.MWQMSiteStartEndDateList = MWQMSiteStartEndDateList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).ToList();

                MWQMSiteModelList.Add(MWQMSiteModel);
            }
        }
    }
}