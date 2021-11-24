namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillMWQMSiteModelListAsync(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }  TVType: { TVType }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVType);

        List<MWQMSite> MWQMSiteList = await GetMWQMSiteListFromSubsectorAsync(TVItem);

        List<TVFile> TVFileListAll = await GetAllTVFileListUnderAsync(TVItem);
        List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnderAsync(TVItem);

        List<TVItem> TVItemFileList = await GetTVItemAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);
        List<TVItemLanguage> TVItemLanguageFileList = await GetTVItemLanguageAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);

        foreach (TVItem tvItem in TVItemList)
        {

            MWQMSiteModel mwqmSiteModel = new MWQMSiteModel();

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

            mwqmSiteModel.TVItemModel = TVItemModel;

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

                    mwqmSiteModel.TVFileModelList.Add(tvFileModel);
                }
            }

            mwqmSiteModel.MWQMSite = MWQMSiteList.Where(c => c.MWQMSiteTVItemID == tvItem.TVItemID).FirstOrDefault();

            MWQMSiteModelList.Add(mwqmSiteModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
