﻿namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebMWQMSamples1980_2020(WebMWQMSamples webMWQMSamples, WebMWQMSamples webMWQMSamplesLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebMWQMSamples WebMWQMSamples, WebMWQMSamples WebMWQMSamplesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebMWQMSamples1980_2020TVItemModel(webMWQMSamples, webMWQMSamplesLocal);

        MergeJsonWebMWQMSamples1980_2020TVItemModelParentList(webMWQMSamples, webMWQMSamplesLocal);

        MergeJsonWebMWQMSamples1980_2020MWQMSampleModelList(webMWQMSamples, webMWQMSamplesLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebMWQMSamples1980_2020TVItemModel(WebMWQMSamples webMWQMSamples, WebMWQMSamples webMWQMSamplesLocal)
    {
        if (webMWQMSamplesLocal.TVItemModel.TVItem.TVItemID != 0
            && (webMWQMSamplesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
          || webMWQMSamplesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
          || webMWQMSamplesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webMWQMSamples.TVItemModel, webMWQMSamplesLocal.TVItemModel);
        }
    }
    private void MergeJsonWebMWQMSamples1980_2020TVItemModelParentList(WebMWQMSamples webMWQMSamples, WebMWQMSamples webMWQMSamplesLocal)
    {
        if ((from c in webMWQMSamplesLocal.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webMWQMSamples.TVItemModelParentList, webMWQMSamplesLocal.TVItemModelParentList);
        }
    }
    private void MergeJsonWebMWQMSamples1980_2020MWQMSampleModelList(WebMWQMSamples webMWQMSamples, WebMWQMSamples webMWQMSamplesLocal)
    {
        List<MWQMSampleModel> MWQMSampleModelList = (from c in webMWQMSamplesLocal.MWQMSampleModelList
                                                     where c.MWQMSample.MWQMSampleID != 0
                                                     && c.MWQMSample.DBCommand != DBCommandEnum.Original
                                                     select c).ToList();

        foreach (MWQMSampleModel mwqmSampleModel in MWQMSampleModelList)
        {
            MWQMSampleModel mwqmSampleModelOriginal = webMWQMSamples.MWQMSampleModelList.Where(c => c.MWQMSample.MWQMSampleID == mwqmSampleModel.MWQMSample.MWQMSampleID).FirstOrDefault();
            if (mwqmSampleModelOriginal == null)
            {
                webMWQMSamples.MWQMSampleModelList.Add(mwqmSampleModel);
            }
            else
            {
                SyncMWQMSampleModel(mwqmSampleModelOriginal, mwqmSampleModel);
            }
        }
    }
}

