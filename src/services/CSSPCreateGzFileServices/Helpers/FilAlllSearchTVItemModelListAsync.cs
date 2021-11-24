namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillAllSearchTVItemModelListAsync(List<TVItemModel> TVItemSearchList)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TVItemModel> TVItemSearchList)";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetSearchableTVItemAsync();
        List<TVItemLanguage> TVItemLanguageList = await GetSearchableTVItemLanguageAsync();

        foreach (TVItem tvItem in TVItemList)
        {
            TVItemModel tvItemModel = new TVItemModel();
            tvItemModel.TVItem = tvItem;
            tvItemModel.TVItemLanguageList = (from c in TVItemLanguageList
                                              where c.TVItemID == tvItem.TVItemID
                                              orderby c.Language
                                              select c).ToList();

            TVItemSearchList.Add(tvItemModel);
        }

        TVItemSearchList = (from c in TVItemSearchList
                            orderby c.TVItem.TVLevel
                            select c).ToList();

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
