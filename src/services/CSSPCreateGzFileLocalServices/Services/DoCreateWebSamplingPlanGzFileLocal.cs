/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebSamplingPlanGzFileLocal(int SamplingPlanID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            SamplingPlan SamplingPlan = await GetSamplingPlanWithSamplingPlanID(SamplingPlanID);

            if (SamplingPlan == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "SamplingPlan", "SamplingPlanID", SamplingPlanID.ToString())));
            }

            TVItem TVItemProvince = await GetTVItemWithTVItemID(SamplingPlan.ProvinceTVItemID);

            if (TVItemProvince == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "ProvinceTVItemID", SamplingPlan.ProvinceTVItemID.ToString())));
            }

            WebSamplingPlan webSamplingPlan = new WebSamplingPlan();

            try
            {
                await FillTVItemModelLocal(webSamplingPlan.TVItemModel, TVItemProvince);

                await FillParentListTVItemModelListLocal(webSamplingPlan.TVItemParentList, TVItemProvince);

                await FillSamplingPlanModelLocal(webSamplingPlan.SamplingPlanModel, SamplingPlan);

                DoStoreLocal<WebSamplingPlan>(webSamplingPlan, $"{ WebTypeEnum.WebSamplingPlan }_{ SamplingPlanID }.gz");
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
