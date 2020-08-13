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
        private async Task<WebPolSourceSite> DoReadWebPolSourceSiteGzFile(int SubsectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebPolSourceSite());
            }

            WebPolSourceSite webPolSourceSite = await DoRead<WebPolSourceSite>($"WebPolSourceSite_{ SubsectorTVItemID }.Gz");

            return await Task.FromResult(webPolSourceSite);
        }
    }
}
