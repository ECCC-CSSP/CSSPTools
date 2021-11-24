namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillPolSourceSiteModelListAsync(List<PolSourceSiteModel> PolSourceSiteModelList, TVItem TVItem, TVTypeEnum TVType)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<PolSourceSiteModel> PolSourceSiteModelList, TVItem TVItem, TVTypeEnum TVType) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }  TVType: { TVType }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVType);

        List<PolSourceSite> PolSourceSiteList = await GetPolSourceSiteListFromSubsectorAsync(TVItem);

        List<PolSourceObservation> PolSourceObservationList = await GetPolSourceObservationListFromSubsectorAsync(TVItem);
        List<PolSourceObservationIssue> PolSourceObservationIssueList = await GetPolSourceObservationIssueListFromSubsectorAsync(TVItem);
        List<PolSourceSiteEffect> PolSourceSiteEffectList = await GetPolSourceSiteEffectListFromSubsectorAsync(TVItem);
        List<Address> PolSourceSiteCivicAddressList = await GetPolSourceSiteAddressListFromSubsectorAsync(TVItem);

        List<TVFile> TVFileListAll = await GetAllTVFileListUnderAsync(TVItem);
        List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnderAsync(TVItem);

        List<TVItem> TVItemFileList = await GetTVItemAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);
        List<TVItemLanguage> TVItemLanguageFileList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);

        foreach (TVItem tvItem in TVItemList)
        {

            PolSourceSiteModel polSourceSiteModel = new PolSourceSiteModel();

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

            TVItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

            foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == tvItem.TVItemID))
            {
                MapInfoModel MapInfoModel = new MapInfoModel();
                MapInfoModel.MapInfo = MapInfo;
                MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                TVItemModel.MapInfoModelList.Add(MapInfoModel);
            }

            polSourceSiteModel.TVItemModel = TVItemModel;

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

                    polSourceSiteModel.TVFileModelList.Add(tvFileModel);
                }
            }

            polSourceSiteModel.PolSourceSite = PolSourceSiteList.Where(c => c.PolSourceSiteTVItemID == tvItem.TVItemID).FirstOrDefault();

            if (polSourceSiteModel.PolSourceSite != null)
            {
                foreach (PolSourceObservation PolSourceObservation in PolSourceObservationList.Where(c => c.PolSourceSiteID == polSourceSiteModel.PolSourceSite.PolSourceSiteID).OrderByDescending(c => c.ObservationDate_Local))
                {
                    PolSourceObservationModel polSourceObservationModel = new PolSourceObservationModel();
                    polSourceObservationModel.PolSourceObservation = PolSourceObservation;
                    polSourceObservationModel.PolSourceObservationIssueList = PolSourceObservationIssueList.Where(c => c.PolSourceObservationID == PolSourceObservation.PolSourceObservationID).ToList();

                    polSourceSiteModel.PolSourceObservationModelList.Add(polSourceObservationModel);
                }
            }

            polSourceSiteModel.PolSourceSiteEffectList = PolSourceSiteEffectList.Where(c => c.PolSourceSiteOrInfrastructureTVItemID == tvItem.TVItemID).ToList();

            PolSourceSiteModelList.Add(polSourceSiteModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
