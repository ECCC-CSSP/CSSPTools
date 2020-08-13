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
        private async Task<WebMikeScenario> DoReadWebMikeScenarioGzFile(int AreaTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMikeScenario());
            }

            WebMikeScenario webMikeScenario = await DoRead<WebMikeScenario>($"WebMikeScenario_{ AreaTVItemID }.Gz");

            return await Task.FromResult(webMikeScenario);
        }
    }
}
