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
using System.Text.RegularExpressions;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillMikeScenarioModelList(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, List<MikeScenarioModel> MIKEScenarioModelList, TVItem TVItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, List<MikeScenarioModel> MIKEScenarioModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
            CSSPLogService.FunctionLog(FunctionName);

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

                MikeScenarioModel.TVItemModelParentList.AddRange(TVItemParentList);

                TVItemModel tvItemModel = new TVItemModel();

                // doing MikeScenarioModel.TVItemModel and MikeScenarioModel.TVItemParentList
                foreach (TVItem tvItem in TVItemListMikeScenario.Where(c => c.TVItemID == tvItemMikeScenario.TVItemID))
                {
                    tvItemModel.TVItem = tvItem;
                    tvItemModel.TVItemLanguageList = TVItemLanguageListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    foreach (TVItemLanguage tvItemLanguage in tvItemModel.TVItemLanguageList)
                    {
                        tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                        RegexOptions options = RegexOptions.None;
                        Regex regex = new Regex("[ ]{2,}", options);
                        tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                    }

                    tvItemModel.TVItemStatList = TVItemStatListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    MikeScenarioModel.TVItemModelParentList.Add(tvItemModel);
                }

                foreach (MapInfo MapInfo in MapInfoListMikeScenario.Where(c => c.TVItemID == tvItemMikeScenario.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointListMikeScenario.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    tvItemModel.MapInfoModelList.Add(MapInfoModel);
                }

                MikeScenarioModel.TVItemModel = tvItemModel;

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

                    TVItemModel TVItemModelMikeSource = new TVItemModel();
                    TVItemModelMikeSource.TVItem = tvItem;
                    TVItemModelMikeSource.TVItemLanguageList = TVItemLanguageListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    foreach (TVItemLanguage tvItemLanguage in TVItemModelMikeSource.TVItemLanguageList)
                    {
                        tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                        RegexOptions options = RegexOptions.None;
                        Regex regex = new Regex("[ ]{2,}", options);
                        tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                    }

                    foreach (MapInfo MapInfo in MapInfoListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID))
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointListMikeSource.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                        TVItemModelMikeSource.MapInfoModelList.Add(MapInfoModel);
                    }

                    mikeSourceModel.TVItemModel = TVItemModelMikeSource;
                    mikeSourceModel.MikeSource = MikeSourceList.Where(c => c.MikeSourceTVItemID == tvItem.TVItemID).FirstOrDefault();
                    mikeSourceModel.MikeSourceStartEndList = MikeSourceStartEndList.Where(c => c.MikeSourceID == mikeSourceModel.MikeSource.MikeSourceID).ToList();

                    MikeScenarioModel.MikeSourceModelList.Add(mikeSourceModel);
                }

                // doing MikeScenarioModel.MikeBoundaryConditionModelList
                foreach (TVItem tvItem in TVItemListMikeBoundary.Where(c => c.ParentID == tvItemMikeScenario.TVItemID))
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModel = new MikeBoundaryConditionModel();

                    TVItemModel TVItemModelBC = new TVItemModel();
                    TVItemModelBC.TVItem = tvItem;
                    TVItemModelBC.TVItemLanguageList = TVItemLanguageListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

                    foreach (TVItemLanguage tvItemLanguage in TVItemModelBC.TVItemLanguageList)
                    {
                        tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                        RegexOptions options = RegexOptions.None;
                        Regex regex = new Regex("[ ]{2,}", options);
                        tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                    }

                    foreach (MapInfo MapInfo in MapInfoListMikeSource.Where(c => c.TVItemID == tvItem.TVItemID))
                    {
                        MapInfoModel MapInfoModel = new MapInfoModel();
                        MapInfoModel.MapInfo = MapInfo;
                        MapInfoModel.MapInfoPointList = MapInfoPointListMikeSource.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                        TVItemModelBC.MapInfoModelList.Add(MapInfoModel);
                    }

                    mikeBoundaryConditionModel.TVItemModel = TVItemModelBC;
                    mikeBoundaryConditionModel.MikeBoundaryCondition = MikeBoundaryConditionList.Where(c => c.MikeBoundaryConditionTVItemID == tvItem.TVItemID).FirstOrDefault();

                    MikeScenarioModel.MikeBoundaryConditionModelList.Add(mikeBoundaryConditionModel);
                }

                MIKEScenarioModelList.Add(MikeScenarioModel);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}