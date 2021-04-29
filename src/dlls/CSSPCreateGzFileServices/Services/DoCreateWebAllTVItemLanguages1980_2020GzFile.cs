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
        private async Task<ActionResult<bool>> DoCreateWebAllTVItemLanguages1980_2020GzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllTVItemLanguages webAllTVItemLanguages = new WebAllTVItemLanguages();

            try
            {
                webAllTVItemLanguages.TVItemLanguageList = await GetAllTVItemLanguage1980_2020();

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllTVItemLanguages>(webAllTVItemLanguages, $"{ WebTypeEnum.WebAllTVItemLanguages1980_2020 }.gz");
                }
                else
                {
                    await DoStore<WebAllTVItemLanguages>(webAllTVItemLanguages, $"{ WebTypeEnum.WebAllTVItemLanguages1980_2020 }.gz");
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
