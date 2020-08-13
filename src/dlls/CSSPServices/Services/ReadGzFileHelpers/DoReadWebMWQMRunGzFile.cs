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
        private async Task<WebMWQMRun> DoReadWebMWQMRunGzFile(int SubsectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMRun());
            }

            WebMWQMRun webMWQMRun = await DoRead<WebMWQMRun>($"WebMWQMRun_{ SubsectorTVItemID }.Gz");

            return await Task.FromResult(webMWQMRun);
        }
    }
}
