/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
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
}
