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
        private async Task<WebSector> DoReadWebSectorGzFile(int SectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebSector());
            }

            WebSector webSector = await DoRead<WebSector>($"WebSector_{ SectorTVItemID }.Gz");

            return await Task.FromResult(webSector);
        }
    }
}
