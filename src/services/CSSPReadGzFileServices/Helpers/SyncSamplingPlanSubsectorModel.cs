namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncSamplingPlanSubsectorModel(SamplingPlanSubsectorModel samplingPlanSubsectorModelOriginal, SamplingPlanSubsectorModel samplingPlanSubsectorModelLocal)
    {
        if (samplingPlanSubsectorModelLocal != null)
        {
            if (samplingPlanSubsectorModelLocal.SamplingPlanSubsector != null)
            {
                samplingPlanSubsectorModelOriginal.SamplingPlanSubsector = samplingPlanSubsectorModelLocal.SamplingPlanSubsector;
            }

            foreach (SamplingPlanSubsectorSite samplingPlanSubsectorSiteLocal in samplingPlanSubsectorModelLocal.SamplingPlanSubsectorSiteList)
            {
                SamplingPlanSubsectorSite samplingPlanSubsectorSiteOriginal = samplingPlanSubsectorModelOriginal.SamplingPlanSubsectorSiteList.Where(c => c.SamplingPlanSubsectorSiteID == samplingPlanSubsectorSiteLocal.SamplingPlanSubsectorSiteID).FirstOrDefault();
                if (samplingPlanSubsectorSiteOriginal == null)
                {
                    samplingPlanSubsectorModelOriginal.SamplingPlanSubsectorSiteList.Add(samplingPlanSubsectorSiteLocal);
                }
                else
                {
                    samplingPlanSubsectorSiteOriginal = samplingPlanSubsectorSiteLocal;
                }
            }
        }
    }
}

