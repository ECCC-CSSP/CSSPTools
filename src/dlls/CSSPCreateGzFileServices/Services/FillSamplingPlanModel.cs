/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task FillSamplingPlanModel(SamplingPlanModel SamplingPlanModel, SamplingPlan SamplingPlan)
        {
            SamplingPlanModel.SamplingPlan = SamplingPlan;
            SamplingPlanModel.SamplingPlanEmailList = await GetSamplingPlanEmailListWithSamplingPlanID(SamplingPlan.SamplingPlanID);

            List<SamplingPlanSubsector> SamplingPlanSubsectorList = await GetSamplingPlanSubsectorListWithSamplingPlanID(SamplingPlan.SamplingPlanID);
            List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList = await GetSamplingPlanSubsectorSiteListWithSamplingPlanID(SamplingPlan.SamplingPlanID);

            foreach(SamplingPlanSubsector samplingPlanSubsector in SamplingPlanSubsectorList)
            {
                SamplingPlanSubsectorModel samplingPlanSubsectorModel = new SamplingPlanSubsectorModel();
                samplingPlanSubsectorModel.SamplingPlanSubsector = samplingPlanSubsector;
                samplingPlanSubsectorModel.SamplingPlanSubsectorSiteList = SamplingPlanSubsectorSiteList.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).ToList();

                SamplingPlanModel.SamplingPlanSubsectorModelList.Add(samplingPlanSubsectorModel);
            }
        }
    }
}