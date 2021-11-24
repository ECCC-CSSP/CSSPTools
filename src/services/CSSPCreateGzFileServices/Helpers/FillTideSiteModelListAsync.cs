namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillTideSiteModelListAsync(List<TideSiteModel> TideSiteModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TideSiteModel> TideSiteModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.TideSite);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.TideSite);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.TideSite);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.TideSite);

        List<TideSite> TideSiteList = await GetTideSiteListUnderProvinceAsync(TVItem);
        List<TideDataValue> TideDataValueList = await GetTideDataValueListUnderProvinceAsync(TVItem);

        foreach (TVItem tvItem in TVItemList)
        {
            TideSiteModel tideSiteModel = new TideSiteModel();

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

            tideSiteModel.TVItemModel = TVItemModel;
            tideSiteModel.TideSite = TideSiteList.Where(c => c.TideSiteTVItemID == tvItem.TVItemID).FirstOrDefault();
            tideSiteModel.TideDataValueList = TideDataValueList.Where(c => c.TideSiteTVItemID == tideSiteModel.TideSite.TideSiteTVItemID).ToList();

            TideSiteModelList.Add(tideSiteModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
