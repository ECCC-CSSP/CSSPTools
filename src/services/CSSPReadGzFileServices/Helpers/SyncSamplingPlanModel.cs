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
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        private void SyncSamplingPlanModel(SamplingPlanModel samplingPlanModelOriginal, SamplingPlanModel samplingPlanModelLocal)
        {
            if (samplingPlanModelLocal != null)
            {
                if (samplingPlanModelLocal.SamplingPlan != null)
                {
                    samplingPlanModelOriginal.SamplingPlan = samplingPlanModelLocal.SamplingPlan;
                }

                foreach (SamplingPlanSubsectorModel samplingPlanSubsectorModelLocal in samplingPlanModelLocal.SamplingPlanSubsectorModelList)
                {
                    SamplingPlanSubsectorModel samplingPlanSubsectorModelOriginal = samplingPlanModelOriginal.SamplingPlanSubsectorModelList.Where(c => c.SamplingPlanSubsector.SamplingPlanSubsectorID == samplingPlanSubsectorModelLocal.SamplingPlanSubsector.SamplingPlanSubsectorID).FirstOrDefault();
                    
                    if (samplingPlanSubsectorModelOriginal == null)
                    {
                        samplingPlanModelOriginal.SamplingPlanSubsectorModelList.Add(samplingPlanSubsectorModelLocal);
                    }
                    else
                    {
                        SyncSamplingPlanSubsectorModel(samplingPlanSubsectorModelOriginal, samplingPlanSubsectorModelLocal);
                    }
                }

                foreach (SamplingPlanEmail samplingPlanEmailLocal in samplingPlanModelLocal.SamplingPlanEmailList)
                {
                    SamplingPlanEmail samplingPlanEmailOriginal = samplingPlanModelOriginal.SamplingPlanEmailList.Where(c => c.SamplingPlanEmailID == samplingPlanEmailLocal.SamplingPlanEmailID).FirstOrDefault();

                    if (samplingPlanEmailOriginal == null)
                    {
                        samplingPlanModelOriginal.SamplingPlanEmailList.Add(samplingPlanEmailLocal);
                    }
                    else
                    {
                        samplingPlanEmailOriginal = samplingPlanEmailLocal;
                    }
                }
            }
        }
    }
}
