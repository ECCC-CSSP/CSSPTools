namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillRainExceedanceModelListAsync(List<RainExceedanceModel> RainExceedanceModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<RainExceedanceModel> RainExceedanceModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.RainExceedance);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.RainExceedance);

        List<RainExceedance> RainExceedanceList = await GetRainExceedanceUnderCountryAsync(TVItem);
        List<RainExceedanceClimateSite> RainExceedanceClimateSiteList = await GetRainExceedanceClimateSiteUnderCountryAsync(TVItem);

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

            RainExceedanceModelList.Add(new RainExceedanceModel()
            {
                TVItemModel = tvItemModel,
                RainExceedance = RainExceedanceList.Where(c => c.RainExceedanceTVItemID == tvItem.TVItemID).FirstOrDefault(),
                RainExceedanceClimateSiteList = RainExceedanceClimateSiteList.Where(c => c.RainExceedanceTVItemID == tvItem.TVItemID).ToList(),
            });
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
