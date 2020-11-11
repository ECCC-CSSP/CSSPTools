/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPWebModels;
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

            TVItem tvItemProvince = await GetTVItemWithTVItemID(samplingPlan.ProvinceTVItemID);

            if (tvItemProvince == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "ProvinceTVItemID", samplingPlan.ProvinceTVItemID.ToString())));
            }

            WebSamplingPlan webSamplingPlan = new WebSamplingPlan();

            try
            {
                await FillParentListTVItemModelList(webSamplingPlan.TVItemParentList, tvItemProvince);

                await FillSamplingPlanModel(webSamplingPlan.SamplingPlanModel, samplingPlan);

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
