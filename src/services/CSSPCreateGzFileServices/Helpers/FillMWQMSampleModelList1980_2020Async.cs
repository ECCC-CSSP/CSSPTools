namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillMWQMSampleModelList1980_2020Async(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<MWQMSampleModel> MWQMSampleModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<MWQMSample> MWQMSampleList = await GetWQMSampleListFromSubsector1980_2020Async(TVItem);
        List<MWQMSampleLanguage> MWQMSampleLanguageList = await GetWQMSampleLanguageListFromSubsector1980_2020Async(TVItem);

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
