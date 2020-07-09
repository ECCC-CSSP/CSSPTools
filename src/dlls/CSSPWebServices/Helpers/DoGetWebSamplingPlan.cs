/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<ActionResult<WebSamplingPlan>> DoGetWebSamplingPlan(int samplingPlanID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            SamplingPlan samplingPlan = await GetSamplingPlanWithSamplingPlanID(samplingPlanID);

            if (samplingPlan == null)
            {
                return BadRequest($"SamplingPlan could not be found for SamplingPlanID = [{ samplingPlanID }]");
            }

            WebSamplingPlan webSamplingPlan = new WebSamplingPlan();

            try
            {
                webSamplingPlan.SamplingPlan = samplingPlan;
                webSamplingPlan.SamplingPlanEmailList = await GetSamplingPlanEmailListWithSamplingPlanID(samplingPlanID);
                webSamplingPlan.SamplingPlanSubsectorList = await GetSamplingPlanSubsectorListWithSamplingPlanID(samplingPlanID);
                webSamplingPlan.SamplingPlanSubsectorSiteList = await GetSamplingPlanSubsectorSiteListWithSamplingPlanID(samplingPlanID);

                await DoStore<WebSamplingPlan>(webSamplingPlan, $"WebSamplingPlan_{samplingPlanID}.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return BadRequest($"{ ex.Message } { inner }");
            }

            return await Task.FromResult(Ok(webSamplingPlan));
        }
    }
}
