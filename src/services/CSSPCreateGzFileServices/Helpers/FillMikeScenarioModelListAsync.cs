namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillMikeScenarioModelListAsync(TVItemModel TVItemModel, List<TVItemModel> TVItemModelParentList, List<MikeScenarioModel> MIKEScenarioModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, List<MikeScenarioModel> MIKEScenarioModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemListMikeScenario = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeScenario);
        List<TVItemLanguage> TVItemLanguageListMikeScenario = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeScenario);
        List<TVItemStat> TVItemStatListMikeScenario = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeScenario);
        List<MapInfo> MapInfoListMikeScenario = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeScenario);
        List<MapInfoPoint> MapInfoPointListMikeScenario = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeScenario);

        List<TVItem> TVItemListMikeSource = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeSource);
        List<TVItemLanguage> TVItemLanguageListMikeSource = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeSource);
        List<TVItemStat> TVItemStatListMikeSource = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeSource);
        List<MapInfo> MapInfoListMikeSource = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeSource);
        List<MapInfoPoint> MapInfoPointListMikeSource = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeSource);

        List<TVItem> TVItemListMikeBoundary = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
        List<TVItemLanguage> TVItemLanguageListMikeBoundary = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
        List<TVItemStat> TVItemStatListMikeBoundary = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
        List<MapInfo> MapInfoListMikeBoundary = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);
        List<MapInfoPoint> MapInfoPointListMikeBoundary = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.MikeBoundaryConditionMesh);

        List<MikeSource> MikeSourceList = await GetMikeSourceListUnderMunicipalityAsync(TVItem);
        List<MikeSourceStartEnd> MikeSourceStartEndList = await GetMikeSourceStartEndListUnderMunicipalityAsync(TVItem);

        List<MikeBoundaryCondition> MikeBoundaryConditionList = await GetMikeBoundaryConditionListUnderMunicipalityAsync(TVItem);

        List<MikeScenario> MIKEScenarioList = await GetMikeScenarioListUnderMunicipalityAsync(TVItem);

        List<TVFile> TVFileListAll = await GetAllTVFileListUnderAsync(TVItem);
        List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnderAsync(TVItem);

        List<TVItem> TVItemFileList = await GetTVItemAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);
        List<TVItemLanguage> TVItemLanguageFileList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);

        foreach (TVItem tvItemMikeScenario in TVItemListMikeScenario)
        {
            MikeScenarioModel MikeScenarioModel = new MikeScenarioModel();

            MikeScenarioModel.MikeScenario = MIKEScenarioList.Where(c => c.MikeScenarioTVItemID == tvItemMikeScenario.TVItemID).FirstOrDefault();

            TVItemModel tvItemModel = new TVItemModel();

            // doing MikeScenarioModel.TVItemModel and MikeScenarioModel.TVItemParentList
            foreach (TVItem tvItem in TVItemListMikeScenario.Where(c => c.TVItemID == tvItemMikeScenario.TVItemID))
            {
                tvItemModel.TVItem = tvItem;
                tvItemModel.TVItemLanguageList = (from c in TVItemLanguageListMikeScenario
                                                  where c.TVItemID == tvItem.TVItemID
                                                  orderby c.Language
                                                  select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in tvItemModel.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                tvItemModel.TVItemStatList = TVItemStatListMikeScenario.Where(c => c.TVItemID == tvItem.TVItemID).ToList();
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
            foreach (TVItem tvItemFile in TVItemFileList.Where(c => c.TVPath.StartsWith(tvItemMikeScenario.TVPath + "p")))
            {
                TVFile tvFile = TVFileListAll.Where(c => c.TVFileTVItemID == tvItemFile.TVItemID).FirstOrDefault();
                if (tvFile != null)
                {
                    TVFileModel tvFileModel = new TVFileModel();
                    tvFileModel.TVFile = tvFile;
                    tvFileModel.TVFileLanguageList = (from c in TVFileLanguageListAll
                                                      where c.TVFileID == tvFileModel.TVFile.TVFileID
                                                      orderby c.Language
                                                      select c).ToList();

                    TVItemModel TVItemModel2 = new TVItemModel();
                    TVItemModel2.TVItem = tvItemFile;
                    TVItemModel2.TVItemLanguageList = (from c in TVItemLanguageFileList
                                                       where c.TVItemID == tvItemFile.TVItemID
                                                       orderby c.Language
                                                       select c).ToList();

                    foreach (TVItemLanguage tvItemLanguage in TVItemModel2.TVItemLanguageList)
                    {
                        tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                        RegexOptions options = RegexOptions.None;
                        Regex regex = new Regex("[ ]{2,}", options);
                        tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                    }

                    tvFileModel.TVItemModel = TVItemModel2;

                    MikeScenarioModel.TVFileModelList.Add(tvFileModel);
                }
            }

            // doing MikeScenarioModel.MikeSourceModelList
            foreach (TVItem tvItem in TVItemListMikeSource.Where(c => c.ParentID == tvItemMikeScenario.TVItemID))
            {
                MikeSourceModel mikeSourceModel = new MikeSourceModel();

                TVItemModel TVItemModelMikeSource = new TVItemModel();
                TVItemModelMikeSource.TVItem = tvItem;
                TVItemModelMikeSource.TVItemLanguageList = (from c in TVItemLanguageListMikeSource
                                                            where c.TVItemID == tvItem.TVItemID
                                                            orderby c.Language
                                                            select c).ToList();

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
                TVItemModelBC.TVItemLanguageList = (from c in TVItemLanguageListMikeBoundary
                                                    where c.TVItemID == tvItem.TVItemID
                                                    orderby c.Language
                                                    select c).ToList();

                foreach (TVItemLanguage tvItemLanguage in TVItemModelBC.TVItemLanguageList)
                {
                    tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{2,}", options);
                    tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
                }

                foreach (MapInfo MapInfo in MapInfoListMikeBoundary.Where(c => c.TVItemID == tvItem.TVItemID))
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointListMikeBoundary.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

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
