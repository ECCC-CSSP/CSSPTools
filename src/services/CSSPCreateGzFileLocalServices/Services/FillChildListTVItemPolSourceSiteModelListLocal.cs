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
        private async Task FillChildListTVItemPolSourceSiteModelListLocal(List<PolSourceSiteModel> PolSourceSiteModelList, TVItem TVItem, TVTypeEnum TVType)
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
                PolSourceSiteModel PolSourceSiteModel = new PolSourceSiteModel();
                PolSourceSiteModel.TVItemModel.TVItem = tvItem;
                PolSourceSiteModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                PolSourceSiteModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        PolSourceSiteModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                PolSourceSiteModel.PolSourceSite = PolSourceSiteList.Where(c => c.PolSourceSiteTVItemID == tvItem.TVItemID).FirstOrDefault();

                foreach (PolSourceObservation PolSourceObservation in PolSourceObservationList.Where(c => c.PolSourceSiteID == PolSourceSiteModel.PolSourceSite.PolSourceSiteID))
                {
                    PolSourceObservationModel PolSourceObservationModel = new PolSourceObservationModel();
                    PolSourceObservationModel.PolSourceObservation = PolSourceObservation;
                    PolSourceObservationModel.PolSourceObservationIssueList = PolSourceObservationIssueList.Where(c => c.PolSourceObservationID == PolSourceObservation.PolSourceObservationID).ToList();

                    PolSourceSiteModel.PolSourceObservationModelList.Add(PolSourceObservationModel);
                }

                PolSourceSiteModel.PolSourceSiteEffectList = PolSourceSiteEffectList.Where(c => c.PolSourceSiteOrInfrastructureTVItemID == tvItem.TVItemID).ToList();
                PolSourceSiteModel.PolSourceSiteCivicAddress = PolSourceSiteCivicAddressList.Where(c => c.AddressTVItemID == tvItem.TVItemID).FirstOrDefault();

                PolSourceSiteModelList.Add(PolSourceSiteModel);
            }
        }
    }
}