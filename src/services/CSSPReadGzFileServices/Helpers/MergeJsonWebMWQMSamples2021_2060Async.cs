namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebMWQMSamples2021_2060Async(WebMWQMSamples2021_2060 webMWQMSamples2021_2060, WebMWQMSamples2021_2060 webMWQMSamples2021_2060Local)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMSamples WebMWQMSamples, WebMWQMSamples WebMWQMSamplesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebMWQMSamples2021_2060TVItemModel(webMWQMSamples2021_2060, webMWQMSamples2021_2060Local);

        MergeJsonWebMWQMSamples2021_2060TVItemModelParentList(webMWQMSamples2021_2060, webMWQMSamples2021_2060Local);

        MergeJsonWebMWQMSamples2021_2060MWQMSampleModelList(webMWQMSamples2021_2060, webMWQMSamples2021_2060Local);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebMWQMSamples2021_2060TVItemModel(WebMWQMSamples2021_2060 webMWQMSamples2021_2060, WebMWQMSamples2021_2060 webMWQMSamples2021_2060Local)
    {
        if (webMWQMSamples2021_2060Local.TVItemModel.TVItem.TVItemID != 0
            && (webMWQMSamples2021_2060Local.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
          || webMWQMSamples2021_2060Local.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
          || webMWQMSamples2021_2060Local.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webMWQMSamples2021_2060.TVItemModel, webMWQMSamples2021_2060Local.TVItemModel);
        }
    }
    private void MergeJsonWebMWQMSamples2021_2060TVItemModelParentList(WebMWQMSamples2021_2060 webMWQMSamples2021_2060, WebMWQMSamples2021_2060 webMWQMSamples2021_2060Local)
    {
        if ((from c in webMWQMSamples2021_2060Local.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webMWQMSamples2021_2060.TVItemModelParentList, webMWQMSamples2021_2060Local.TVItemModelParentList);
        }
    }
    private void MergeJsonWebMWQMSamples2021_2060MWQMSampleModelList(WebMWQMSamples2021_2060 webMWQMSamples2021_2060, WebMWQMSamples2021_2060 webMWQMSamples2021_2060Local)
    {
        List<MWQMSampleModel> MWQMSampleModelList = (from c in webMWQMSamples2021_2060Local.MWQMSampleModelList
                                                     where c.MWQMSample.MWQMSampleID != 0
                                                     && c.MWQMSample.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

        foreach (MWQMSampleModel mwqmSampleModel in MWQMSampleModelList)
        {
            MWQMSampleModel mwqmSampleModelOriginal = webMWQMSamples2021_2060.MWQMSampleModelList.Where(c => c.MWQMSample.MWQMSampleID == mwqmSampleModel.MWQMSample.MWQMSampleID).FirstOrDefault();
            if (mwqmSampleModelOriginal == null)
            {
                webMWQMSamples2021_2060.MWQMSampleModelList.Add(mwqmSampleModel);
            }
            else
            {
                SyncMWQMSampleModel(mwqmSampleModelOriginal, mwqmSampleModel);
            }
        }
    }
}

