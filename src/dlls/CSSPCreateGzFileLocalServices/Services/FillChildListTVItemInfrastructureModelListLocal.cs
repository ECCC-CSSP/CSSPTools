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
        private async Task FillChildListTVItemInfrastructureModelListLocal(List<InfrastructureModel> InfrastructureModelList, TVItem TVItem, TVTypeEnum TVType)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVType);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVType);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVType);

            List<Infrastructure> InfrastructureList = await GetInfrastructureListUnderMunicipality(TVItem);
            List<InfrastructureLanguage> InfrastructureLanguageList = await GetInfrastructureLanguageListUnderMunicipality(TVItem);
            Address InfrastructureCivicAddress = await GetInfrastructureCivicAddressListUnderMunicipality(TVItem);
            List<BoxModel> BoxModelList = await GetBoxModelListUnderMunicipality(TVItem);
            List<BoxModelLanguage> BoxModelLanguageList = await GetBoxModelLanguageListUnderMunicipality(TVItem);
            List<BoxModelResult> BoxModelResultList = await GetBoxModelResultListUnderMunicipality(TVItem);
            List<VPScenario> VPScenarioList = await GetVPScenarioListUnderMunicipality(TVItem);
            List<VPScenarioLanguage> VPScenarioLanguageList = await GetVPScenarioLanguageListUnderMunicipality(TVItem);
            List<VPAmbient> VPAmbientList = await GetVPAmbientListUnderMunicipality(TVItem);
            List<VPResult> VPResultList = await GetVPResultListUnderMunicipality(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                InfrastructureModel InfrastructureModel = new InfrastructureModel();
                InfrastructureModel.TVItemModel.TVItem = tvItem;
                InfrastructureModel.TVItemModel.TVItemLanguageList = new List<TVItemLanguage>()
                {
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault(),
                    TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault()
                };

                InfrastructureModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList)
                {
                    if (MapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();
                        InfrastructureModel.TVItemModel.MapInfoModelList.Add(MapInfoModel);
                    }
                }

                InfrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();
                InfrastructureModel.InfrastructureLanguageList = InfrastructureLanguageList.Where(c => c.InfrastructureID == InfrastructureModel.Infrastructure.InfrastructureID).ToList();
                InfrastructureModel.InfrastructureCivicAddress = InfrastructureCivicAddress;

                foreach (BoxModel BoxModel in BoxModelList)
                {
                    if (BoxModel.InfrastructureTVItemID == tvItem.TVItemID)
                    {
                        BoxModelModel BoxModelModel = new BoxModelModel();
                        BoxModelModel.BoxModel = BoxModel;
                        BoxModelModel.BoxModelLanguageList = BoxModelLanguageList.Where(c => c.BoxModelID == BoxModelModel.BoxModel.BoxModelID).ToList();
                        BoxModelModel.BoxModelResultList = BoxModelResultList.Where(c => c.BoxModelID == BoxModelModel.BoxModel.BoxModelID).ToList();

                        InfrastructureModel.BoxModelModelList.Add(BoxModelModel);
                    }
                }

                foreach (VPScenario VPScenario in VPScenarioList)
                {
                    if (VPScenario.InfrastructureTVItemID == tvItem.TVItemID)
                    {
                        VPScenarioModel VPScenarioModel = new VPScenarioModel();
                        VPScenarioModel.VPScenario = VPScenario;
                        VPScenarioModel.VPScenarioLanguageList = VPScenarioLanguageList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();
                        VPScenarioModel.VPAmbientList = VPAmbientList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();
                        VPScenarioModel.VPResultList = VPResultList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();

                        InfrastructureModel.VPScenarioModelList.Add(VPScenarioModel);
                    }
                }

                InfrastructureModelList.Add(InfrastructureModel);
            }
        }
    }
}