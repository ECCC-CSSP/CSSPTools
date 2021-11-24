namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillMWQMRunModelListAsync(List<MWQMRunModel> MWQMRunModelList, TVItem TVItem, TVTypeEnum TVType)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMRunModel> MWQMRunModelList, TVItem TVItem, TVTypeEnum TVType) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }  TVType: { TVType }";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVType);
        List<TVItemStat> TVItemStatList = await GetTVItemStatChildrenListWithTVItemIDAsync(TVItem, TVType);

        List<MWQMRun> MWQMRunList = await GetMWQMRunListFromSubsectorAsync(TVItem);
        List<MWQMRunLanguage> MWQMRunLanguageList = await GetMWQMRunLanguageListFromSubsectorAsync(TVItem);

        foreach (TVItem tvItem in TVItemList)
        {
            MWQMRunModel mwqmRunModel = new MWQMRunModel();

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

            mwqmRunModel.TVItemModel = TVItemModel;

            mwqmRunModel.MWQMRun = MWQMRunList.Where(c => c.MWQMRunTVItemID == tvItem.TVItemID).FirstOrDefault();
            if (mwqmRunModel.MWQMRun != null)
            {
                mwqmRunModel.MWQMRunLanguageList = MWQMRunLanguageList.Where(c => c.MWQMRunID == mwqmRunModel.MWQMRun.MWQMRunID).ToList();
            }

            MWQMRunModelList.Add(mwqmRunModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
