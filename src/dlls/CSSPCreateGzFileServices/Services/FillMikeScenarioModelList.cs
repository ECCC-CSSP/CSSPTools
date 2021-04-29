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
        private async Task FillMikeScenarioModelList(TVItemStatMapModel TVItemStatMapModel, List<TVItemStatModel> TVItemStatParentList, List<MikeScenarioModel> MIKEScenarioModelList, TVItem TVItem)
        {
            List<TVItem> TVItemListMikeScenario = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeScenario);
            List<TVItemLanguage> TVItemLanguageListMikeScenario = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeScenario);
            List<TVItemStat> TVItemStatListMikeScenario = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeScenario);
            List<MapInfo> MapInfoListMikeScenario = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeScenario);
            List<MapInfoPoint> MapInfoPointListMikeScenario = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeScenario);
            List<TVItem> TVItemFileListAll = await GetTVItemListFileUnderMunicipality(TVItem);
            List<TVItemLanguage> TVItemLanguageFileListAll = await GetTVItemLanguageListFileUnderMunicipality(TVItem);

            List<TVFile> TVFileListAll = await GetAllTVFileListUnder(TVItem);
            List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnder(TVItem);

            List<TVItem> TVItemListMikeSource = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);
            List<TVItemLanguage> TVItemLanguageListMikeSource = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);
            List<TVItemStat> TVItemStatListMikeSource = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);
            List<MapInfo> MapInfoListMikeSource = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);
            List<MapInfoPoint> MapInfoPointListMikeSource = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeSource);

            List<TVItem> TVItemListMikeBoundary = await GetTVItemChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
            List<TVItemLanguage> TVItemLanguageListMikeBoundary = await GetTVItemLanguageChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
            List<TVItemStat> TVItemStatListMikeBoundary = await GetTVItemStatChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
            List<MapInfo> MapInfoListMikeBoundary = await GetMapInfoChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
            List<MapInfoPoint> MapInfoPointListMikeBoundary = await GetMapInfoPointChildrenListWithTVItemID(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);

            List<MikeSource> MikeSourceList = await GetMikeSourceListUnderMunicipality(TVItem);
            List<MikeSourceStartEnd> MikeSourceStartEndList = await GetMikeSourceStartEndListUnderMunicipality(TVItem);

            List<MikeBoundaryCondition> MikeBoundaryConditionList = await GetMikeBoundaryConditionListUnderMunicipality(TVItem);

            List<MikeScenario> MIKEScenarioList = await GetMikeScenarioListUnderMunicipality(TVItem);

            foreach (TVItem tvItemMikeScenario in TVItemListMikeScenario)
            {
                MikeScenarioModel MikeScenarioModel = new MikeScenarioModel();

                MikeScenarioModel.MikeScenario = MIKEScenarioList.Where(c => c.MikeScenarioTVItemID == tvItemMikeScenario.TVItemID).FirstOrDefault();

                MikeScenarioModel.TVItemStatModelParentList.AddRange(TVItemStatParentList);

                TVItemStatMapModel tvItemStatMapModel = new TVItemStatMapModel();

                // doing MikeScenarioModel.TVItemStatMapModel and MikeScenarioModel.TVItemStatParentList
                foreach (TVItem tvItem in TVItemListMikeScenario.Where(c => c.TVItemID == tvItemMikeScenario.TVItemID))
                {
                    TVItemStatModel tvItemStatModel = new TVItemStatModel();
                    tvItemStatModel.TVItem = tvItem;
                    tvItemStatModel.TVItemLanguageList = TVItemLanguageListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                    tvItemStatModel.TVItemStatList = TVItemStatListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    tvItemStatMapModel.TVItem = tvItem;
                    tvItemStatMapModel.TVItemLanguageList = TVItemLanguageListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                    tvItemStatMapModel.TVItemStatList = TVItemStatListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    MikeScenarioModel.TVItemStatModelParentList.Add(tvItemStatModel);
                }

                foreach (MapInfo MapInfo in MapInfoListMikeScenario.Where(c => c.TVItemID == tvItemMikeScenario.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointListMikeScenario.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    tvItemStatMapModel.MapInfoModelList.Add(MapInfoModel);
                }

                MikeScenarioModel.TVItemStatMapModel = tvItemStatMapModel;

                // doing MikeScenarioModel.TVItemFileList
                foreach (TVItem tvItem in TVItemFileListAll.Where(c => c.ParentID == tvItemMikeScenario.TVItemID))
                {
                    TVFileModel tvFileModel = new TVFileModel();
                    tvFileModel.TVItem = tvItem;
                    tvFileModel.TVItemLanguageList = TVItemLanguageFileListAll.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
                    tvFileModel.TVFile = TVFileListAll.Where(c => c.TVFileTVItemID == tvItem.TVItemID).FirstOrDefault();
                    tvFileModel.TVFileLanguageList = TVFileLanguageListAll.Where(c => c.TVFileID == tvFileModel.TVFile.TVFileID).ToList();

                    MikeScenarioModel.TVFileModelList.Add(tvFileModel);
                }

                // doing MikeScenarioModel.MikeSourceModelList
                foreach (TVItem tvItem in TVItemListMikeSource.Where(c => c.ParentID == tvItemMikeScenario.TVItemID))
                {
                    MikeSourceModel mikeSourceModel = new MikeSourceModel();

                    TVItemMapModel tvItemMapModelMikeSource = new TVItemMapModel();
                    tvItemMapModelMikeSource.TVItem = tvItem;
                    tvItemMapModelMikeSource.TVItemLanguageList = TVItemLanguageListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    foreach (MapInfo MapInfo in MapInfoListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID))
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointListMikeSource.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                        tvItemMapModelMikeSource.MapInfoModelList.Add(MapInfoModel);
                    }

                    mikeSourceModel.TVItemMapModel = tvItemMapModelMikeSource;
                    mikeSourceModel.MikeSource = MikeSourceList.Where(c => c.MikeSourceTVItemID == tvItem.TVItemID).FirstOrDefault();
                    mikeSourceModel.MikeSourceStartEndList = MikeSourceStartEndList.Where(c => c.MikeSourceID == mikeSourceModel.MikeSource.MikeSourceID).ToList();

                    MikeScenarioModel.MikeSourceModelList.Add(mikeSourceModel);
                }

                // doing MikeScenarioModel.MikeBoundaryConditionModelList
                foreach (TVItem tvItem in TVItemListMikeBoundary.Where(c => c.ParentID == tvItemMikeScenario.TVItemID))
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModel = new MikeBoundaryConditionModel();

                    TVItemMapModel tvItemMapModelBC = new TVItemMapModel();
                    tvItemMapModelBC.TVItem = tvItem;
                    tvItemMapModelBC.TVItemLanguageList = TVItemLanguageListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    foreach (MapInfo MapInfo in MapInfoListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID))
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointListMikeSource.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                        tvItemMapModelBC.MapInfoModelList.Add(MapInfoModel);
                    }

                    mikeBoundaryConditionModel.TVItemMapModel = tvItemMapModelBC;
                    mikeBoundaryConditionModel.MikeBoundaryCondition = MikeBoundaryConditionList.Where(c => c.MikeBoundaryConditionTVItemID == tvItem.TVItemID).FirstOrDefault();

                    MikeScenarioModel.MikeBoundaryConditionModelList.Add(mikeBoundaryConditionModel);
                }

                MIKEScenarioModelList.Add(MikeScenarioModel);
            }
        }
    }
}