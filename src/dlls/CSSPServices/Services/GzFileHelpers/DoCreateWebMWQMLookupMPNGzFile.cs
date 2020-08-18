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
    public partial class GzFileService : ControllerBase, IGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebMWQMLookupMPNGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebMWQMLookupMPN webMWQMLookupMPN = new WebMWQMLookupMPN();

            try
            {
                webMWQMLookupMPN.MWQMLookupMPNList = await GetMWQMLookupMPN();

                await DoStore<WebMWQMLookupMPN>(webMWQMLookupMPN, $"WebMWQMLookupMPN.gz");
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
