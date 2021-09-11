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
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> FillSamplingPlanModelList(List<SamplingPlanModel> SamplingPlanModelList, TVItem tvItem)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<SamplingPlanModel> SamplingPlanModelList, TVItem tvItem) -- TVItem.TVItemID: { tvItem.TVItemID }   TVItem.TVPath: { tvItem.TVPath }";
            CSSPLogService.FunctionLog(FunctionName);

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

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}