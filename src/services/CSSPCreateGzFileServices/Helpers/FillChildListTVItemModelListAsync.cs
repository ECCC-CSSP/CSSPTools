namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillChildListTVItemModelListAsync(List<TVItemModel> TVItemChildList, TVItem TVItem, TVTypeEnum TVType)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TVItemModel> TVItemChildList, TVItem TVItem, TVTypeEnum TVType) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }  TVType: { TVType }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVType);

        foreach (TVItem tvItem in TVItemList)
        {
            TVItemModel tvItemModel = new TVItemModel();
            tvItemModel.TVItem = tvItem;
            tvItemModel.TVItemLanguageList = (from c in TVItemLanguageList
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

            tvItemModel.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

            foreach (MapInfo MapInfo in MapInfoList)
            {
                if (MapInfo.TVItemID == tvItem.TVItemID)
                {
                    MapInfoModel MapInfoModel = new MapInfoModel();
                    MapInfoModel.MapInfo = MapInfo;
                    MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

                    tvItemModel.MapInfoModelList.Add(MapInfoModel);
                }
            }

            TVItemChildList.Add(tvItemModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
