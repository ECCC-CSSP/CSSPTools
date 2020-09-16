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
        private async Task FillChildTVItemInfrastructureModel(List<InfrastructureModel> InfrastructureModelList, TVItem TVItem, TVTypeEnum TVType)
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
                InfrastructureModel infrastructureModel = new InfrastructureModel();
                infrastructureModel.TVItemModel.TVItem = tvItem;
                infrastructureModel.TVItemModel.TVItemLanguageEN = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
                infrastructureModel.TVItemModel.TVItemLanguageFR = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();

                infrastructureModel.TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo mapInfo in MapInfoList)
                {
                    if (mapInfo.TVItemID == tvItem.TVItemID)
                    {
                        MapInfoModel mapInfoModel = new MapInfoModel();
                        mapInfoModel.MapInfo = mapInfo;
                        mapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == mapInfo.MapInfoID).Select(c => c).ToList();
                        infrastructureModel.TVItemModel.MapInfoModelList.Add(mapInfoModel);
                    }
                }

                infrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();
                infrastructureModel.InfrastructureLanguageList = InfrastructureLanguageList.Where(c => c.InfrastructureID == infrastructureModel.Infrastructure.InfrastructureID).ToList();
                infrastructureModel.InfrastructureCivicAddress = InfrastructureCivicAddress;

                foreach (BoxModel boxModel in BoxModelList)
                {
                    if (boxModel.InfrastructureTVItemID == tvItem.TVItemID)
                    {
                        BoxModelModel boxModelModel = new BoxModelModel();
                        boxModelModel.BoxModel = boxModel;
                        boxModelModel.BoxModelLanguageList = BoxModelLanguageList.Where(c => c.BoxModelID == boxModelModel.BoxModel.BoxModelID).ToList();
                        boxModelModel.BoxModelResultList = BoxModelResultList.Where(c => c.BoxModelID == boxModelModel.BoxModel.BoxModelID).ToList();

                        infrastructureModel.BoxModelModelList.Add(boxModelModel);
                    }
                }

                foreach (VPScenario vpScenario in VPScenarioList)
                {
                    if (vpScenario.InfrastructureTVItemID == tvItem.TVItemID)
                    {
                        VPScenarioModel vpScenarioModel = new VPScenarioModel();
                        vpScenarioModel.VPScenario = vpScenario;
                        vpScenarioModel.VPScenarioLanguageList = VPScenarioLanguageList.Where(c => c.VPScenarioID == vpScenarioModel.VPScenario.VPScenarioID).ToList();
                        vpScenarioModel.VPAmbientList = VPAmbientList.Where(c => c.VPScenarioID == vpScenarioModel.VPScenario.VPScenarioID).ToList();
                        vpScenarioModel.VPResultList = VPResultList.Where(c => c.VPScenarioID == vpScenarioModel.VPScenario.VPScenarioID).ToList();

                        infrastructureModel.VPScenarioModelList.Add(vpScenarioModel);
                    }
                }

                InfrastructureModelList.Add(infrastructureModel);
            }
        }
    }
}