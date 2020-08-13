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
        private async Task<WebMunicipality> DoReadWebMunicipalityGzFile(int MunicipalityTVItemID)
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(new WebMunicipality());
            }

            WebMunicipality webMunicipality = await DoRead<WebMunicipality>($"WebMunicipality_{ MunicipalityTVItemID }.Gz");

            return await Task.FromResult(webMunicipality);
        }
    }
}
