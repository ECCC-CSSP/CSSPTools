namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillInfrastructureModelListAsync(List<InfrastructureModel> InfrastructureModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<InfrastructureModel> InfrastructureModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.Infrastructure);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.Infrastructure);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.Infrastructure);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.Infrastructure);
        List<TVItem> TVItemFileListAll = await GetTVItemListFileUnderMunicipalityAsync(TVItem);
        List<TVItemLanguage> TVItemLanguageFileListAll = await GetTVItemLanguageListFileUnderMunicipalityAsync(TVItem);

        List<Infrastructure> InfrastructureList = await GetInfrastructureListUnderMunicipalityAsync(TVItem);
        List<InfrastructureLanguage> InfrastructureLanguageList = await GetInfrastructureLanguageListUnderMunicipalityAsync(TVItem);
        List<BoxModel> BoxModelList = await GetBoxModelListUnderMunicipalityAsync(TVItem);
        List<BoxModelLanguage> BoxModelLanguageList = await GetBoxModelLanguageListUnderMunicipalityAsync(TVItem);
        List<BoxModelResult> BoxModelResultList = await GetBoxModelResultListUnderMunicipalityAsync(TVItem);
        List<VPScenario> VPScenarioList = await GetVPScenarioListUnderMunicipalityAsync(TVItem);
        List<VPScenarioLanguage> VPScenarioLanguageList = await GetVPScenarioLanguageListUnderMunicipalityAsync(TVItem);
        List<VPAmbient> VPAmbientList = await GetVPAmbientListUnderMunicipalityAsync(TVItem);
        List<VPResult> VPResultList = await GetVPResultListUnderMunicipalityAsync(TVItem);

        List<TVFile> TVFileListAll = await GetAllTVFileListUnderAsync(TVItem);
        List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnderAsync(TVItem);

        List<TVItem> TVItemFileList = await GetTVItemAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);
        List<TVItemLanguage> TVItemLanguageFileList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);

        foreach (TVItem tvItem in TVItemList)
        {

            InfrastructureModel InfrastructureModel = new InfrastructureModel();

            InfrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();

            TVItemModel TVItemModel = new TVItemModel();
            TVItemModel.TVItem = tvItem;
            TVItemModel.TVItemLanguageList = (from c in TVItemLanguageList
                                              where c.TVItemID == tvItem.TVItemID
                                              orderby c.Language
                                              select c).ToList();

            foreach (TVItemLanguage tvItemLanguage in TVItemModel.TVItemLanguageList)
            {
                tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
            }

            foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
            {
                MapInfoModel MapInfoModel = new MapInfoModel();
                MapInfoModel.MapInfo = MapInfo;
                MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                TVItemModel.MapInfoModelList.Add(MapInfoModel);
            }

            InfrastructureModel.TVItemModel = TVItemModel;

            foreach (TVItem tvItemFile in TVItemFileList.Where(c => c.TVPath.StartsWith(tvItem.TVPath + "p")))
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

                    InfrastructureModel.TVFileModelList.Add(tvFileModel);
                }
            }

            InfrastructureModel.Infrastructure = InfrastructureList.Where(c => c.InfrastructureTVItemID == tvItem.TVItemID).FirstOrDefault();
            InfrastructureModel.InfrastructureLanguageList = InfrastructureLanguageList.Where(c => c.InfrastructureID == InfrastructureModel.Infrastructure.InfrastructureID).ToList();

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

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
