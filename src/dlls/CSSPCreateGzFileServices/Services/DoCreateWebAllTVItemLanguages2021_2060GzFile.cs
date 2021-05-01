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
        private async Task<ActionResult<bool>> DoCreateWebAllTVItemLanguages2021_2060GzFile()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            WebAllTVItemLanguages webAllTVItemLanguages = new WebAllTVItemLanguages();

            try
            {
                webAllTVItemLanguages.TVItemLanguageList = await GetAllTVItemLanguage2021_2060();

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebAllTVItemLanguages>(webAllTVItemLanguages, $"{ WebTypeEnum.WebAllTVItemLanguages2021_2060 }.gz");
                }
                else
                {
                    await DoStore<WebAllTVItemLanguages>(webAllTVItemLanguages, $"{ WebTypeEnum.WebAllTVItemLanguages2021_2060 }.gz");
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
