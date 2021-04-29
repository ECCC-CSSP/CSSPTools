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
        private async Task FillSamplingPlanModelList(List<SamplingPlanModel> SamplingPlanModelList, TVItem tvItem)
        {
            List<SamplingPlan> SamplingPlanList = await GetAllSamplingPlanUnderProvince(tvItem);
            List<SamplingPlanEmail> SamplingPlanEmailList = await GetAllSamplingPlanEmailUnderProvince(tvItem);
            List<SamplingPlanSubsector> SamplingPlanSubsectorList = await GetAllSamplingPlanSubsectorUnderProvince(tvItem);
            List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList = await GetAllSamplingPlanSubsectorSiteUnderProvince(tvItem);

            foreach(SamplingPlan samplingPlan in SamplingPlanList)
            {
                SamplingPlanModel samplingPlanModel = new SamplingPlanModel();

                samplingPlanModel.SamplingPlan = samplingPlan;
                samplingPlanModel.SamplingPlanEmailList = SamplingPlanEmailList.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).ToList();

                foreach(SamplingPlanSubsector samplingPlanSubsector in SamplingPlanSubsectorList.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID))
                {
                    SamplingPlanSubsectorModel samplingPlanSubsectorModel = new SamplingPlanSubsectorModel();

                    samplingPlanSubsectorModel.SamplingPlanSubsector = samplingPlanSubsector;
                    samplingPlanSubsectorModel.SamplingPlanSubsectorSiteList = SamplingPlanSubsectorSiteList.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).ToList();

                    samplingPlanModel.SamplingPlanSubsectorModelList.Add(samplingPlanSubsectorModel);
                }

                SamplingPlanModelList.Add(samplingPlanModel);
            }
        }
    }
}