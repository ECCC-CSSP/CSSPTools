namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebMWQMRunsAsync(WebMWQMRuns webMWQMRuns, WebMWQMRuns webMWQMRunsLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMRuns WebMWQMRuns, WebMWQMRuns WebMWQMRunsLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebMWQMRunsTVItemModel(webMWQMRuns, webMWQMRunsLocal);

        MergeJsonWebMWQMRunsTVItemModelParentList(webMWQMRuns, webMWQMRunsLocal);

        MergeJsonWebMWQMRunsMWQMRunModelList(webMWQMRuns, webMWQMRunsLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebMWQMRunsTVItemModel(WebMWQMRuns webMWQMRuns, WebMWQMRuns webMWQMRunsLocal)
    {
        if (webMWQMRunsLocal.TVItemModel.TVItem.TVItemID != 0
            && (webMWQMRunsLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
          || webMWQMRunsLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
          || webMWQMRunsLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webMWQMRuns.TVItemModel, webMWQMRunsLocal.TVItemModel);
        }
    }
    private void MergeJsonWebMWQMRunsTVItemModelParentList(WebMWQMRuns webMWQMRuns, WebMWQMRuns webMWQMRunsLocal)
    {
        if ((from c in webMWQMRunsLocal.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webMWQMRuns.TVItemModelParentList, webMWQMRunsLocal.TVItemModelParentList);
        }
    }
    private void MergeJsonWebMWQMRunsMWQMRunModelList(WebMWQMRuns webMWQMRuns, WebMWQMRuns webMWQMRunsLocal)
    {
        List<MWQMRunModel> MWQMRunModelLocalList = (from c in webMWQMRunsLocal.MWQMRunModelList
                                                    where c.TVItemModel.TVItem.TVItemID != 0
                                                    && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                    select c).ToList();

        foreach (MWQMRunModel mwqmRunModelLocal in MWQMRunModelLocalList)
        {
            MWQMRunModel mwqmRunModelOriginal = (from c in webMWQMRuns.MWQMRunModelList
                                                 where c.TVItemModel.TVItem.TVItemID == mwqmRunModelLocal.TVItemModel.TVItem.TVItemID
                                                 select c).FirstOrDefault();
            if (mwqmRunModelOriginal == null)
            {
                webMWQMRuns.MWQMRunModelList.Add(mwqmRunModelLocal);
            }
            else
            {
                SyncMWQMRunModel(mwqmRunModelOriginal, mwqmRunModelLocal);
            }
        }
    }
}

