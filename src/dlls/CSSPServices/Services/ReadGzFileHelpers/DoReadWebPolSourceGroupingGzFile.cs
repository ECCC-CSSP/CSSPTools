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
        private async Task<WebPolSourceGrouping> DoReadWebPolSourceGroupingGzFile()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebPolSourceGrouping());
            }

            WebPolSourceGrouping webPolSourceGrouping = await DoRead<WebPolSourceGrouping>($"WebPolSourceGrouping.Gz");

            return await Task.FromResult(webPolSourceGrouping);
        }
    }
}
