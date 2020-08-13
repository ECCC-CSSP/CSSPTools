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
        private async Task<WebReportType> DoReadWebReportTypeGzFile()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebReportType());
            }

            WebReportType webReportType = await DoRead<WebReportType>($"WebReportType.Gz");

            return await Task.FromResult(webReportType);
        }
    }
}
