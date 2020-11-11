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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillChildListTVItemPolSourceSiteModelList(List<PolSourceSiteModel> PolSourceSiteModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<PolSourceSite> PolSourceSiteList = await GetPolSourceSiteListFromSubsector(TVItem);
            List<PolSourceObservation> PolSourceObservationList = await GetPolSourceObservationListFromSubsector(TVItem);
            List<PolSourceObservationIssue> PolSourceObservationIssueList = await GetPolSourceObservationIssueListFromSubsector(TVItem);
            List<PolSourceSiteEffect> PolSourceSiteEffectList = await GetPolSourceSiteEffectListFromSubsector(TVItem);
            List<Address> PolSourceSiteCivicAddressList = await GetPolSourceSiteAddressListFromSubsector(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                PolSourceSiteModel polSourceSiteModel = new PolSourceSiteModel();
                polSourceSiteModel.TVItemModel.TVItem = tvItem;
                polSourceSiteModel.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                polSourceSiteModel.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();

                polSourceSiteModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        polSourceSiteModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                polSourceSiteModel.PolSourceSite = PolSourceSiteList.Where(c => c.PolSourceSiteTVItemID == tvItem.TVItemID).FirstOrDefault();

                foreach (PolSourceObservation polSourceObservation in PolSourceObservationList.Where(c => c.PolSourceSiteID == polSourceSiteModel.PolSourceSite.PolSourceSiteID))
                {
                    PolSourceObservationModel polSourceObservationModel = new PolSourceObservationModel();
                    polSourceObservationModel.PolSourceObservation = polSourceObservation;
                    polSourceObservationModel.PolSourceObservationIssueList = PolSourceObservationIssueList.Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).ToList();

                    polSourceSiteModel.PolSourceObservationModelList.Add(polSourceObservationModel);
                }

                polSourceSiteModel.PolSourceSiteEffectList = PolSourceSiteEffectList.Where(c => c.PolSourceSiteOrInfrastructureTVItemID == tvItem.TVItemID).ToList();
                polSourceSiteModel.PolSourceSiteCivicAddress = PolSourceSiteCivicAddressList.Where(c => c.AddressTVItemID == tvItem.TVItemID).FirstOrDefault();

                PolSourceSiteModelList.Add(polSourceSiteModel);
            }
        }
    }
}