/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllCountriesGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "TVType", TVTypeEnum.Root.ToString())));
            }

            WebAllCountries webAllCountries = new WebAllCountries();

            try
            {
                await FillChildListTVItemModelList(webAllCountries.TVItemAllCountryList, TVItemRoot, TVTypeEnum.Country);

                await DoStore<WebAllCountries>(webAllCountries, $"{ WebTypeEnum.WebAllCountries }.gz");
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
