namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillClassificationModelListAsync(List<ClassificationModel> ClassificationModelList, TVItem TVItem, TVTypeEnum TVType)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMSiteModel> MWQMSiteModelList, TVItem TVItem, TVTypeEnum TVType) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }  TVType: { TVType }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVType);

        List<Classification> ClassificationList = await GetClassificationListFromSubsectorAsync(TVItem);

        List<TVFile> TVFileListAll = await GetAllTVFileListUnderAsync(TVItem);
        List<TVFileLanguage> TVFileLanguageListAll = await GetAllTVFileLanguageListUnderAsync(TVItem);

        List<TVItem> TVItemFileList = await GetTVItemAllChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);

        foreach (TVItem tvItem in TVItemList)
        {

            ClassificationModel classificationModel = new ClassificationModel();

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

            classificationModel.TVItemModel = TVItemModel;

            classificationModel.Classification = ClassificationList.Where(c => c.ClassificationTVItemID == tvItem.TVItemID).FirstOrDefault();

            ClassificationModelList.Add(classificationModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
