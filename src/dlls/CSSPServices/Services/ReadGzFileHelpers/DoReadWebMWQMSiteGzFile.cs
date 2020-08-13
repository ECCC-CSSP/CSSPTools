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
        private async Task<WebMWQMSite> DoReadWebMWQMSiteGzFile(int SubsectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMSite());
            }

            WebMWQMSite webMWQMSite = await DoRead<WebMWQMSite>($"WebMWQMSite_{ SubsectorTVItemID }.Gz");

            return await Task.FromResult(webMWQMSite);
        }
    }
}
