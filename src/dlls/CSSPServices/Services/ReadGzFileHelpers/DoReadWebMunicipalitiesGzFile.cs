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
        private async Task<WebMunicipalities> DoReadWebMunicipalitiesGzFile(int ProvinceTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMunicipalities());
            }

            WebMunicipalities webMunicipalities = await DoRead<WebMunicipalities>($"WebMunicipalities_{ ProvinceTVItemID }.Gz");

            return await Task.FromResult(webMunicipalities);
        }
    }
}
