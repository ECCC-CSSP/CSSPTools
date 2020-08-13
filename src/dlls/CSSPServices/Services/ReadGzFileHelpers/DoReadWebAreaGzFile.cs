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
        private async Task<WebArea> DoReadWebAreaGzFile(int AreaTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebArea());
            }

            WebArea webArea = await DoRead<WebArea>($"WebArea_{ AreaTVItemID }.Gz");

            return await Task.FromResult(webArea);
        }
    }
}
