namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillMWQMSampleModelList2021_2060Async(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<MWQMSample> MWQMSampleList = await GetWQMSampleListFromSubsector2021_2060Async(TVItem);
        List<MWQMSampleLanguage> MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector2021_2060Async(TVItem);

        foreach (MWQMSample mwqmSample in MWQMSampleList)
        {
            MWQMSampleModel mwqmSampleModel = new MWQMSampleModel()
            {
                MWQMSample = mwqmSample,
                MWQMSampleLanguageList = MWQMSampleLanguageList.Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).ToList(),
            };

            MWQMSampleModelList.Add(mwqmSampleModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
