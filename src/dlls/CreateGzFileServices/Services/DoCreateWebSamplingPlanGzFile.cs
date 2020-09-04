/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebSamplingPlanGzFile(int SamplingPlanID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            SamplingPlan samplingPlan = await GetSamplingPlanWithSamplingPlanID(SamplingPlanID);

            if (samplingPlan == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "SamplingPlan", "SamplingPlanID", SamplingPlanID.ToString())));
            }

            WebSamplingPlan webSamplingPlan = new WebSamplingPlan();

            try
            {
                webSamplingPlan.SamplingPlan = samplingPlan;
                webSamplingPlan.SamplingPlanEmailList = await GetSamplingPlanEmailListWithSamplingPlanID(SamplingPlanID);
                webSamplingPlan.SamplingPlanSubsectorList = await GetSamplingPlanSubsectorListWithSamplingPlanID(SamplingPlanID);
                webSamplingPlan.SamplingPlanSubsectorSiteList = await GetSamplingPlanSubsectorSiteListWithSamplingPlanID(SamplingPlanID);

                await DoStore<WebSamplingPlan>(webSamplingPlan, $"WebSamplingPlan_{SamplingPlanID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
