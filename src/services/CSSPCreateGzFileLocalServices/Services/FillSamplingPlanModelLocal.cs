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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task FillSamplingPlanModelLocal(SamplingPlanModel SamplingPlanModel, SamplingPlan SamplingPlan)
        {
            SamplingPlanModel.SamplingPlan = SamplingPlan;
            SamplingPlanModel.SamplingPlanEmailList = await GetSamplingPlanEmailListWithSamplingPlanID(SamplingPlan.SamplingPlanID);

            List<SamplingPlanSubsector> SamplingPlanSubsectorList = await GetSamplingPlanSubsectorListWithSamplingPlanID(SamplingPlan.SamplingPlanID);
            List<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteList = await GetSamplingPlanSubsectorSiteListWithSamplingPlanID(SamplingPlan.SamplingPlanID);

            foreach(SamplingPlanSubsector SamplingPlanSubsector in SamplingPlanSubsectorList)
            {
                SamplingPlanSubsectorModel SamplingPlanSubsectorModel = new SamplingPlanSubsectorModel();
                SamplingPlanSubsectorModel.SamplingPlanSubsector = SamplingPlanSubsector;
                SamplingPlanSubsectorModel.SamplingPlanSubsectorSiteList = SamplingPlanSubsectorSiteList.Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsector.SamplingPlanSubsectorID).ToList();

                SamplingPlanModel.SamplingPlanSubsectorModelList.Add(SamplingPlanSubsectorModel);
            }
        }
    }
}