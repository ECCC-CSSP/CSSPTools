namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebMWQMSamples1980_2020Async(WebMWQMSamples1980_2020 webMWQMSamples1980_2020, WebMWQMSamples1980_2020 webMWQMSamples1980_2020Local)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMSamples WebMWQMSamples, WebMWQMSamples WebMWQMSamplesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebMWQMSamples1980_2020TVItemModel(webMWQMSamples1980_2020, webMWQMSamples1980_2020Local);

        MergeJsonWebMWQMSamples1980_2020TVItemModelParentList(webMWQMSamples1980_2020, webMWQMSamples1980_2020Local);

        MergeJsonWebMWQMSamples1980_2020MWQMSampleModelList(webMWQMSamples1980_2020, webMWQMSamples1980_2020Local);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebMWQMSamples1980_2020TVItemModel(WebMWQMSamples1980_2020 webMWQMSamples1980_2020, WebMWQMSamples1980_2020 webMWQMSamples1980_2020Local)
    {
        if (webMWQMSamples1980_2020Local.TVItemModel.TVItem.TVItemID != 0
            && (webMWQMSamples1980_2020Local.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
          || webMWQMSamples1980_2020Local.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
          || webMWQMSamples1980_2020Local.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webMWQMSamples1980_2020.TVItemModel, webMWQMSamples1980_2020Local.TVItemModel);
        }
    }
    private void MergeJsonWebMWQMSamples1980_2020TVItemModelParentList(WebMWQMSamples1980_2020 webMWQMSamples1980_2020, WebMWQMSamples1980_2020 webMWQMSamples1980_2020Local)
    {
        if ((from c in webMWQMSamples1980_2020Local.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webMWQMSamples1980_2020.TVItemModelParentList, webMWQMSamples1980_2020Local.TVItemModelParentList);
        }
    }
    private void MergeJsonWebMWQMSamples1980_2020MWQMSampleModelList(WebMWQMSamples1980_2020 webMWQMSamples1980_2020, WebMWQMSamples1980_2020 webMWQMSamples1980_2020Local)
    {
        List<MWQMSampleModel> MWQMSampleModelList = (from c in webMWQMSamples1980_2020Local.MWQMSampleModelList
                                                     where c.MWQMSample.MWQMSampleID != 0
                                                     && c.MWQMSample.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

        foreach (MWQMSampleModel mwqmSampleModel in MWQMSampleModelList)
        {
            MWQMSampleModel mwqmSampleModelOriginal = webMWQMSamples1980_2020.MWQMSampleModelList.Where(c => c.MWQMSample.MWQMSampleID == mwqmSampleModel.MWQMSample.MWQMSampleID).FirstOrDefault();
            if (mwqmSampleModelOriginal == null)
            {
                webMWQMSamples1980_2020.MWQMSampleModelList.Add(mwqmSampleModel);
            }
            else
            {
                SyncMWQMSampleModel(mwqmSampleModelOriginal, mwqmSampleModel);
            }
        }
    }
}

