﻿/*
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
        private async Task FillInfrastructureModelList(List<InfrastructureModel> InfrastructureModelList, TVItem TVItem)
        {
            List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);
            List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.Infrastructure);

            List<Infrastructure> InfrastructureList = await GetInfrastructureListUnderMunicipality(TVItem);
            List<InfrastructureLanguage> InfrastructureLanguageList = await GetInfrastructureLanguageListUnderMunicipality(TVItem);
            List<Address> InfrastructureCivicAddressList = await GetInfrastructureCivicAddressListUnderMunicipality(TVItem);
            List<BoxModel> BoxModelList = await GetBoxModelListUnderMunicipality(TVItem);
            List<BoxModelLanguage> BoxModelLanguageList = await GetBoxModelLanguageListUnderMunicipality(TVItem);
            List<BoxModelResult> BoxModelResultList = await GetBoxModelResultListUnderMunicipality(TVItem);
            List<VPScenario> VPScenarioList = await GetVPScenarioListUnderMunicipality(TVItem);
            List<VPScenarioLanguage> VPScenarioLanguageList = await GetVPScenarioLanguageListUnderMunicipality(TVItem);
            List<VPAmbient> VPAmbientList = await GetVPAmbientListUnderMunicipality(TVItem);
            List<VPResult> VPResultList = await GetVPResultListUnderMunicipality(TVItem);

            List<TVItem> TVItemFileList = await GetTVItemAllChildrenListWithTVItemID(TVItem, TVTypeEnum.File);
            List<TVItemLanguage> TVItemLanguageFileList = await GetTVItemLanguageAllChildrenListWithTVItemID(TVItem, TVTypeEnum.File);

            List<TVFile> TVFileList = await GetAllTVFileListUnder(TVItem);
            List<TVFileLanguage> TVFileLanguageList = await GetAllTVFileLanguageListUnder(TVItem);

            foreach (TVItem tvItem in TVItemList)
            {
                InfrastructureModel InfrastructureModel = new InfrastructureModel();

                TVItemMapModel tvItemMapModel = new TVItemMapModel();
                tvItemMapModel.TVItem = tvItem;
                tvItemMapModel.TVItemLanguageList = TVItemLanguageList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    tvItemMapModel.MapInfoModelList.Add(MapInfoModel);
                }

                InfrastructureModel.TVItemMapModel = tvItemMapModel;

                foreach (TVItem tvItemFile in TVItemFileList.Where(c => c.ParentID == tvItem.TVItemID))
                {
                    TVFileModel tvFileModel = new TVFileModel();
                    tvFileModel.TVItem = tvItemFile;
                    tvFileModel.TVItemLanguageList = TVItemLanguageFileList.Where(c => c.TVItemID == tvItemFile.TVItemID).ToList();
                    tvFileModel.TVFile = TVFileList.Where(c => c.TVFileTVItemID == tvItemFile.TVItemID).FirstOrDefault();
                    tvFileModel.TVFileLanguageList = TVFileLanguageList.Where(c => c.TVFileID == tvFileModel.TVFile.TVFileID).ToList();

                    InfrastructureModel.TVFileModelList.Add(tvFileModel);

                }

                InfrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();
                InfrastructureModel.InfrastructureLanguageList = InfrastructureLanguageList.Where(c => c.InfrastructureID == InfrastructureModel.Infrastructure.InfrastructureID).ToList();
                InfrastructureModel.InfrastructureCivicAddress = InfrastructureCivicAddressList.Where(c => c.AddressTVItemID == InfrastructureModel.Infrastructure.CivicAddressTVItemID).FirstOrDefault();

                foreach (BoxModel BoxModel in BoxModelList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID))
                {
                    BoxModelModel BoxModelModel = new BoxModelModel();
                    BoxModelModel.BoxModel = BoxModel;
                    BoxModelModel.BoxModelLanguageList = BoxModelLanguageList.Where(c => c.BoxModelID == BoxModelModel.BoxModel.BoxModelID).ToList();
                    BoxModelModel.BoxModelResultList = BoxModelResultList.Where(c => c.BoxModelID == BoxModelModel.BoxModel.BoxModelID).ToList();

                    InfrastructureModel.BoxModelModelList.Add(BoxModelModel);
                }

                foreach (VPScenario VPScenario in VPScenarioList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID))
                {
                    VPScenarioModel VPScenarioModel = new VPScenarioModel();
                    VPScenarioModel.VPScenario = VPScenario;
                    VPScenarioModel.VPScenarioLanguageList = VPScenarioLanguageList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();
                    VPScenarioModel.VPAmbientList = VPAmbientList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();
                    VPScenarioModel.VPResultList = VPResultList.Where(c => c.VPScenarioID == VPScenarioModel.VPScenario.VPScenarioID).ToList();

                    InfrastructureModel.VPScenarioModelList.Add(VPScenarioModel);
                }

                InfrastructureModelList.Add(InfrastructureModel);
            }
        }
    }
}