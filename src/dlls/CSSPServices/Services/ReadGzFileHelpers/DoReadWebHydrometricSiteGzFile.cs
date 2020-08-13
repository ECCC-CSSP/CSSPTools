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
        private async Task<WebHydrometricSite> DoReadWebHydrometricSiteGzFile(int ProvinceTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebHydrometricSite());
            }

            WebHydrometricSite webHydrometricSite = await DoRead<WebHydrometricSite>($"WebHydrometricSite_{ ProvinceTVItemID }.Gz");

            return await Task.FromResult(webHydrometricSite);
        }
    }
}
