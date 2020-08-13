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
        private async Task<WebClimateDataValue> DoReadWebClimateDataValueGzFile(int ClimateSiteTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebClimateDataValue());
            }

            WebClimateDataValue webClimateDataValue = await DoRead<WebClimateDataValue>($"WebClimateDataValue_{ ClimateSiteTVItemID }.Gz");

            return await Task.FromResult(webClimateDataValue);
        }
    }
}
