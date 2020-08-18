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
        private async Task<ActionResult<bool>> DoCreateWebPolSourceGroupingGzFile()
        {
            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebPolSourceGrouping webPolSourceGrouping = new WebPolSourceGrouping();

            try
            {
                webPolSourceGrouping.PolSourceGroupingList = await GetPolSourceGroupingList();
                webPolSourceGrouping.PolSourceGroupingLanguageList = await GetPolSourceGroupingLanguageList();

                await DoStore<WebPolSourceGrouping>(webPolSourceGrouping, $"WebPolSourceGrouping.gz");
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
