/*
 * Manually edited
 * 
 */
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        private async Task<WebMWQMLookupMPN> DoReadWebMWQMLookupMPNGzFile(int AreaTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMWQMLookupMPN());
            }

            WebMWQMLookupMPN webMWQMLookupMPN = await DoRead<WebMWQMLookupMPN>($"WebMWQMLookupMPN_{ AreaTVItemID }.Gz");

            return await Task.FromResult(webMWQMLookupMPN);
        }
    }
}
