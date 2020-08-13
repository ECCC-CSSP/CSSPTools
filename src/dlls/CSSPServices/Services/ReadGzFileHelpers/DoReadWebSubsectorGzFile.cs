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
        private async Task<WebSubsector> DoReadWebSubsectorGzFile(int SubsectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebSubsector());
            }

            WebSubsector webSubsector = await DoRead<WebSubsector>($"WebSubsector_{ SubsectorTVItemID }.Gz");

            return await Task.FromResult(webSubsector);
        }
    }
}
