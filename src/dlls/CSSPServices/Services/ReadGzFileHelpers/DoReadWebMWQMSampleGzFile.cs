/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<WebMWQMSample> DoReadWebMWQMSampleGzFile(int SubsectorTVItemID, int Year)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSample());
            }

            WebMWQMSample webMWQMSample = await DoRead<WebMWQMSample>($"WebMWQMSample_{SubsectorTVItemID}_{Year}_{Year + 9}.Gz");

            return await Task.FromResult(webMWQMSample);
        }
    }
}
