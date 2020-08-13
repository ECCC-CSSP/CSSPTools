/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<WebSamplingPlan> DoReadWebSamplingPlanGzFile(int SamplingPlanID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebSamplingPlan());
            }

            WebSamplingPlan webSamplingPlan = await DoRead<WebSamplingPlan>($"WebSamplingPlan_{ SamplingPlanID }.Gz");

            return await Task.FromResult(webSamplingPlan);
        }
    }
}

