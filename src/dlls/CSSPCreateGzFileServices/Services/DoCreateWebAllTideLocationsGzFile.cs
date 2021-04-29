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
        private async Task<ActionResult<bool>> DoCreateWebAllTideLocationsGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllTideLocations webAllTideLocations = new WebAllTideLocations();

            try
            {
                webAllTideLocations.TideLocationList = await GetTideLocation();

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllTideLocations>(webAllTideLocations, $"{ WebTypeEnum.WebAllTideLocations }.gz");
                }
                else
                {
                    await DoStore<WebAllTideLocations>(webAllTideLocations, $"{ WebTypeEnum.WebAllTideLocations }.gz");
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
