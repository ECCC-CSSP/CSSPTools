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
        private async Task<WebHelpDoc> DoReadWebHelpDocGzFile(int AreaTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebHelpDoc());
            }

            WebHelpDoc webHelpDoc = await DoRead<WebHelpDoc>($"WebHelpDoc.Gz");

            return await Task.FromResult(webHelpDoc);
        }
    }
}
