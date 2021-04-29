/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllMWQMLookupMPNsGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = new WebAllMWQMLookupMPNs();

            try
            {
                webAllMWQMLookupMPNs.MWQMLookupMPNList = await GetMWQMLookupMPN();

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllMWQMLookupMPNs>(webAllMWQMLookupMPNs, $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz");
                }
                else
                {
                    await DoStore<WebAllMWQMLookupMPNs>(webAllMWQMLookupMPNs, $"{ WebTypeEnum.WebAllMWQMLookupMPNs }.gz");
                }
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
