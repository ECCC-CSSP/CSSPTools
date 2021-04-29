/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllTVItems2021_2060GzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllTVItems webAllTVItems = new WebAllTVItems();

            try
            {
                webAllTVItems.TVItemList = await GetAllTVItem2021_2060();

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllTVItems>(webAllTVItems, $"{ WebTypeEnum.WebAllTVItems2021_2060 }.gz");
                }
                else
                {
                    await DoStore<WebAllTVItems>(webAllTVItems, $"{ WebTypeEnum.WebAllTVItems2021_2060 }.gz");
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
