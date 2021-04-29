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
        private async Task<ActionResult<bool>> DoCreateWebAllPolSourceGroupingsGzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllPolSourceGroupings webAllPolSourceGroupings = new WebAllPolSourceGroupings();

            try
            {
                await FillPolSourceGroupingModelList(webAllPolSourceGroupings.PolSourceGroupingModelList);

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz");
                }
                else
                {
                    await DoStore<WebAllPolSourceGroupings>(webAllPolSourceGroupings, $"{ WebTypeEnum.WebAllPolSourceGroupings }.gz");
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
