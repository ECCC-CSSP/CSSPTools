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
        private async Task<WebDrogueRun> DoReadWebDrogueRunGzFile(int SubsectorTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebDrogueRun());
            }

            WebDrogueRun webDrogueRun = await DoRead<WebDrogueRun>($"WebDrogueRun_{ SubsectorTVItemID }.Gz");

            return await Task.FromResult(webDrogueRun);
        }
    }
}
