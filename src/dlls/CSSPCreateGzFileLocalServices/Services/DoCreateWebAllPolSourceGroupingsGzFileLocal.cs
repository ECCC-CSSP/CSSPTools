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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllPolSourceGroupingsGzFileLocal()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllPolSourceGroupings webAllPolSourceGroupings = new WebAllPolSourceGroupings();

            try
            {
                webAllPolSourceGroupings.PolSourceGroupingList = await GetPolSourceGroupingList();
                webAllPolSourceGroupings.PolSourceGroupingLanguageList = await GetPolSourceGroupingLanguageList();

                DoStoreLocal<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz");
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
