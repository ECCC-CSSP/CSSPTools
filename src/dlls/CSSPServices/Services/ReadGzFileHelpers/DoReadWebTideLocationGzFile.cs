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
        private async Task<WebTideLocation> DoReadWebTideLocationGzFile()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebTideLocation());
            }

            WebTideLocation webTideLocation = await DoRead<WebTideLocation>($"WebTideLocation.Gz");

            return await Task.FromResult(webTideLocation);
        }
    }
}
