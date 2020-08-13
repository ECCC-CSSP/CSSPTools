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
        private async Task<WebHydrometricDataValue> DoReadWebHydrometricDataValueGzFile(int HydrometricSiteTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebHydrometricDataValue());
            }

            WebHydrometricDataValue webHydrometricDataValue = await DoRead<WebHydrometricDataValue>($"WebHydrometricDataValue_{ HydrometricSiteTVItemID }.Gz");

            return await Task.FromResult(webHydrometricDataValue);
        }
    }
}
