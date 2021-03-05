/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using CSSPEnums;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<ActionResult<bool>> DoCreateWebAllPolSourceSiteEffectTermsGzFileLocal()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = new WebAllPolSourceSiteEffectTerms();

            try
            {
                webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList = await GetPolSourceSiteEffectTermList();

                DoStoreLocal<WebAllPolSourceSiteEffectTerms>(webAllPolSourceSiteEffectTerms, $"{ WebTypeEnum.WebAllPolSourceSiteEffectTerms }.gz");
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