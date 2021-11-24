namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillClimateSiteModelListAsync(List<ClimateSiteModel> ClimateSiteModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<ClimateSiteModel> ClimateSiteModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.ClimateSite);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.ClimateSite);
        List<MapInfo> MapInfoList = await GetMapInfoChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.ClimateSite);
        List<MapInfoPoint> MapInfoPointList = await GetMapInfoPointChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.ClimateSite);

        List<ClimateSite> ClimateSiteList = await GetClimateSiteListUnderProvinceAsync(TVItem);
        List<ClimateDataValue> ClimateDataValueList = await GetClimateDataValueListUnderProvinceAsync(TVItem);

        foreach (TVItem tvItem in TVItemList)
        {
            ClimateSiteModel climateSiteModel = new ClimateSiteModel();

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

            climateSiteModel.TVItemModel = TVItemModel;
            climateSiteModel.ClimateSite = ClimateSiteList.Where(c => c.ClimateSiteTVItemID == tvItem.TVItemID).FirstOrDefault();
            climateSiteModel.ClimateDataValueList = ClimateDataValueList.Where(c => c.ClimateSiteID == climateSiteModel.ClimateSite.ClimateSiteID).ToList();

            ClimateSiteModelList.Add(climateSiteModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
