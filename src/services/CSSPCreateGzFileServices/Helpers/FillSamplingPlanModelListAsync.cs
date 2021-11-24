namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillSamplingPlanModelListAsync(List<SamplingPlanModel> SamplingPlanModelList, TVItem tvItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<SamplingPlanModel> SamplingPlanModelList, TVItem tvItem) -- TVItem.TVItemID: { tvItem.TVItemID }   TVItem.TVPath: { tvItem.TVPath }";
        CSSPLogService.FunctionLog(FunctionName);

        List<SamplingPlan> SamplingPlanList = await GetAllSamplingPlanUnderProvinceAsync(tvItem);
        List<SamplingPlanEmail> SamplingPlanEmailList = await GetAllSamplingPlanEmailUnderProvinceAsync(tvItem);
        List<SamplingPlanSubsector> SamplingPlanSubsectorList = await GetAllSamplingPlanSubsectorUnderProvinceAsync(tvItem);
        List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList = await GetAllSamplingPlanSubsectorSiteUnderProvinceAsync(tvItem);

        foreach (SamplingPlan samplingPlan in SamplingPlanList)
        {
            SamplingPlanModel samplingPlanModel = new SamplingPlanModel();

            samplingPlanModel.SamplingPlan = samplingPlan;
            samplingPlanModel.SamplingPlanEmailList = SamplingPlanEmailList.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).ToList();

            foreach (SamplingPlanSubsector samplingPlanSubsector in SamplingPlanSubsectorList.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID))
            {
                SamplingPlanSubsectorModel samplingPlanSubsectorModel = new SamplingPlanSubsectorModel();

                samplingPlanSubsectorModel.SamplingPlanSubsector = samplingPlanSubsector;
                samplingPlanSubsectorModel.SamplingPlanSubsectorSiteList = SamplingPlanSubsectorSiteList.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).ToList();

                samplingPlanModel.SamplingPlanSubsectorModelList.Add(samplingPlanSubsectorModel);
            }

            SamplingPlanModelList.Add(samplingPlanModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
