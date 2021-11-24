namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillTVItemModelAndParentTVItemModelListAsync(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(TVItemModel TVItemModel, List<TVItemModel> TVItemParentList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemParentListWithTVItemAsync(TVItem);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageParentListWithTVItemAsync(TVItem);
        List<TVItemStat> TVItemStatList = await GetTVItemStatParentListWithTVItemAsync(TVItem);
        List<MapInfo> MapInfoList = await GetMapInfoParentListWithTVItemAsync(TVItem);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointParentListWithTVItemAsync(TVItem);

        foreach (TVItem tvItem in TVItemList)
        {
            TVItemModel tvItemModelParent = new TVItemModel();
            tvItemModelParent.TVItem = tvItem;
            tvItemModelParent.TVItemLanguageList = (from c in TVItemLanguageList
                                                    where c.TVItemID == tvItem.TVItemID
                                                    orderby c.Language
                                                    select c).ToList();

            foreach (TVItemLanguage tvItemLanguage in tvItemModelParent.TVItemLanguageList)
            {
                tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
            }

            tvItemModelParent.TVItemStatList = TVItemStatList.Where(c => c.TVItemID == tvItem.TVItemID).ToList();

            TVItemParentList.Add(tvItemModelParent);
        }

        TVItemModel.TVItem = TVItemParentList[TVItemParentList.Count - 1].TVItem;
        TVItemModel.TVItemLanguageList = TVItemParentList[TVItemParentList.Count - 1].TVItemLanguageList;

        foreach (TVItemLanguage tvItemLanguage in TVItemModel.TVItemLanguageList)
        {
            tvItemLanguage.TVText = tvItemLanguage.TVText.Replace(Convert.ToChar(160), ' ');

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            tvItemLanguage.TVText = regex.Replace(tvItemLanguage.TVText, " ");
        }

        TVItemModel.TVItemStatList = TVItemParentList[TVItemParentList.Count - 1].TVItemStatList;

        foreach (MapInfo MapInfo in MapInfoList.Where(c => c.TVItemID == TVItem.TVItemID))
        {
            MapInfoModel MapInfoModel = new MapInfoModel();
            MapInfoModel.MapInfo = MapInfo;
            MapInfoModel.MapInfoPointList = MapInfoPointList.Where(c => c.MapInfoID == MapInfo.MapInfoID).Select(c => c).ToList();

            TVItemModel.MapInfoModelList.Add(MapInfoModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
